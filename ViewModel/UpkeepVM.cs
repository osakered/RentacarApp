using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{
    internal class UpkeepVM
    {
        Core db = new Core();

        public void AddUpkeep(int idcars, DateTime beginupkeepdate, DateTime endupkeepdate, string price)
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
        }

        public bool CheckUpkeep(object car, string cost)
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
            if (!cost.All(char.IsDigit)) // проверяет состоит ли string из чисел
            {
                throw new Exception("Цена введена некорректно");
            }
            else
            {
                return true;
            }
        }

        public void DeleteUpkeep(int idUpkeep)
        {
            Upkeep delUpkeep = db.context.Upkeep.FirstOrDefault(x => x.IDUpkeep == idUpkeep);
            db.context.Upkeep.Remove(delUpkeep);
            db.context.SaveChanges();
        }

        public void EditUpkeep(int idUpkeep, int idcars, DateTime beginupkeepdate, DateTime endupkeepdate, string price)
        {
            Upkeep editUpkeep = db.context.Upkeep.FirstOrDefault(x => x.IDUpkeep == idUpkeep);

            editUpkeep.IDCars = idcars,
            editUpkeep.BeginUpkeepDate = beginupkeepdate,
            editUpkeep.EndUpkeepDate = endupkeepdate,
            editUpkeep.Price = Convert.ToDecimal(price)

            db.context.SaveChanges();
        }
    }
}
