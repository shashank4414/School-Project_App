using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace culinaryGuild
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Thanks : Page
    {
        public Thanks()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                string name = e.Parameter.ToString();
                txtDisplay.Text = "Thank you for contacting us, " + name + "!" +
                    "\n\nWe will get back to you shortly";
                stackThanks.Visibility = Visibility.Visible;
            }
         
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
            stackThanks.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(Home));
        }
    }
}
