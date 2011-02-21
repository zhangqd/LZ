using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GLTWarter.Pages
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Login : DetailsBase
    {

        public Login(Galant.DataEntity.BaseData data)
            : base(data)
        {
            InitializeComponent();
            data.Operation = "Login";
            this.Unloaded += new RoutedEventHandler(Login_Unloaded);
        }

        void Login_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void FocusFirstControl()
        {
            this.textAlias.Focus();
        }

        private void passwordPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPopulation();
        }

        protected override void PreCommit()
        {

        }

        private void PasswordPopulation()
        {
            if (dataCurrent != null)
            {

            }
        }



        protected override void OnNext(Galant.DataEntity.BaseData incomingData)
        {
          
        }


        private void buttonCancelPrivate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DetailsBase_Return(object sender, ReturnEventArgs<Galant.DataEntity.BaseData> e)
        {

        }
        public event System.Windows.Navigation.ReturnEventHandler<string> VerdictReceived;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.textAlias.Text.Trim() == string.Empty)
            { }
            else if (this.passwordPassword.Password.Trim() == string.Empty)
            { }
            GLTService.ServiceAPIClient client = new GLTService.ServiceAPIClient();
            Galant.DataEntity.Entity entity = new Galant.DataEntity.Entity();
            entity.Alias = this.textAlias.Text;
            entity.Password = this.passwordPassword.Password.Trim();
            client.DoRequestCompleted += new EventHandler<GLTService.DoRequestCompletedEventArgs>(client_DoRequestCompleted);
            
            client.DoRequestAsync(entity, entity, "Login");
            
            
            System.Windows.Navigation.ReturnEventHandler<string> handler = VerdictReceived;
            if (handler != null)
            {
                handler(this, new System.Windows.Navigation.ReturnEventArgs<string>(null));
            }
        }

        public delegate void DoRequestCompleted(object sender, GLTService.DoRequestCompletedEventArgs e);
        public event DoRequestCompleted RequestCompletedEvent = null;

        void client_DoRequestCompleted(object sender, GLTService.DoRequestCompletedEventArgs e)
        {
            if (RequestCompletedEvent != null)
                this.RequestCompletedEvent.Invoke(sender, e);
            else
            { }
        }
    }
}
