namespace ChaChaCoin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Miyabi.Asset.Models;
    using Miyabi.ClientSdk;
    using Miyabi.Common.Models;
    using Utility;

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Ver2 implements module system. To enable modules, register is required.
            AssetTypesRegisterer.RegisterTypes();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
