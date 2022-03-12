using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GDCITTechnicalAssignmentLibrary
{
    public class CsvFileUser
    {
        //Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //CTORS
        public CsvFileUser()
        {

        }

        public CsvFileUser(int id, string firstName, string lastName, string email)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        //Method
        public override string ToString()
        {
            return $"User: {FirstName} {LastName} \nEmail: {Email}\n";
        }

        //Method for Email Validation
        public bool ValidateEmails()
        {
            try
            {
                EmailAddressAttribute userEmail = new EmailAddressAttribute();
                if (userEmail.IsValid(Email))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
