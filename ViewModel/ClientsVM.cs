using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{
    /// <summary>
    /// Логика кнопок страницы ClientsPage.xaml
    /// </summary>
    internal class ClientsVM
    {
        Core db = new Core();
        /// <summary>
        /// Добавление клиента в базу данных
        /// Фиксация добавления в журнал действий
        /// </summary>
        /// <param name="address"></param>
        /// <param name="passportdata"></param>
        /// <param name="fullname"></param>
        /// <param name="dlicensenumber"></param>
        /// <param name="phonenumber"></param>
        public void AddClients(string address, string passportdata, string fullname, string dlicensenumber, string phonenumber)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 1,
                TableName = "Клиенты"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

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
        }

        /// <summary>
        /// Проверка корректного ввода номера телефона
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
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
        /// Проверка полей ввода на корректные данные
        /// </summary>
        /// <param name="address"></param>
        /// <param name="passportdata"></param>
        /// <param name="fullname"></param>
        /// <param name="dlicensenumber"></param>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool CheckClients(string address, string passportdata, string fullname, string dlicensenumber, string phonenumber)
        {
            if (String.IsNullOrEmpty(address) && String.IsNullOrEmpty(passportdata) && String.IsNullOrEmpty(fullname) && String.IsNullOrEmpty(dlicensenumber) && String.IsNullOrEmpty(phonenumber))
            {
                throw new Exception("Заполните поля");
            }
            if (String.IsNullOrEmpty(address))
            {
                throw new Exception("Адрес не указан");
            }
            if (String.IsNullOrEmpty(passportdata))
            {
                throw new Exception("Паспортные данные не указаны");
            }
            Regex rr = new Regex(@"[0-9]{4}[\s][0-9]{6}");
            if (!rr.IsMatch(passportdata)) 
            {
                throw new Exception("Паспортные данные указаны неверно");
            }
            if (String.IsNullOrEmpty(fullname))
            {
                throw new Exception("ФИО не указано");
            }
            if (String.IsNullOrEmpty(dlicensenumber))
            {
                throw new Exception("Номер водительского удостоверения не указан");
            }
            Regex r = new Regex(@"[0-9]{6}[-][0-9]{2}");
            if (!r.IsMatch(dlicensenumber))
            {
                throw new Exception("Номер водительского удостоверения указан неверно");
            }
            if (String.IsNullOrEmpty(phonenumber))
            {
                throw new Exception("Номер телефона не указан");
            }
            bool phonechk = PhoneCheck(phonenumber);
            if (phonechk == false)
            {
                throw new Exception("Номер телефона указан неверно");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Удаление клиента из базы данных
        /// Фиксация удаления в журнал действий
        /// </summary>
        /// <param name="idClient"></param>
        public void DeleteClient(int idClient)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 3,
                TableName = "Клиенты"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Clients delClient = db.context.Clients.FirstOrDefault(x => x.IDClients == idClient);
            db.context.Clients.Remove(delClient);
            db.context.SaveChanges();
        }

        /// <summary>
        /// Фиксация редактирования в журнал действий
        /// </summary>
        public void AddLog_Edit()
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 2,
                TableName = "Клиенты"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();
        }
    }
}
