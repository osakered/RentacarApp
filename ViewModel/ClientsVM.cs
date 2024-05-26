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
    internal class ClientsVM
    {
        Core db = new Core();

        public void AddClients(string address, string passportdata, string fullname, string dlicensenumber, string phonenumber)
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
        }
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

        public void DeleteClient(int idClient)
        {
            Clients delClient = db.context.Clients.FirstOrDefault(x => x.IDClients == idClient);
            db.context.Clients.Remove(delClient);
            db.context.SaveChanges();
        }
    }
}
