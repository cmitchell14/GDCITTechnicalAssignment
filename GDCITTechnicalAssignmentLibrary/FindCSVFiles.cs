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
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\CSVFiles";
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


    }
}
