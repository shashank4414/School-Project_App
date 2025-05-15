using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace culinaryGuild
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            frmMain.Navigate(typeof(Home));
        }

        private void navMenu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string selectedTag = ((NavigationViewItem)args.InvokedItemContainer).Tag.ToString();

            switch (selectedTag)
            {
                case "Home":
                    frmMain.Navigate(typeof(Home));
                    break;
                case "SignUp":
                    frmMain.Navigate(typeof(SignUp));
                    break;
                case "Contact":
                    frmMain.Navigate(typeof(Contact));
                    break;
                default:
                    frmMain.Navigate(typeof(Home));
                    break;
                  

            }
        }
    }
}
