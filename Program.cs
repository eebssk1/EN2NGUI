using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EN2NGui
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
              Application.ThreadException += handleException;
              AppDomain.CurrentDomain.UnhandledException += handleException;
            Directory.SetCurrentDirectory(MiscData.PWD);
            Application.Run(new Spla());
            if (!MiscData.isSplashExitAbornomal)
                Application.Run(new GUI());
        }
        private static void handleException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Critical Error:" + Environment.NewLine + ((Exception)e.ExceptionObject).Message + Environment.NewLine + ((Exception)e.ExceptionObject).StackTrace);
            Application.Exit();
        }
        private static void handleException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Critical Error:" + Environment.NewLine + e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);
            Application.Exit();
        }
    }
}
