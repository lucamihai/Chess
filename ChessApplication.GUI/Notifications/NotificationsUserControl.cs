using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace ChessApplication.GUI.Notifications
{
    [ExcludeFromCodeCoverage]
    public partial class NotificationsUserControl : UserControl
    {
        private readonly string notificationSeparator = Constants.NotificationTextSeparator;

        public NotificationsUserControl()
        {
            InitializeComponent();

            labelNotifications.Text = Constants.NotificationsLabelText;
        }

        public void AddNotification(string notificationMessage)
        {
            var currentTime = DateTime.Now.ToString("h:mm:ss tt");
            var notificationText = $"{currentTime} -> {notificationMessage}{notificationSeparator}";
            textBoxNotifications.Text += notificationText;
        }

        public void ClearNotifications()
        {
            textBoxNotifications.Text = string.Empty;
        }
    }
}
