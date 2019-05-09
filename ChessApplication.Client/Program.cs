using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChessApplication.Client.Forms;

namespace ChessApplication.Client
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
