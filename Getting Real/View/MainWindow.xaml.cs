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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Getting_Real.View;

namespace Getting_Real
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegisterCompany_Click(object sender, RoutedEventArgs e)
        {
            CreateCompanyDialog createCompanyDialog = new CreateCompanyDialog();
            createCompanyDialog.ShowDialog();
        }

        private void btnFirstContact_Click(object sender, RoutedEventArgs e)
        {
            FirstContactDialog firstContactDialog = new FirstContactDialog();
            firstContactDialog.ShowDialog();
        }

        private void btnDeleteOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateCompanyDialog updateCompanyDialog = new UpdateCompanyDialog();
            updateCompanyDialog.ShowDialog();
        }
    }
}
