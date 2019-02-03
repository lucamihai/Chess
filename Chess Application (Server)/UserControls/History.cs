using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application.UserControls
{
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
            HistoryEntry historyEntry = new HistoryEntry(EntryCount, origin, destination);
            panelHistoryEntries.Controls.Add(historyEntry);
            historyEntry.Location = new Point(0, (EntryCount - 1) * 75);

            panelHistoryEntries.ScrollControlIntoView(historyEntry);
        }

        void ScrollToTopOfPanel()
        {
            panelHistoryEntries.VerticalScroll.Value = 0;
        }

        private void History_Load(object sender, EventArgs e)
        {

        }
    }
}
