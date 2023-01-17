using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real.ViewModel
{
    public class CompanyViewModel
    {
        public CompanyRepository CompanyRepository;
        public List<Company> Companies { get; set; }

        public List<Company> CompaniesToContact { get; set; }

        public Company SelectedCompany { get; set; }

        public string[] Status { get; set; }

        public string[] Field { get; set; }


        public CompanyViewModel()
        {
            CompanyRepository = new CompanyRepository();
            Companies = CompanyRepository.GetCompanies();

            //This adds all the companies which have not been contacted yet to the CompaniesToContact list
            //by checking if their DateOfFirstContact is equal to the default value for DateTime
            CompaniesToContact= new List<Company>();
            foreach (Company c in Companies)
            {
                if (c.DateOfFirstContact == default)
                {
                    CompaniesToContact.Add(c);
                }
            }

            Status = new string[] { "Ikke til at træffe", "Følg op igen senere", "Arbejder med bæredygtighed", "Afventer svar", "Indtalt besked/sendt mail" };

            Field = new string[] { "Efterskole", "Fitnesscenter", "Gymnasie", "Hotel og Kro", "Højskole", "Kommune" };
        }
    }
}
