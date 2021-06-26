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
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotificationListenerThrower
{
    public partial class Form1 : Form
    {
        class Setting {
            public string port { get; set; }
            public bool localonly { get; set; }
            public bool viewer{ get; set; }
        }

        Websocket websocket = new Websocket();
        Notification notification = new Notification();
        uint sent = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!await notification.Init())
            {
                PresentTextBox.Text = "NG";
                PresentTextBox.BackColor = Color.Red;
                return;
            }
            PresentTextBox.Text = "OK";
            PresentTextBox.BackColor = Color.Green;

            open(load());
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            websocket.Close();
        }

        List<NotificationMessage> lastNotificationMessage = new List<NotificationMessage>();
        private async void WatchTimer_Tick(object sender, EventArgs e)
        {
            List<NotificationMessage> notificationMessage = await notification.Get();

            DetectedListBox.Items.Clear();
            foreach (var n in notificationMessage)
            {
                string msg = JsonSerializer.Serialize(n);
                DetectedListBox.Items.Add(msg);
                if (lastNotificationMessage.Where(l => l.id == n.id).Count() == 0) {
                    //新規
                    await websocket.Broadcast(msg);
                    sent = unchecked(sent + 1);
                }
            }
            lastNotificationMessage = notificationMessage;

            SendTextBox.Text = sent.ToString();
       }
        private async void PingTimer_Tick(object sender, EventArgs e)
        {
            ConnectedTextBox.Text = websocket.GetConnected().ToString();
            await websocket.Broadcast("{\"ping\":true}");
        }


        private void ApplyButton_Click(object sender, EventArgs e)
        {
            open(save());
        }

        private Setting load()
        {
            Setting setting;
            if (File.Exists("setting.json"))
            {
                string json = File.ReadAllText("setting.json");
                try
                {
                    setting = JsonSerializer.Deserialize<Setting>(json);
                    PortTextBox.Text = setting.port;
                    LocalOnlyCheckBox.Checked = setting.localonly;
                    ViewerCheckBox.Checked = setting.viewer;
                    return setting;
                }
                catch (JsonException)
                {
                    //Do noting (json error)
                }
            }
            setting = new Setting
            {
                port = PortTextBox.Text,
                localonly = LocalOnlyCheckBox.Checked,
                viewer = ViewerCheckBox.Checked
            };
            return setting;
        }
        private Setting save()
        {
            Setting setting = new Setting
            {
                port = PortTextBox.Text,
                localonly = LocalOnlyCheckBox.Checked,
                viewer = ViewerCheckBox.Checked
            };

            string json = JsonSerializer.Serialize(setting);
            File.WriteAllText("setting.json", json);
            return setting;
        }

        private void open(Setting setting)
        {
            AccessStatusTextBox.Text = "CLOSED";
            AccessStatusTextBox.BackColor = Color.Red;

            websocket.Close();

            try
            {
                websocket.Open(setting.port, setting.localonly, setting.viewer);
            }
            catch (HttpListenerException e) {
                MessageBox.Show(e.Message);
                return;
            }
            AccessStatusTextBox.Text = "OPEN";
            AccessStatusTextBox.BackColor = Color.Green;
        }
    }
}
