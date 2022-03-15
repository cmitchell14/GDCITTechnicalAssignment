using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCITTechnicalAssignmentLibrary
{
    public class FindCSVFiles
    {
        //Methods
        //Retrieve Directory to search
        //TODO: Remove method, Possibly create file in csproj
        public static string GetCSVDirectory()
        {
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\CSVFiles";
            return filePath;
        }

        //Retrieves Full file list within the directory given.
        public static List<string> GetFileList(string directory)
        {
            try
            {
                //Find Directory & search for files while adding them to an array.
                string[] files = Directory.GetFiles(directory);

                //Add files to a list of strings to enable easier iteration and add ToUpper().
                List<string> fileNames = new List<string>() { };
                foreach (string file in files)
                {
                    fileNames.Add(Path.GetFileName(file).ToUpper());
                }
                //Return Full File list in CSVFiles Directory
                return fileNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Prompts user if they would like to see the full list of users.
        public static void GetUserList(List<CsvFileUser> userList)
        {
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
        }



    }
}
