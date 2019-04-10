using System;
using System.Windows.Forms;

namespace ChessApplication.Notifications
{
    public partial class NotificationsUserControl : UserControl
    {
        private readonly string notificationPattern = Strings.NotificationPattern;
        private readonly string notificationSeparator = Strings.NotificationSeparator;

        public NotificationsUserControl()
        {
            InitializeComponent();

            labelNotifications.Text = Strings.Notifications;
        }

        public void AddNotification(string notificationMessage, DateTime? notificationTime = null)
        {
            var currentTime = notificationTime == null
                ? DateTime.Now.ToString("h:mm:ss tt")
                : notificationTime.Value.ToString("h:mm:ss tt");

            var notification = string.Format(notificationPattern, currentTime, notificationMessage,
                notificationSeparator);
            textBoxNotifications.Text += notification;
        }

        public void ClearNotifications()
        {
            textBoxNotifications.Text = string.Empty;
        }
    }
}
