using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDCITTechnicalAssignmentLibrary;

namespace GDCITTechnicalAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Instantiating needed variables.
                string directory = FindCSVFiles.GetCSVDirectory();
                List<string> fullFileList = FindCSVFiles.GetFileList(directory);
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
                List<CsvFileUser> userList = CSVRead.RetrieveFileUsers(userSearch, fullFileList, directory);

                //Prompts user if they would like to see the full list of users.
                bool wantList = true;
                do
                {
                    Console.Write("\nWould you like to see the full user list for this file? Y/N: ");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            Console.WriteLine("\n");
                            foreach (CsvFileUser item in userList)
                            {
                                Console.WriteLine(item);
                            }
                            wantList = false;
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("\n");
                            wantList = false;
                            break;
                        default:
                            Console.WriteLine("\n\nThat selection is invalid.  Please press 'Y' for yes, or 'N' for no.");
                            break;
                    }
                } while (wantList);

                //Validate the emails
                List<string> validEmails = new List<string>();
                List<string> invalidEmails = new List<string>();
                foreach (CsvFileUser item in userList)
                {
                    if (item.ValidateEmails())
                    {
                        validEmails.Add(item.Email);
                    }
                    else
                    {
                        invalidEmails.Add(item.Email);
                    }
                }

                //Show Invalid Emails 
                Console.WriteLine("\nInvalid Emails");
                foreach (string item in invalidEmails)
                {
                    Console.WriteLine(item);
                }
                //Show Valid Emails
                Console.WriteLine("\nValid Emails");
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
