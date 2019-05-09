using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common.UserControls;

namespace ChessApplication.History
{
    [ExcludeFromCodeCoverage]
    public partial class History : UserControl
    {
        public int EntryCount { get; private set; }

        public History()
        {
            InitializeComponent();

            panelHistoryEntries.AutoScroll = true;
        }

        public void AddEntry(Box origin, Box destination)
        {
            ScrollToTopOfPanel();

            EntryCount++;
            var historyEntry = new HistoryEntry(EntryCount, origin, destination);
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
