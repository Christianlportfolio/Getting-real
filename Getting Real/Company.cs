using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real
{
    public class Company
    {
        public int ID { get; set; }
        
        public string CompanyName { get; set; }

        public string Field { get; set; }

        public string PhoneNumber { get; set; } = "";

        public string EMail { get; set; } = "";

        public string CVRNumber { get; set; } = "";

        public DateTime DateOfFirstContact { get; set; }

        public string Status { get; set; } = "";

        public string Comment { get; set; } = "";

        public bool FollowUpLetter { get; set; }

        public Company(string companyName, string field, string cvrNumber)
        {
            CompanyName = companyName;
            Field = field;
            CVRNumber = cvrNumber;
        }

        public Company(string companyName, string field, string cvrNumber, string phoneNumber, string eMail):
            this(companyName, field, cvrNumber)
        {
            PhoneNumber = phoneNumber;
            EMail = eMail;
        }

        public Company (string companyName, string field, string phoneNumber, string eMail, string cvrNumber, DateTime dateOfFirstContact, string status, string comment, bool followUpLetter):
            this(companyName, field, cvrNumber, phoneNumber, eMail)
        {
            DateOfFirstContact = dateOfFirstContact;
            Status = status;
            Comment = comment;
            FollowUpLetter = followUpLetter;
        }

        public override string ToString()
        {
            string title = CompanyName + "," + Field + "," + PhoneNumber + "," + EMail + "," + CVRNumber + "," + DateOfFirstContact.ToString() + "," + Status + "," + Comment + "," + FollowUpLetter;
            return title;
        }
    }
}
