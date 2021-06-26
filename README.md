# NotificationListenerThrower
Get Windows 10 notifications and deliver via WebSocket.  
Windows 10 の通知を取得し、WebSocketで配信します。  

If you turn on Viewer and apply, the simple WebSocket client will work in your browser.  
ViewerをオンにしてApplyすると、ブラウザにて簡易WebSocketクライアントが動作します。  

[Download](https://github.com/gpsnmeajp/NotificationListenerThrower/releases/)

![](img/img1.png)
![](img/img2.png)

## Specification
The settings are saved in setting.json in the same folder.  
設定は同フォルダのsetting.jsonに保存されます。

Notifications are taken every 100ms and new arrivals are delivered.  
通知は100ms秒間隔で取得し、新着が配信されます。  

The ping is delivered once a second.  
pingは1秒に1回配信されます。  

If Local Only is enabled, it will not accept connections from anyone other than localhost.  
Local Onlyが有効の場合、ローカルホスト以外からの接続は受け付けません  

If Present = NG, please allow the notification to be obtained from the Windows settings.  
Present=NGの場合、Windowsの設定から通知の取得を許可してください。  

Administrator privileges are used to open HTTP ports to the outside world. (Based on the HttpListener specification)  
管理者権限は、外部へHTTPポートを開くために使用します。(HttpListenerの仕様に基づく)  

```json
{"ping":true}

{"id":1, "title":"notification title","body":"notification body",}
```

## Reference
https://docs.microsoft.com/ja-JP/windows/apps/design/shell/tiles-and-notifications/notification-listener

## Licence
MIT Licence
