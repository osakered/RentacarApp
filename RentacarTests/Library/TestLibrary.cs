using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RentacarApp;
using RentacarApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RentacarTests.Library
{
    internal class TestLibrary
    {
        /// <summary>
        /// Проверка строки текстового поля
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool StringTextCheck(string text)
        {
            Regex r = new Regex(@"[a-zA-Zа-яА-ЯЁё\s]$");
            if (!r.IsMatch(text))
            {
                return false;
            }
            if (text == String.Empty)
            {
                return false;
            }
            return true;
        }        
        
        /// <summary>
        /// Проверка поля государственного номера автомобиля
        /// </summary>
        /// <param name="regnum"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool StringRegNumberCheck(string regnum)
        {
            Regex r = new Regex(@"^[АВЕКМНОРСТУХ][0-9]{3}[АВЕКМНОРСТУХ]{2}[-][0-9]{2,3}$");
            if (!r.IsMatch(regnum))
            {
                return false;
            }
            if (regnum == String.Empty)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка корректности ввода номера телефона
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>
        /// true - в случае корректного ввода
        /// throw - в случае ввода некорректных данных
        /// </returns>
        public bool PhoneCheck(string phone)
        {
            string phonenumber = "1234567890+-";
            if (phone == String.Empty)
            {
                return false;
            }
            if (phone.Length < 11)
            {
                return false;
            }
            if (phone.Length > 12)
            {
                return false;
            }
            if (!phone.All(x => phonenumber.Contains(x)))
            {
                return false;
            }
            if (phone.StartsWith("+7"))
            {
                phone.Replace("+7", "8");
            }
            return true;
        }

        /// <summary>
        /// Проверка числового поля
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool DigitTextCheck(string numbers)
        {
            if (!numbers.All(char.IsDigit))
            {
                return false;
            }
            if (numbers == String.Empty)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка номера водительского удостоверения
        /// </summary>
        /// <param name="licensenumber"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool StringLicenseNumberCheck(string licensenumber)
        {
            Regex r = new Regex(@"[0-9]{6}[-][0-9]{2}");
            if (!r.IsMatch(licensenumber))
            {
                return false;
            }
            if (licensenumber == String.Empty)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка паспортных данных
        /// </summary>
        /// <param name="passportdata"></param>
        /// <returns>
        /// true - истина
        /// exception - ошибка
        /// </returns>
        public bool StringPassportDataCheck(string passportdata)
        {
            Regex r = new Regex(@"[0-9]{4}[\s][0-9]{6}");
            if (!r.IsMatch(passportdata))
            {
                return false;
            }
            if (passportdata == String.Empty)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод используется в тестировании приложения на добавление авто
        /// </summary>
        public static bool CheckAddCar(string carmodel, DateTime carprodyear, string carcolor, string regnumber, int idavailability)
        {
            Core db = new Core();
            try
            {
                Cars addCars = new Cars()
                {
                    CarModel = carmodel,
                    CarProdYear = carprodyear,
                    CarColor = carcolor,
                    RegNumber = regnumber,
                    IDAvailability = idavailability
                };

                db.context.Cars.Add(addCars);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на удаление авто
        /// </summary>
        public static bool CheckDelCar(int idcar)
        {
            Core db = new Core();
            try
            {
                Cars delCar = db.context.Cars.FirstOrDefault(x => x.IDCars == idcar);

                db.context.Cars.Remove(delCar);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на добавление данных аренды
        /// </summary>
        public static bool CheckAddRental(int idclient, int idcar, string cost, DateTime datestart, DateTime dateend)
        {
            Core db = new Core();
            try
            {
                Rental addRental = new Rental()
                {
                    IDClients = idclient,
                    IDCars = idcar,
                    Cost = Convert.ToDecimal(cost),
                    DateStart = datestart,
                    DateEnd = dateend
                };
                db.context.Rental.Add(addRental);
                db.context.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на удаление данных аренды
        /// </summary>
        public static bool CheckDelRental(int idrent)
        {
            Core db = new Core();
            try
            {
                Rental delRent = db.context.Rental.FirstOrDefault(x => x.IDRent == idrent);
                db.context.Rental.Remove(delRent);
                db.context.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на добавление данных об обслуживании
        /// </summary>
        public static bool CheckAddUpkeep(int idcars, DateTime beginupkeepdate, DateTime endupkeepdate, string price)
        {
            Core db = new Core();
            try
            {
                Upkeep addUpkeep = new Upkeep()
                {
                    IDCars = idcars,
                    BeginUpkeepDate = beginupkeepdate,
                    EndUpkeepDate = endupkeepdate,
                    Price = Convert.ToDecimal(price)
                };
                db.context.Upkeep.Add(addUpkeep);
                db.context.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на удаление данных об обслуживании
        /// </summary>
        public static bool CheckDelUpkeep(int idupkeep)
        {
            Core db = new Core();
            try
            {
                Upkeep delUpkeep = db.context.Upkeep.FirstOrDefault(x => x.IDUpkeep == idupkeep);
                db.context.Upkeep.Remove(delUpkeep);
                db.context.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на добавление клиента
        /// </summary>
        public static bool CheckAddClients(string address, string passportdata, string fullname, string dlicensenumber, string phonenumber)
        {
            Core db = new Core();
            try
            {
                Clients addClients = new Clients()
                {
                    Address = address,
                    PassportData = passportdata,
                    FullName = fullname,
                    DLicenseNumber = dlicensenumber,
                    PhoneNumber = phonenumber
                };
                db.context.Clients.Add(addClients);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на удаление клиента
        /// </summary>
        public static bool CheckDelClients(int idclient)
        {
            Core db = new Core();
            try
            {
                Clients delClient = db.context.Clients.FirstOrDefault(x => x.IDClients == idclient);
                db.context.Clients.Remove(delClient);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на добавление пользователя
        /// </summary>
        public static bool CheckAddUsers(string username, string password, int idrole)
        {
            Core db = new Core();
            try
            {
                Users addUsers = new Users()
                {
                    Username = username,
                    Password = password,
                    IDRole = idrole
                };
                db.context.Users.Add(addUsers);
                db.context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Метод используется в тестировании приложения на удаление пользователя
        /// </summary>
        public static bool CheckDelUsers(int iduser)
        {
            Core db = new Core();
            try
            {
                Users delUser = db.context.Users.FirstOrDefault(x => x.IDUsers == iduser);
                db.context.Users.Remove(delUser);
                db.context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
