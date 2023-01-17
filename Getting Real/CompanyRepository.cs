using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real
{
    public class CompanyRepository
    {
        public List<Company> companies;
        private string fileName;

        public CompanyRepository()
        {
            companies = new List<Company>();
            
            //This reads the text file and adds the companies to the list.
            fileName = "CompanyList.txt";
            if (File.Exists(fileName))
            {
                int idCount = 0;
                StreamReader sr = new StreamReader(fileName);
                if (sr.Peek() != -1)
                {
                    while (sr.EndOfStream != true)
                    {
                        string[] companyAttributes = new string[9];
                        companyAttributes = sr.ReadLine().Split(',');
                        string companyName = companyAttributes[0];
                        string field = companyAttributes[1];
                        string phoneNumber = companyAttributes[2];
                        string eMail = companyAttributes[3];
                        string cvrNumber = companyAttributes[4];
                        DateTime dateOfFirstCContact = DateTime.Parse(companyAttributes[5]);
                        string status = companyAttributes[6];
                        string comment = companyAttributes[7];
                        bool followUpLetter = bool.Parse(companyAttributes[8]);
                        Company company = new Company(companyName, field, phoneNumber, eMail, cvrNumber, dateOfFirstCContact, status, comment, followUpLetter);
                        company.ID = idCount++;
                        companies.Add(company);
                    }
                }
                sr.Close();
            }
        }

        public void AddCompany(Company company)
        {
            companies.Add(company);
            fileName = "CompanyList.txt";

            WriteToFile(fileName);
        }

        public Company GetCompanyByName(string companyName)
        {
            foreach (Company company in companies)
            {
                if (company.CompanyName == companyName)
                {
                    return company;
                }
            }
            return null;
        }

        public Company GetCompanyByID(int id)
        {
            foreach(Company company in companies)
            {
                if (company.ID == id)
                {
                    return company;
                }
            }
            return null;
        }

        public List<Company> GetCompanies()
        {
            return companies;
        }

        public void UpdateCompany(Company company, string companyName, string field, string phoneNumber, string eMail, string cvrNumber, string status, bool followUpLetter, string comment)
        {
            //This check to see if the properties are different from the input values and changes the properties if they are
            if (company.CompanyName != companyName)
                company.CompanyName = companyName;
            if (company.Field != field)
                company.Field = field;
            if (company.PhoneNumber != phoneNumber)
                company.PhoneNumber = phoneNumber;
            if (company.EMail != eMail)
                company.EMail = eMail;
            if (company.CVRNumber != cvrNumber)
                company.CVRNumber = cvrNumber;
            if (company.Status != status)
                company.Status = status;
            if (company.FollowUpLetter != followUpLetter)
                company.FollowUpLetter = followUpLetter;
            if (company.Comment != comment)
                company.Comment = comment;

            fileName = "CompanyList.txt";
            WriteToFile(fileName);
        }

        public void RegisterFirstContact (Company company, DateTime dateOfFirstContact, string status, bool followUpLetter, string comment)
        {
            company.DateOfFirstContact = dateOfFirstContact;
            company.Status = status;
            company.FollowUpLetter = followUpLetter;
            company.Comment = comment;

            fileName = "CompanyList.txt";
            WriteToFile(fileName);
        }

        public void DeleteCompany(Company company)
        {
            companies.Remove(company);
            fileName = "CompanyList.txt";

            WriteToFile(fileName);
        }
        public void WriteToFile (string fileName)
        {
            File.Delete(fileName);
            StreamWriter sw = new StreamWriter(fileName, true);
            foreach (Company c in companies)
            {
                sw.WriteLine(c.ToString());
            }
            sw.Close();
        }
    }
}
