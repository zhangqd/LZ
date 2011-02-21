using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using Galant.DataEntity;

namespace GLTWarter
{
    public class AppCurrent : INotifyPropertyChanged
    {
        public readonly static log4net.ILog Logger = log4net.LogManager.GetLogger("MainLogger");

        public Window MainWindow { get { return Application.Current.MainWindow; } }

        public Galant.DataEntity.Entity Staff { get; set; }

        static public AppCurrent Active
        {
            get;
            set;
        }

        public AppCurrent()
        {
            Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGP31-M42XN-22M34-CWJA";           
            System.Threading.Thread.CurrentThread.CurrentUICulture = DeploymentSettings.Default.Locale;
            System.Threading.Thread.CurrentThread.CurrentCulture = DeploymentSettings.Default.Locale;
            Resource.Culture = DeploymentSettings.Default.Locale;
            Staff = new Entity();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
