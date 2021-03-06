﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.IO.Packaging;

namespace GLTWarter.Pages
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : GLTWarter.Views.ViewBase
    {
        public Welcome()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Welcome_Loaded);
           
        }

        void Welcome_Loaded(object sender, RoutedEventArgs e)
        {
            FocusSelectedTabItem();
        }

        protected override void FocusFirstControl()
        {
            FocusSelectedTabItem();
        }

        void EffectiveRole_SelectedEntityChanged(object sender, EventArgs e)//将焦点指定在已显示的TabItem上
        {
            this.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.DataBind,
                (Action)delegate()
                {                    
                    FocusSelectedTabItem();
                }
            );
        }

        void FocusSelectedTabItem()
        {
            //if (this.tabControlMain.SelectedItem == null)
            //{
            //    FocusFirstUsableTab();
            //}
            //else if (((TabItem)this.tabControlMain.SelectedItem).Visibility != Visibility.Visible)
            //{
            //    FocusFirstUsableTab();
            //}
        }

        void FocusFirstUsableTab()
        {
            //foreach (TabItem ti in this.tabControlMain.Items)
            //{
            //    if (ti.Visibility == Visibility.Visible)
            //    {
            //        if (ti.Focusable)
            //        {
            //            this.tabControlMain.SelectedItem = ti;
            //            ti.Focus();
            //            break;
            //        }
            //    }
            //}
        }

        private void textQuickShipmentQuery_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyEventArgs ke = (KeyEventArgs)e;
            //if (!(ke.Key == Key.Enter && ke.KeyboardDevice.Modifiers == ModifierKeys.None))
            //{
            //    return;
            //}
            //e.Handled = true;

            //Shipment.Entity.SearchDataById data = new Shipment.Entity.SearchDataById();
            //data.ShipmentId = ((TextBox)sender).Text;
            //((TextBox)sender).Text = string.Empty;

            //this.NavigationService.Navigate(
            //    new Pages.Search(new Shipment.Entity.SearchById(data), new Shipment.Entity.Result(), new Shipment.Entity.ActionSingleGo())
            //);
        }

        public override bool IsRefreshable
        {
            get
            {
                return true;
            }
        }

        public override void OnRefresh()
        {
        }

        

       
       

        private void linkStationSimpleCheckout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("待开发");
        }

        private void linkWarterOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void linkDeliverOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}