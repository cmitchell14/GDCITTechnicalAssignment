using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDCITTechnicalAssignmentLibrary;
using System.Collections.Generic;
using GDCITTechnicalAssignmentLibrary.Services;

namespace GDCITTechnicalAssignment.Tests.Models
{
    [TestClass]
    public class EmailValidationTests
    {
        [TestMethod]
        public void GetValidEmails_OneValidEmail_CountOne()
        {
            // arrange - String List will always be ToUpper() due to previous method.
            List<CsvFileUser> userList = new List<CsvFileUser>() { new CsvFileUser("Tim", "Test", "Test@Test.com"), new CsvFileUser("Bob", "Testagain", "invalidtest.com")};

            // act
            var result = EmailValidation.GetValidEmails(userList);

            // assert
            Assert.AreEqual(1, result.Count) ;
        }

        [TestMethod]
        public void GetInvalidEmails_OneInvalidEmail_CountOne()
        {
            // arrange - String List will always be ToUpper() due to previous method.
            List<CsvFileUser> userList = new List<CsvFileUser>() { new CsvFileUser("Tim", "Test", "Test@Test.com"), new CsvFileUser("Bob", "Testagain", "invalidtest.com") };

            // act
            var result = EmailValidation.GetInvalidEmails(userList);

            // assert
            Assert.AreEqual(1, result.Count);
        }
    }
}
