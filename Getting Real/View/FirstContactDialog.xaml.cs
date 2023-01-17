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

namespace Getting_Real.View
{
    /// <summary>
    /// Interaction logic for FirstContactDialog.xaml
    /// </summary>
    public partial class FirstContactDialog : Window
    {
        CompanyController companyController = new CompanyController();

        CompanyViewModel cvm = new CompanyViewModel();

        public FirstContactDialog()
        {
            InitializeComponent();
            DataContext = cvm;
        }

        private void SetButton()
        {
            //This method enables the Register button once all the conditions are true.
            //This means that all the required boxes have to be filled out for the button to be enabled
            btnRegisterCompany.IsEnabled = (dpFirstContact.SelectedDate != null) && (cbStatus.Text != "") && (rBtnLetterNo.IsChecked == true || rBtnLetterYes.IsChecked == true) && (lbCompanyList.SelectedItem != null);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //This checks to see which radio button is checked and sets the value of letter
            //which is then passed as an argument in the method call
            bool letter = false;
            if (rBtnLetterYes.IsChecked == true)
                letter = true;
            else if (rBtnLetterNo.IsChecked == true)
                letter = false;

            //This will set the Comment to be ingen if no text is entered in the textbox,
            //To allow the user to not enter any value if none is necessary.
            string comment = "Ingen";
            if (tbComment.Text != "")
                comment = tbComment.Text;

            companyController.RegisterFirstContact((lbCompanyList.SelectedItem as Company).ID, dpFirstContact.SelectedDate.Value, cbStatus.Text, letter, comment);

            this.DialogResult = true;
        }

        private void dpFirstContact_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void rBtnLetterYes_Checked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void rBtnLetterNo_Checked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void lbCompanyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }
    }
}
