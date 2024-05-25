using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RentacarApp;
using RentacarApp.ViewModel;

namespace RentacarTests
{
    [TestClass]
    public class ViewModelChecks
    {
        /// <summary>
        /// Тест проверки авторизации пользователя, ввод пустого логина. Исключение ожидается
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void TestingAuthCheck_UsernameNull_ThrowEx()
        {
            bool auth = AuthVM.CheckAuth(" ", "password");
        }        
        
        /// <summary>
        /// Тест проверки авторизации пользователя, ввод пустого пароля. Исключение ожидается
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void TestingAuthCheck_PasswordNull_ThrowEx()
        {
            bool auth = AuthVM.CheckAuth("username", " ");
        }
        
        /// <summary>
        /// Тест проверки авторизации пользователя, ввод несуществующего пользователя. Исключение ожидается
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void TestingAuthCheck_UserNotExist_ThrowEx()
        {
            bool auth = AuthVM.CheckAuth("toor", "toor");
        }

        /// <summary>
        /// Тест проверки авторизации пользователя, ввод существующего пользователя
        /// </summary>
        [TestMethod()]
        public void TestingAuthCheck_SysAdminSignIn_ReturnTrue()
        {
            bool auth = AuthVM.CheckAuth("root", "root");

            Assert.IsTrue(auth);
        }
    }
}
