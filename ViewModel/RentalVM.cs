﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{
    /// <summary>
    /// Логика кнопок страницы RentalPage.xaml
    /// </summary>
    internal class RentalVM
    {
        Core db = new Core();

        public void AddRental(int idclient, int idcar, string cost, DateTime datestart, DateTime dateend)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 1,
                TableName = "Аренда"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

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

        public bool CheckRental(object client, object car, string cost, DateTime start, DateTime end)
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
            if (!cost.All(char.IsDigit)) 
            {
                throw new Exception("Стоимость указана некорректно");
            }            
            if (start > end) 
            {
                throw new Exception("Дата начала не может быть больше даты окончания");
            }
            else
            {
                return true;
            }
        }

        public void DeleteRent(int idRent)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 3,
                TableName = "Аренда"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Rental delRent = db.context.Rental.FirstOrDefault(x => x.IDRent == idRent);
            db.context.Rental.Remove(delRent);
            db.context.SaveChanges();
        }

        public void AddLog_Edit()
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 2,
                TableName = "Аренда"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();
        }
    }
}
