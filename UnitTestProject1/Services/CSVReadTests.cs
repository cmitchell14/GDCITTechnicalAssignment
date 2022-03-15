using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDCITTechnicalAssignmentLibrary;
using System.Collections.Generic;

namespace GDCITTechnicalAssignment.Tests.Models
{
    [TestClass]
    public class CSVReadTests
    {
        [TestMethod]
        public void SearchResult_NoFileExtension_ReturnsTrue()
        {
            // arrange - String List will always be ToUpper() due to previous method.
            List<string> fileList = new List<string>() { "TEST.CSV", "FAIL.CSV" };
            string userSearch = "test";

            // act
            var result = CSVRead.SearchResult(userSearch, fileList);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchResult_LowerCaseFileName_ReturnsFalse()
        {
            // arrange - String List will always be ToUpper() due to previous method.  
            List<string> fileList = new List<string>() { "test.CSV", "FAIL.CSV" };
            string userSearch = "test";

            // act
            var result = CSVRead.SearchResult(userSearch, fileList);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchResult_WithExtension_ReturnsTrue()
        {
            // arrange - String List will always be ToUpper() due to previous method.  
            List<string> fileList = new List<string>() { "TEST.CSV", "FAIL.CSV" };
            string userSearch = "test.csv";

            // act
            var result = CSVRead.SearchResult(userSearch, fileList);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchResult_NotInList_ReturnsFalse()
        {
            // arrange - String List will always be ToUpper() due to previous method.  
            List<string> fileList = new List<string>() { "test.CSV", "FAIL.CSV" };
            string userSearch = "nope.csv";

            // act
            var result = CSVRead.SearchResult(userSearch, fileList);

            // assert
            Assert.IsFalse(result);
        }
    }
}
