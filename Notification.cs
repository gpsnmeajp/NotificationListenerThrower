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
    class Notification
    {
        bool accessAllowed = false;
        UserNotificationListener userNotificationListener = null;

        public async Task<bool> Init()
        {
            if (!ApiInformation.IsTypePresent("Windows.UI.Notifications.Management.UserNotificationListener"))
            {
                accessAllowed = false;
                userNotificationListener = null;
                return false;
            }

            userNotificationListener = UserNotificationListener.Current;
            UserNotificationListenerAccessStatus accessStatus = await userNotificationListener.RequestAccessAsync();

            if (accessStatus != UserNotificationListenerAccessStatus.Allowed) {
                accessAllowed = false;
                userNotificationListener = null;
                return false;
            }
            accessAllowed = true;
            return true;
        }

        public async Task<List<NotificationMessage>> Get()
        {
            if (!accessAllowed) {
                return new List<NotificationMessage>();
            }

            List<NotificationMessage> list = new List<NotificationMessage>();

            IReadOnlyList<UserNotification> userNotifications = await userNotificationListener.GetNotificationsAsync(NotificationKinds.Toast);
            foreach (var n in userNotifications)
            {
                var notificationBinding = n.Notification.Visual.GetBinding(KnownNotificationBindings.ToastGeneric);
                if (notificationBinding != null)
                {
                    IReadOnlyList<AdaptiveNotificationText> textElements = notificationBinding.GetTextElements();
                    string titleText = textElements.FirstOrDefault()?.Text;
                    string bodyText = string.Join("\n", textElements.Skip(1).Select(t => t.Text));

                    list.Add(new NotificationMessage(n.Id, titleText, bodyText));
                }
            }
            return list;
        }
    }

}
