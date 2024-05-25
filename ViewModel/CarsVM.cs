﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{
    internal class CarsVM
    {
        Core db = new Core();

        public void AddCar(string carmodel, DateTime carprodyear, string carcolor, string regnumber, int idavailability)
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
        }

        public bool CheckCar(string model, string color, string regnumber, object availability) 
        {
            if (String.IsNullOrEmpty(model) && String.IsNullOrEmpty(color) && String.IsNullOrEmpty(regnumber) && availability == null)
            {
                throw new Exception("Заполните поля");
            }            
            if (String.IsNullOrEmpty(model))
            {
                throw new Exception("Модель автомобиля не указана");
            }
            if (String.IsNullOrEmpty(color))
            {
                throw new Exception("Цвет автомобиля не указан");
            } 
            if (String.IsNullOrEmpty(regnumber))
            {
                throw new Exception("Госномер не указан");
            }            
            if (availability == null)
            {
                throw new Exception("Статус автомобиля не выбран");
            }
            else
            {
                return true;
            }
        }

        public void DeleteCar(int idCar) 
        {
            Cars delCar = db.context.Cars.FirstOrDefault(x=>x.IDCars == idCar);

            db.context.Cars.Remove(delCar);
            db.context.SaveChanges();
        }
    }
}
