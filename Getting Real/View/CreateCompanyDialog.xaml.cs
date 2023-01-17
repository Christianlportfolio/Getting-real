using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Getting_Real.ViewModel;

namespace Getting_Real
{
    /// <summary>
    /// Interaction logic for CreateCompanyDialog.xaml
    /// </summary>
    public partial class CreateCompanyDialog : Window
    {

        string savedPhoneNumber;
        string savedEmail;

        CompanyController companyController;

        CompanyViewModel cvm = new CompanyViewModel();


        public CreateCompanyDialog()
        {
            InitializeComponent();
            companyController = new CompanyController();

            DataContext = cvm;
        }

        private void SetButton()
        {
            //This method enables the Register button once all the conditions are true.
            //This means that all the required boxes have to be filled out for the button to be enabled
            btnRegisterCompany.IsEnabled = (tbCompanyName.Text != "") && (tbPhoneNumber.Text != "" || rBtnPhoneNumber.IsChecked == true) && (tbEmail.Text != "" || rBtnEmail.IsChecked == true) && (cbField.SelectedItem != null) && (tbCVRNumber.Text != "");
        }

        private void btnRegisterCompany_Click(object sender, RoutedEventArgs e)
        {
            //this check to see if the radiobuttons indicating that there is no phone number or Email is checked
            //and then calls the appropriate method.
            bool noPhoneNumber = rBtnPhoneNumber.IsChecked.Value;
            bool noEmail = rBtnEmail.IsChecked.Value;
            if(noPhoneNumber == true && noEmail == true)
            {
                companyController.CreateCompany(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text);
            }
            else if (noPhoneNumber == true)
            {
                companyController.CreateCompanyWithEMail(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text, tbEmail.Text);

            }
            else if (noEmail == true)
            {
                companyController.CreateCompanyWithPhone(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text, tbPhoneNumber.Text);
            }
            else
            {
                companyController.CreateCompanyWithPhoneAndEMail(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text, tbPhoneNumber.Text, tbEmail.Text);
            }

            this.DialogResult = true;
        }


        private void tbCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
            //This unchecks the "no phone number" radiobutton if text is entered into the phone number textbox
            rBtnPhoneNumber.IsChecked = false;
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
            //This unchecks the "no email" radiobutton if text is entered into the email textbox
            rBtnEmail.IsChecked = false;
        }

        private void cbField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void rBtnPhoneNumber_checked(object sender, RoutedEventArgs e)
        {
            SetButton();
            //This saves the text in the phone number textbox in case the use did not mean to click the no phone number radiobutton.
            //It is entered back into the textbox if the GotFocus event is triggered.
            if (tbPhoneNumber.Text != "")
            {
                savedPhoneNumber = tbPhoneNumber.Text;
                tbPhoneNumber.Text = "";
            }
            rBtnPhoneNumber.IsChecked = true;
        }

        private void rBtnEmail_checked(object sender, RoutedEventArgs e)
        {
            SetButton();
            //This saves the text in the Email textbox in case the use did not mean to click the no email radiobutton.
            //It is entered back into the textbox if the GotFocus event is triggered.
            if (tbEmail.Text != "")
            {
                savedEmail = tbEmail.Text;
                tbEmail.Text = "";
            }
            rBtnEmail.IsChecked = true;
        }

        private void rBtnPhoneNumber_unchecked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void rBtnEmail_unchecked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void tbPhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            //If there is a previously saved phone number, this enters the saved phone number into the textbox
            if(savedPhoneNumber != "")
            {
                tbPhoneNumber.Text = savedPhoneNumber;
                rBtnPhoneNumber.IsChecked = false;
            }
        }

        private void tbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            //If there is a previously saved email, this enters the saved email into the textbox
            if (savedPhoneNumber != "")
            {
                tbEmail.Text = savedEmail;
                rBtnEmail.IsChecked = false;
            }
        }
    }
}
