using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{
    internal class ClientsVM
    {
        Core db = new Core();

        public void AddClients(string address, string passportdata, string fullname, string dlicensenumber)
        {
            Clients addClients = new Clients()
            {
                Address = address,
                PassportData = passportdata,
                FullName = fullname,
                DLicenseNumber = dlicensenumber
            };
            db.context.Clients.Add(addClients);
            db.context.SaveChanges();
        }

        public bool CheckAddClients(string CHKaddress, string CHKpassportdata, string CHKfullname, string CHKdlicensenumber)
        {
            if (String.IsNullOrEmpty(CHKaddress) && String.IsNullOrEmpty(CHKpassportdata) && String.IsNullOrEmpty(CHKfullname) && String.IsNullOrEmpty(CHKdlicensenumber))
            {
                throw new Exception("Заполните поля");
            }
            if (String.IsNullOrEmpty(CHKaddress))
            {
                throw new Exception("Адрес не указан");
            }
            if (String.IsNullOrEmpty(CHKpassportdata))
            {
                throw new Exception("Паспортные данные не указаны");
            }
            if (String.IsNullOrEmpty(CHKfullname))
            {
                throw new Exception("ФИО не указано");
            }
            if (String.IsNullOrEmpty(CHKdlicensenumber))
            {
                throw new Exception("Номер водительского удостоверения не указан");
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
