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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //CTORS
        public CsvFileUser()
        {

        }

        public CsvFileUser( string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        //Method
        public override string ToString()
        {
            return $"User: {FirstName} {LastName} \nEmail: {Email}\n";
        }

        //Method for Email Validation.  Created for convenience in use of an instance method.  Ex. user.ValidateEmail()
        public bool ValidateEmail()
        {
            //Early exit if null or empty string for Email.
            if (String.IsNullOrEmpty(Email))
            {
                return false;
            }

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
    }
}
