using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
    public sealed partial class SignUp : Page
    {
        public SignUp()
        {
            this.InitializeComponent();
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            // input validation
            string errorOutput = "";

            // Verify name is not empty
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Length < 2)
            {
                errorOutput += "Name cannot be empty and must have two or more letters.\n";
            }

            if (!txtName.Text.Contains(" "))
            {
                errorOutput += "Please Enter both First and Last name.\n";
            }

            // Verify Phone Number length and format
            txtPhone.Text = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Length < 10)
            {
                errorOutput += "Enter Valid Phone Number.\n";
            }

            // Verify email is not empty and has the appropriate format            
            txtEmail.Text = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text.IndexOf("@") == -1 || txtEmail.Text.IndexOf(".com") == -1)
            {
                errorOutput += "Enter Valid Email.\n";
            }

            // Verify Delivery Date has not passed
            if (dtpStartDate.Date.DateTime < DateTime.Today)
            {
                errorOutput += "Enter Valid Start Date.\n";
            }

            // Verify Selections have been made
            ComboBoxItem selectedLength = (ComboBoxItem)cboSubLength.SelectedItem;
            ComboBoxItem selectedType = (ComboBoxItem)cboSubType.SelectedItem;

            if (selectedLength == null)
            {
                errorOutput += "Please Select subscription length.\n";
            }
            if (selectedType == null)
            {
                errorOutput += "Please Select subscription type.\n";
            }

            // In case of no errors
            if (errorOutput == "")
            {
                int price = Int32.Parse(selectedLength.Tag.ToString()) * Int32.Parse(selectedType.Tag.ToString());
                // Generate a random 10-digit code
                string confirmCode = "";
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int random = rnd.Next(0, 10);
                    confirmCode.Concat(random.ToString());
                }
                txtResults.Text = "Checkout Complete!\n" +
                    "\n========= Information Summary =========" +
                    "\nSubscription Length : " + selectedLength.Content.ToString() +
                    "\nSubscription Type : " + selectedType.Content.ToString() +
                    "\n\nTotal Cost: $" + price.ToString() +
                    "\nConfirmation code:" + confirmCode;

                stackSignUp.Visibility = Visibility.Collapsed;
                txtResults.Visibility = Visibility.Visible;
            }
            // If case of errors
            else
            {
                MessageDialog error = new MessageDialog(errorOutput);
                error.ShowAsync();
            }
        }
    }
}
