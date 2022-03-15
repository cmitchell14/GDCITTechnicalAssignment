using System;
using System.Collections.Generic;
using GDCITTechnicalAssignmentLibrary;
using GDCITTechnicalAssignmentLibrary.Services;

namespace GDCITTechnicalAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Instantiating needed variables.
                List<string> fullFileList = FindCSVFiles.GetFileList(FindCSVFiles.GetCSVDirectory());
                string userSearch = "";
                
                //Capturing user input for the search term. In a loop to retry submission if file not found.
                do
                {
                    Console.Write("Please enter the file you are searching for: ");
                    userSearch = Console.ReadLine();
                } while (!CSVRead.SearchResult(userSearch, fullFileList));

                //Adds .csv to filename if it was searched without it.  Also trims the submission to allow accidental white spaces.
                userSearch = CSVRead.UserSearchConvert(userSearch);

                //Retrieve Users from the searched file.
                List<CsvFileUser> userList = CSVRead.RetrieveFileUsers(userSearch, fullFileList, FindCSVFiles.GetCSVDirectory());

                //Ask user if they would like to see a full user list before email validation.
                FindCSVFiles.GetUserList(userList);

                //Validate the emails
                List<string> validEmails = EmailValidation.GetValidEmails(userList);
                List<string> invalidEmails = EmailValidation.GetInvalidEmails(userList);

                //Show Invalid Emails 
                Console.WriteLine("\nInvalid Emails");
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string item in invalidEmails)
                {
                    Console.WriteLine(item);
                }
                //Show Valid Emails
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nValid Emails");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (string item in validEmails)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
