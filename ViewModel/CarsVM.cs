﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RentacarApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RentacarApp.ViewModel
{
    /// <summary>
    /// Логика кнопок страницы CarsPage.xaml
    /// </summary>
    public class CarsVM
    {
        Core db = new Core();

        /// <summary>
        /// Добавление автомобиля в базу данных
        /// Фиксация добавления в журнал действий
        /// </summary>
        /// <param name="carmodel">Модель авто</param>
        /// <param name="carprodyear">Дата выпуска авто</param>
        /// <param name="carcolor">Цвет авто</param>
        /// <param name="regnumber">Госномер авто</param>
        /// <param name="idavailability">Идентификатор доступности</param>
        public void AddCar(string carmodel, DateTime carprodyear, string carcolor, string regnumber, int idavailability)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 1,
                TableName = "Автомобили"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

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

        /// <summary>
        /// Проверка полей ввода на корректные данные
        /// </summary>
        /// <param name="model">Модель</param>
        /// <param name="color">Цвет</param>
        /// <param name="regnumber">Госномер</param>
        /// <param name="availability">Доступность</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
            Regex r = new Regex(@"^[АВЕКМНОРСТУХ][0-9]{3}[АВЕКМНОРСТУХ]{2}[-][0-9]{2,3}$");
            if (!r.IsMatch(regnumber))
            {
                throw new Exception("Госномер указан неправильно");
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

        /// <summary>
        /// Удаление автомобиля из базы данных
        /// Фиксация удаления в журнал действий
        /// </summary>
        /// <param name="idCar">Идентификатор авто</param>
        public void DeleteCar(int idCar) 
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 3,
                TableName = "Автомобили"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Cars delCar = db.context.Cars.FirstOrDefault(x=>x.IDCars == idCar);

            db.context.Cars.Remove(delCar);
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
                TableName = "Автомобили"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();
        }
    }
}
