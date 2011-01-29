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

        public Login(Data.BusinessEntity data)
            : base(data)
        {
            InitializeComponent();
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



        protected override void OnNext(GLTWarter.Data.BusinessEntity incomingData)
        {


        }


        private void buttonCancelPrivate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DetailsBase_Return(object sender, ReturnEventArgs<Data.BusinessEntity> e)
        {

        }
    }
}
