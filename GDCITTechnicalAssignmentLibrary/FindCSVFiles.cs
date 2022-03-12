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
        public static string GetCSVDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 9) + "CSVFiles";
            return dir;
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


    }
}
