using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDCITTechnicalAssignmentLibrary;

namespace GDCITTechnicalAssignment.Tests.Models
{
    [TestClass]
    public class TCsvFileUserTests
    {
        [TestMethod]
        public void ValidateEmails_GoodUser_ReturnsTrue()
        {
            // arrange
            string firstName = "Test";
            string lastName = "Testerson";
            string email = "test@test.com";
            CsvFileUser user = new CsvFileUser(firstName, lastName, email);

            // act
            var answer = user.ValidateEmail();

            // assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void ValidateEmails_InvalidEmailUser_ReturnsFalse()
        {
            // arrange
            string firstName = "Test";
            string lastName = "Testerson";
            string email = "testest.com";
            CsvFileUser user = new CsvFileUser(firstName, lastName, email);

            // act
            var answer = user.ValidateEmail();

            // assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void ValidateEmails_BadUserData_ReturnsFalse()
        {
            // arrange
            CsvFileUser user = new CsvFileUser();

            // act
            var answer = user.ValidateEmail();

            // assert
            Assert.IsFalse(answer);
        }
    }
}
