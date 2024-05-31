using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{    
     /// <summary>
     /// Логика кнопок страницы UpkeepPage.xaml
     /// </summary>
    internal class UpkeepVM
    {
        Core db = new Core();

        /// <summary>
        /// Добавление данных об обслуживании в базу данных
        /// Фиксация добавления в журнал 
        /// </summary>
        /// <param name="idcars"></param>
        /// <param name="beginupkeepdate"></param>
        /// <param name="endupkeepdate"></param>
        /// <param name="price"></param>
        public void AddUpkeep(int idcars, DateTime beginupkeepdate, DateTime endupkeepdate, string price)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 1,
                TableName = "Обслуживание"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Upkeep addUpkeep = new Upkeep()
            {
                IDCars = idcars,
                BeginUpkeepDate = beginupkeepdate,
                EndUpkeepDate = endupkeepdate,
                Price = Convert.ToDecimal(price)
            };
            db.context.Upkeep.Add(addUpkeep);
            db.context.SaveChanges();
        }

        /// <summary>
        /// Проверка полей ввода на корректные данные
        /// </summary>
        /// <param name="car"></param>
        /// <param name="cost"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool CheckUpkeep(object car, string cost, DateTime start, DateTime end)
        {
            if (car == null && String.IsNullOrEmpty(cost))
            {
                throw new Exception("Заполните поля");
            }
            if (car == null)
            {
                throw new Exception("Автомобиль не указан");
            }
            if (String.IsNullOrEmpty(cost))
            {
                throw new Exception("Цена не указана");
            }            
            if (!cost.All(char.IsDigit)) 
            {
                throw new Exception("Цена введена некорректно");
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

        /// <summary>
        /// Удаление данных об обслуживании из базы данных
        /// Фиксация удаления в журнал действий
        /// </summary>
        /// <param name="idUpkeep"></param>
        public void DeleteUpkeep(int idUpkeep)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 3,
                TableName = "Обслуживание"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Upkeep delUpkeep = db.context.Upkeep.FirstOrDefault(x => x.IDUpkeep == idUpkeep);
            db.context.Upkeep.Remove(delUpkeep);
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
                TableName = "Обслуживание"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();
        }
    }
}
