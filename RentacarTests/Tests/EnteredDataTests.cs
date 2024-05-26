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
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringTextCheck_False()
        {
            // Arrange
            string text = "#/%^";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringTextCheck(text);
            // Assert
            Assert.IsFalse(result);
        }        
        
        /// <summary>
        /// Поля содержащие только текст - введено пустое поле
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringTextCheck_False2()
        {
            // Arrange
            string text = "";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringTextCheck(text);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие только текст - введены числа
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringTextCheck_False3()
        {
            // Arrange
            string text = "43241234";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringTextCheck(text);
            // Assert
            Assert.IsFalse(result);
        }        
        
        /// <summary>
        /// Поля содержащие только текст - введены буквы
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectStringTextCheck_True()
        {
            // Arrange
            string text = "буквы";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringTextCheck(text);
            // Assert
            Assert.IsTrue(result);
        }        
        
        /// <summary>
        /// Поля содержащие только текст - введены буквы
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectStringTextCheck_True2()
        {
            // Arrange
            string text = "letters";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringTextCheck(text);
            // Assert
            Assert.IsTrue(result);
        }        
        
        
        /// <summary>
        /// Поля содержащие госномер авто - введен правильный номер с трехзначным регионом
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectStringRegNumberCheck_True()
        {
            // Arrange
            string text = "Т543УХ-196";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringRegNumberCheck(text);
            // Assert
            Assert.IsTrue(result);
        }        
        
        /// <summary>
        /// Поля содержащие госномер авто - введен правильный номер с двухзначным регионом
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectStringRegNumberCheck_True2()
        {
            // Arrange
            string text = "О704ОХ-33";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringRegNumberCheck(text);
            // Assert
            Assert.IsTrue(result);
        }        
        
        /// <summary>
        /// Поля содержащие госномер авто - введено пустое поле
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringRegNumberCheck_False()
        {
            // Arrange
            string text = "";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringRegNumberCheck(text);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие госномер авто - введены некорректные буквы в госномере
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringRegNumberCheck_False2()
        {
            // Arrange
            string text = "Б543ЁЖ-43";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringRegNumberCheck(text);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие госномер авто - введен европейский госномер
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringRegNumberCheck_False3()
        {
            // Arrange
            string text = "CA-7890-BT";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringRegNumberCheck(text);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие госномер авто - введен СевАмериканский госномер
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectStringRegNumberCheck_False4()
        {
            // Arrange
            string text = "5PPP064";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.StringRegNumberCheck(text);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - номер введен корректно, начинается на +7
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestIncorrectNumberPhone_True()
        {
            // Arrange
            string phone = "+79095436437";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - номер введен корректно, начинается на 8
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_True2()
        {
            // Arrange
            string phone = "88005553535";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - номер введен корректно, казахский номер
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_True3()
        {
            // Arrange
            string phone = "+99305553535";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - введен пустое поле
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_False()
        {
            // Arrange
            string phone = "";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - введеный номер начинается с буквы
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_False2()
        {
            // Arrange
            string phone = "Б005553535";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - введены только буквы
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_False3()
        {
            // Arrange
            string phone = "БЕБЕБЕБАБАБА";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsFalse(result);
        }
        
        /// <summary>
        /// Проерка корректности ввода номера телефона - введен слишком длинный номер
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_False4()
        {
            // Arrange
            string phone = "+79093453258893447585932";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проерка корректности ввода номера телефона - введен слишком короткий номер
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberPhone_False5()
        {
            // Arrange
            string phone = "+79093453";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.PhoneCheck(phone);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие только числа - введено число
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectDigitTextCheck_True()
        {
            // Arrange
            string number = "4";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.DigitTextCheck(number);
            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Поля содержащие только числа - введены числа
        /// Ожидается true
        /// </summary>
        [TestMethod]
        public void TestCorrectDigitTextCheck_True2()
        {
            // Arrange
            string number = "42124";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.DigitTextCheck(number);
            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Поля содержащие только числа - введены символы
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectDigitTextCheck_False()
        {
            // Arrange
            string number = ":%?*";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.DigitTextCheck(number);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие только числа - введено пустое поле
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectDigitTextCheck_False2()
        {
            // Arrange
            string number = "";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.DigitTextCheck(number);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие только числа - введены русские буквы
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectDigitTextCheck_False3()
        {
            // Arrange
            string number = "буквы";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.DigitTextCheck(number);
            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Поля содержащие только числа - введены английские буквы
        /// Ожидается false
        /// </summary>
        [TestMethod]
        public void TestCorrectDigitTextCheck_False4()
        {
            // Arrange
            string number = "letters";
            // Act
            TestLibrary library = new TestLibrary();
            bool result = library.DigitTextCheck(number);
            // Assert
            Assert.IsFalse(result);
        }
    }
}
