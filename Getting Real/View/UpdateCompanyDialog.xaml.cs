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
using Getting_Real;
using Getting_Real.ViewModel;

namespace Getting_Real.View
{
    /// <summary>
    /// Interaction logic for UpdateCompany.xaml
    /// </summary>
    public partial class UpdateCompanyDialog : Window
    {
        CompanyController companyController;

        CompanyViewModel cvm;

        public string[] Status { get; set; }
        public UpdateCompanyDialog()
        {
            InitializeComponent();
            companyController = new CompanyController();
            cvm = new CompanyViewModel();

            DataContext = cvm;
        }

        private void btnSaveCompany_Click(object sender, RoutedEventArgs e)
        {
            //This checks to see which radio button is checked and sets the value of letter
            //which is then passed as an argument in the method call
            bool letter = false;
            if (rBtnLetterYes.IsChecked == true)
            {
                letter = true;
            }
            else if (rBtnLetterNo.IsChecked == true)
            {
                letter = false;
            }

            //If no status is given yet this will set the staus to and empty string to prevent an exception being thrown.
            //Ottherwise status will be set to the value of the textbox
            string status = "";
            if(cbStatus.SelectedItem != null)
            {
                status = cbStatus.SelectedItem.ToString();
            }

            Company company = lbCompanyList.SelectedItem as Company;
            companyController.UpdateSelectedCompany(company.ID, tbCompanyName.Text, cbField.Text, tbPhoneNumber.Text, tbEmail.Text, tbCVRNumber.Text, status, letter, tbComment.Text);
            this.DialogResult = true;
        }


        private void btnDeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            Company company = lbCompanyList.SelectedItem as Company;
            companyController.DeleteSelectedCompany(company.ID);
            this.DialogResult = true;
        }

        private void lbCompanyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //This checks the value of the property FollowUpLetter to determine which radio buttin to check
            Company company = lbCompanyList.SelectedItem as Company;
            if (company.FollowUpLetter == true)
            {
                rBtnLetterYes.IsChecked = true;
            }
            else if (company.FollowUpLetter == false)
            {
                rBtnLetterNo.IsChecked = true;
            }

            //This enables the Save and Delete buttons once a company is selected from the list.
            btnDeleteCompany.IsEnabled = true;
            btnSaveCompany.IsEnabled = true;
        }
    }
}
