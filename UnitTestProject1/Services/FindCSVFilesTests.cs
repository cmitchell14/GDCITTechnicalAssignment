using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDCITTechnicalAssignmentLibrary;
using System.Collections.Generic;

namespace GDCITTechnicalAssignment.Tests.Models
{
    [TestClass]
    public class FindcsvfilesTests
    {
        [TestMethod]
        public void SearchResult_NoFileExtension_ReturnsTrue()
        {
            // arrange - String List will always be ToUpper() due to previous method.
            List<string> fileList = new List<string>() { "TEST.CSV", "FAIL.CSV"};
            string userSearch = "test";

            // act
            var result = CSVRead.SearchResult(userSearch, fileList);

            // assert
            Assert.IsTrue(result);
        }
    }
}
