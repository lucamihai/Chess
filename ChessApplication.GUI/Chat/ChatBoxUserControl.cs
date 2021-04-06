using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace ChessApplication.GUI.Chat
{
    [ExcludeFromCodeCoverage]
    public partial class ChatBoxUserControl : UserControl
    {
        private readonly string separator = Constants.Separator;

        public string Username { get; set; }

        public delegate void SentChat(string message);
        public SentChat OnSentChat { get; set; }

        public ChatBoxUserControl()
        {
            InitializeComponent();

            labelChatBox.Text = Constants.ChatLabelText;
            Username = Constants.DefaultUsername;
        }
        
        public void AddChatMessage(string username, string message)
        {
            var currentTime = DateTime.Now.ToString("h:mm:ss tt");
            var chatEntry = $"{currentTime} {username}: {message}{separator}";

            textBoxChat.Text += chatEntry;
        }

        public void ClearChatMessages()
        {
            textBoxChat.Text = string.Empty;
        }

        private void TextBoxInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Send(sender, e);
            }
        }

        private void Send(object sender, EventArgs e)
        {
            AddChatMessage(Username, textBoxInput.Text);
            OnSentChat(textBoxInput.Text);

            textBoxInput.Text = string.Empty;
            textBoxInput.Text = textBoxInput.Text.Trim();
            textBoxInput.Focus();
        }
    }
}
