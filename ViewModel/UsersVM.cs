using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RentacarApp.Models;
using System.Text.RegularExpressions;

namespace RentacarApp.ViewModel
{
    /// <summary>
    /// Логика кнопок страницы UsersPage.xaml
    /// </summary>
    public class UsersVM
    {
        Core db = new Core();

        public void AddUsers(string username, string password, int idrole)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 1,
                TableName = "Пользователи"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Users addUsers = new Users()
            {
                Username = username,
                Password = password,
                IDRole = idrole
            };
            db.context.Users.Add(addUsers);
            db.context.SaveChanges();
        }

        public bool CheckUsers(string username, string password, object idrole)
        {
            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password) && idrole == null)
            {
                throw new Exception("Заполните поля");
            }
            if (String.IsNullOrEmpty(username))
            {
                throw new Exception("Логин не введен");
            }            
            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("Пароль не введен");
            }
            Regex r = new Regex(@"^[a-zA-Z0-9$@$!%*?&#^-_. +]+$");
            if (!r.IsMatch(username) || !r.IsMatch(password))
            {
                throw new Exception("Разрешено использование только латинских букв, символов и чисел");
            }
            if (idrole == null)
            {
                throw new Exception("Роль не выбрана");
            }
            else
            {
                return true;
            }
        }

        public void DeleteUser(int idUser)
        {
            Logs addLogs = new Logs()
            {
                IDUsers = Properties.Settings.Default.idUser,
                LogTime = DateTime.Now,
                ActionID = 3,
                TableName = "Пользователи"
            };
            db.context.Logs.Add(addLogs);
            db.context.SaveChanges();

            Users delUser = db.context.Users.FirstOrDefault(x => x.IDUsers == idUser);
            db.context.Users.Remove(delUser);
            db.context.SaveChanges();
        }
    }
}
