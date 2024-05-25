using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RentacarApp;
using RentacarTests.Library;

namespace RentacarTests
{
    [TestClass]
    public class EnteredDataChecks
    {
        /// <summary>
        /// Поля содержащие только текст - введены символы
        /// </summary>
        [TestMethod]
        public void TestIncorrectStringTextCheck()
        {
            // Arrange
            string text = "###";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringTextCheck(text);
            // Assert
            Assert.IsFalse(result);
        }
    }
}
