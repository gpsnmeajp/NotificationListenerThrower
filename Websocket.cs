/*
MIT License

Copyright (c) 2021 gpsnmeajp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.UI.Notifications.Management;
using Windows.Foundation.Metadata;
using Windows.UI.Notifications;


namespace NotificationListenerThrower
{
    class Websocket
    {
        HttpListener httpListener = null;
        Task httpListenerTask = null;

        List<WebSocket> WebSockets = new List<WebSocket>();

        bool localOnly = false;
        bool viewer = false;

        public void Open(string port, bool localOnly, bool viewer) {
            this.localOnly = localOnly;
            this.viewer = viewer;

            string host = localOnly ? "127.0.0.1" : "+";

            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://" + host + ":" + port + "/");
            httpListener.Start();

            //接続待受タスク
            httpListenerTask = new Task(async () => {
                try
                {
                    while (true)
                    {
                        HttpListenerContext context = await httpListener.GetContextAsync();
                        if (localOnly == true && context.Request.IsLocal == false)
                        {
                            context.Response.StatusCode = 400;
                            context.Response.Close(Encoding.UTF8.GetBytes("400 Bad request"), true);
                            continue;
                        }

                        if (!context.Request.IsWebSocketRequest)
                        {
                            if (viewer)
                            {
                                context.Response.StatusCode = 200;
                                context.Response.Close(Encoding.UTF8.GetBytes(html), true);
                            }
                            else {
                                context.Response.StatusCode = 404;
                                context.Response.Close(Encoding.UTF8.GetBytes("404 Not found"), true);
                            }
                            continue;
                        }

                        if (WebSockets.Count > 1024)
                        {
                            context.Response.StatusCode = 503;
                            context.Response.Close(Encoding.UTF8.GetBytes("503 Service Unavailable"), true);
                            continue;
                        }

                        HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                        WebSocket webSocket = webSocketContext.WebSocket;

                        if (localOnly == true && webSocketContext.IsLocal == false)
                        {
                            webSocket.Abort();
                            continue;
                        }

                        WebSockets.Add(webSocket);
                    }
                }
                catch (HttpListenerException)
                {
                    //Do noting (Closed)
                }
            });
            httpListenerTask.Start();
        }

        public async Task Broadcast(string msg) {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
            foreach (var ws in WebSockets)
            {
                try
                {
                    if (ws.State == WebSocketState.Open)
                    {
                        await ws.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                    else
                    {
                        ws.Abort();
                    }
                }
                catch (WebSocketException)
                {
                    //Do noting (Closed)
                }
            }
            WebSockets.RemoveAll(ws => ws.State != WebSocketState.Open);
        }

        public void Close() {
            foreach (var ws in WebSockets)
            {
                ws.Abort();
                ws.Dispose();
            }
            WebSockets.Clear();

            try
            {
                httpListener?.Stop();
            }
            catch (Exception) { 
                //Do noting
            }
            httpListenerTask?.Wait();
            httpListenerTask?.Dispose();
        }

        public int GetConnected() {
            return WebSockets.Count;
        }


        string html = @"<html>
<head>
<meta charset='UTF-8'/>
<meta name='viewport' content='width=device-width,initial-scale=1'>
</head>
<body>
<input id='ip' value='ws://127.0.0.1:8000'></input>
<button onclick='connect();'>CONNECT</button>
<button onclick='disconnect();'>DISCONNECT</button>
<div id='ping'></div>
<div id='log'></div>
<script>
let socket = null;
let lastupdate = new Date();

window.onload = function() {
	document.getElementById('ip').value = 'ws://'+location.host;
    connect();
};
function connect(){
	try{
	if(socket != null){
		socket.close();
	}
	socket = new WebSocket(document.getElementById('ip').value);
	socket.addEventListener('error', function (event) {
	    document.getElementById('log').innerText = 'CONNECTION ERROR';	
	});
	socket.addEventListener('open', function (event) {
	    document.getElementById('log').innerText = 'CONNECT...';	
	});
	socket.addEventListener('message', function (event) {
        let packet = JSON.parse(event.data);
		if('ping' in packet){
            lastupdate = new Date();
		    document.getElementById('ping').innerText = 'ping: '+lastupdate;
		}else{
		    document.getElementById('log').innerText = packet.id +':'+packet.title+':'+packet.body +'\n'+ document.getElementById('log').innerText;
		}
	});
	socket.addEventListener('onclose', function (event) {
	    document.getElementById('log').innerText = document.getElementById('log').innerText +'\n' +'CLOSED';
		socket.close();
		socket = null;
	});
	}catch(e){
	    document.getElementById('log').innerHTML = e;	
	}
}
function disconnect(){
	socket.close();
	socket = null;
    document.getElementById('log').innerText = 'DISCONNECT';	
}
function timeout(){
    if(new Date().getTime() - lastupdate.getTime() > 3000){
        if(socket != null){
            document.getElementById('ping').innerText = 'ping: TIMEOUT! RECONNECTING...';
            disconnect();
            connect();
        }else{
            document.getElementById('ping').innerText = 'ping: TIMEOUT!';
        }
    }
}
setInterval(timeout,1000);

</script>
</body>
</html>";
    }
}
