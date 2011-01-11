using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace GLTWarter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        static public App Active
        {
            get;
            set;
        }

        public MainScreen MainScreen { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGP31-M42XN-22M34-CWJA";

            this.MainWindow = new MainScreen();
            //if (new LoginScreen(App.Active.Rpc).ShowDialog() == false)
            //{
            //    Application.Current.Shutdown();
            //}
           this.MainWindow.Show();
        }
    }
}
