using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChessApplication.GUI.Forms;

namespace ChessApplication.GUI
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
