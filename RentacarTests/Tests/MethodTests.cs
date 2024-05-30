using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RentacarApp;
using RentacarApp.ViewModel;
using RentacarTests.Library;

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

        /// <summary>
        /// Тест проверки добавления авто
        /// </summary>
        [TestMethod()]
        public void TestingAddCar_ReturnTrue()
        {
            bool cars = TestLibrary.CheckAddCar("TestCar", DateTime.Today, "Бесцветный", "А001А-11", 1);

            Assert.IsTrue(cars);
        }

        /// <summary>
        /// Тест проверки удаления авто
        /// </summary>
        [TestMethod()]
        public void TestingDelCar()
        {
            bool cars = TestLibrary.CheckDelCar(14);

            Assert.IsTrue(cars);
        }

        /// <summary>
        /// Тест проверки добавления аренды
        /// </summary>
        [TestMethod()]
        public void TestingAddRental_ReturnTrue()
        {
            bool rental = TestLibrary.CheckAddRental(1, 1, "5000", DateTime.Today, DateTime.Now.AddDays(+1));

            Assert.IsTrue(rental);
        }

        /// <summary>
        /// Тест проверки удаления аренды
        /// </summary>
        [TestMethod()]
        public void TestingDelRental()
        {
            bool rental = TestLibrary.CheckDelRental(5);

            Assert.IsTrue(rental);
        }

        /// <summary>
        /// Тест проверки добавления обслуживания
        /// </summary>
        [TestMethod()]
        public void TestingAddUpkeep_ReturnTrue()
        {
            bool upkeep = TestLibrary.CheckAddUpkeep(1, DateTime.Today, DateTime.Now.AddDays(+1), "1010");

            Assert.IsTrue(upkeep);
        }

        /// <summary>
        /// Тест проверки удаления обслуживания
        /// </summary>
        [TestMethod()]
        public void TestingDelUpkeep()
        {
            bool upkeep = TestLibrary.CheckDelUpkeep(3);

            Assert.IsTrue(upkeep);
        }

        /// <summary>
        /// Тест проверки добавления клиента
        /// </summary>
        [TestMethod()]
        public void TestingAddClient_ReturnTrue()
        {
            bool client = TestLibrary.CheckAddClients("ул. Тестовая д. 1", "1111 111111", "Тестовый клиент", "111111-11", "88005553535");

            Assert.IsTrue(client);
        }

        /// <summary>
        /// Тест проверки удаления клиента
        /// </summary>
        [TestMethod()]
        public void TestingDelClient()
        {
            bool client = TestLibrary.CheckDelClients(6);

            Assert.IsTrue(client);
        }

        /// <summary>
        /// Тест проверки добавления пользователя
        /// </summary>
        [TestMethod()]
        public void TestingAddUser_ReturnTrue()
        {
            bool user = TestLibrary.CheckAddUsers("TestUser", "TestPassword", 3);

            Assert.IsTrue(user);
        }

        /// <summary>
        /// Тест проверки удаления пользователя
        /// </summary>
        [TestMethod()]
        public void TestingDelUser()
        {
            bool user = TestLibrary.CheckDelUsers(4);

            Assert.IsTrue(user);
        }
    }
}
