using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCITTechnicalAssignmentLibrary.Services
{
    public class EmailValidation
    {
        //Generates a List for valid emails.
        public static List<string> GetValidEmails(List<CsvFileUser> userList)
        {
            List<string> validEmails = new List<string>();
            foreach (CsvFileUser item in userList)
            {
                if (item.ValidateEmail())
                {
                    validEmails.Add(item.Email);
                } 
            }
            return validEmails;
        }

        //Generates a List for invalid emails.
        public static List<string> GetInvalidEmails(List<CsvFileUser> userList)
        {
            List<string> invalidEmails = new List<string>();

            foreach (CsvFileUser item in userList)
            {
                if (!item.ValidateEmail())
                {
                    invalidEmails.Add(item.Email);
                }
            }
            return invalidEmails;
        }
    }
}
