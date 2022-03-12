using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCITTechnicalAssignmentLibrary
{
    public class CSVRead
    {
        //Methods
        //Retrieves full user list from the file searched.
        public static bool SearchResult(string userSearch, List<string> fullFileList)
        {
            try
            {
                if (fullFileList.Contains(userSearch.Trim().ToUpper()) || fullFileList.Contains(userSearch.Trim().ToUpper() + ".CSV"))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("That file wasn't found.  Please try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Checks and converts userSearch to add .csv if needed.
        public static string UserSearchConvert(string userSearch)
        {
            if (userSearch.ToUpper().Contains(".CSV"))
            {
                return userSearch.Trim();
            }
            else
            {
                userSearch = userSearch.Trim() + ".CSV";
                return userSearch;
            }
        }

        public static List<CsvFileUser> RetrieveFileUsers(string userSearch, List<string> fullFileList, string directory)
        {
            try
            {
                //Declare Lists to capture data for CsvFileUser.
                List<string> firstName = new List<string>();
                List<string> lastName = new List<string>();
                List<string> email = new List<string>();
                List<CsvFileUser> users = new List<CsvFileUser>();

                //use StreamReader to iterate through rows in the .csv file.
                using (StreamReader reader = new StreamReader(directory + @"\" + userSearch))
                {
                    while (!reader.EndOfStream)
                    {
                        string row = reader.ReadLine();
                        string[] values = row.Split(',');

                        firstName.Add(values[0]);
                        lastName.Add(values[1]);
                        email.Add(values[2]);
                    }
                }

                //Create CsvFileUser Instance for each user, and add them to list.
                int userCount = firstName.Count() - 1;
                for (int i = 1; i <= userCount; i++)
                {
                    users.Add(new CsvFileUser { ID = i, FirstName = firstName[i].Substring(1), LastName = lastName[i], Email = email[i].Substring(0, email[i].Length - 1) });
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
