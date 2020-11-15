using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common.UserControls;

namespace ChessApplication.GUI.History
{
    [ExcludeFromCodeCoverage]
    public partial class HistoryUserControl : UserControl
    {
        public int EntryCount { get; private set; }

        public HistoryUserControl()
        {
            InitializeComponent();

            panelHistoryEntries.AutoScroll = true;
        }

        public void AddEntry(Box origin, Box destination)
        {
            ScrollToTopOfPanel();

            EntryCount++;
            var historyEntry = new HistoryEntryUserControl(EntryCount, origin, destination);
            panelHistoryEntries.Controls.Add(historyEntry);

            var entryHeight = (EntryCount - 1) * 75;
            historyEntry.Location = new Point(0, entryHeight);

            panelHistoryEntries.ScrollControlIntoView(historyEntry);
        }

        private void ScrollToTopOfPanel()
        {
            panelHistoryEntries.VerticalScroll.Value = 0;
        }
    }
}
