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
    internal class RentalVM
    {
        Core db = new Core();

        public void AddRental(int idclient, int idcar, string cost, DateTime datestart, DateTime dateend)
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
        }

        public bool CheckRental(object client, object car, string cost)
        {
            if (client == null && car == null && String.IsNullOrEmpty(cost))
            {
                throw new Exception("Заполните поля");
            }
            if (client == null)
            {
                throw new Exception("Клиент не указан");
            }
            if (car == null)
            {
                throw new Exception("Автомобиль не указан");
            }
            if (String.IsNullOrEmpty(cost))
            {
                throw new Exception("Стоимость не указана");
            }            
            if (!cost.All(char.IsDigit)) // проверяет состоит ли string из чисел
            {
                throw new Exception("Стоимость указана некорректно");
            }
            else
            {
                return true;
            }
        }

        public void DeleteRent(int idRent)
        {
            Rental delRent = db.context.Rental.FirstOrDefault(x => x.IDRent == idRent);
            db.context.Rental.Remove(delRent);
            db.context.SaveChanges();
        }

        public void EditRent(int idRent, int idclient, int idcar, string cost, DateTime datestart, DateTime dateend)
        {
            Rental editRent = db.context.Rental.FirstOrDefault(x => x.IDRent == idRent);

            editRent.IDClients = idclient;
            editRent.IDCars = idcar;
            editRent.Cost = Convert.ToDecimal(cost);
            editRent.DateStart = datestart;
            editRent.DateEnd = dateend;

            db.context.SaveChanges();
        }
    }
}
