using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentacarApp.Models;

namespace RentacarApp.ViewModel
{
    public static class AuthVM
    {
        public static Core db = new Core();

        public static bool CheckAuth(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) && String.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Заполните поля");
            }

            if (String.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Не введён логин");
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Не введён пароль");
            }
            else
            {
                int checkUser = db.context.Users.Where(x => x.Username == username && x.Password == password).Count();
                if (checkUser == 0)
                {
                    throw new Exception("Пользователь не найден");
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
