using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real
{
    public class CompanyController
    {
        public CompanyRepository CompanyRepository;

        public CompanyController()
        {
            CompanyRepository = new CompanyRepository();
        }

        public List<Company> GetCompanyList()
        {
            return CompanyRepository.GetCompanies();
        }

        public void CreateCompany(string name, string field, string cvrNumber)
        {
            Company company = new Company(name, field, cvrNumber);
            company.PhoneNumber = "Ingen";
            company.EMail = "Ingen";
            CompanyRepository.AddCompany(company);
        }

        //There are seperate methods for CreateCompany based on what contact information there is,
        //since it was not possible to create seperate constructors for the 2 scenarios in the Company class
        //as PhoneNumber and EMail are both strings.
        public void CreateCompanyWithPhone(string name, string field, string cvrNumber, string phoneNumber)
        {
            Company company = new Company(name, field, cvrNumber);
            company.PhoneNumber = phoneNumber;
            company.EMail = "Ingen";
            CompanyRepository.AddCompany(company);
        }

        public void CreateCompanyWithEMail(string name, string field, string cvrNumber, string eMail)
        {
            Company company = new Company(name, field, cvrNumber);
            company.EMail = eMail;
            company.PhoneNumber = "Ingen";
            CompanyRepository.AddCompany(company);
        }

        public void CreateCompanyWithPhoneAndEMail(string name, string field, string cvrNumber, string phoneNumber, string eMail)
        {
            Company company = new Company(name, field, cvrNumber, phoneNumber, eMail);
            CompanyRepository.AddCompany(company);
        }

        public void UpdateSelectedCompany(int id, string companyName, string field, string phoneNumber, string eMail, string cvrNumber, string status, bool followUpLetter, string comment)
        {
            Company selectedCompany = CompanyRepository.GetCompanyByID(id);
            CompanyRepository.UpdateCompany(selectedCompany, companyName, field, phoneNumber, eMail, cvrNumber, status, followUpLetter, comment);
        }

        public void RegisterFirstContact(int id, DateTime date, string status, bool followUpLetter, string comment)
        {
            Company selectedCompany = CompanyRepository.GetCompanyByID(id);
            CompanyRepository.RegisterFirstContact(selectedCompany, date, status, followUpLetter, comment);
        }

        public void DeleteSelectedCompany(int id)
        {
            Company selectedCompany = CompanyRepository.GetCompanyByID(id);
            CompanyRepository.DeleteCompany(selectedCompany);
        }
    }
}
