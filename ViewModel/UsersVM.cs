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
    internal class UsersVM
    {
        Core db = new Core();

        public void AddUsers(string username, string password, int idrole)
        {
            Users addUsers = new Users()
            {
                Username = username,
                Password = password,
                IDRole = idrole
            };
            db.context.Users.Add(addUsers);
            db.context.SaveChanges();
        }

        public bool CheckUsers(string CHKusername, string CHKpassword, object CHKidrole)
        {
            if (String.IsNullOrEmpty(CHKusername) && String.IsNullOrEmpty(CHKpassword) && CHKidrole == null)
            {
                throw new Exception("Заполните поля");
            }
            if (String.IsNullOrEmpty(CHKusername))
            {
                throw new Exception("Логин не введен");
            }            
            if (String.IsNullOrEmpty(CHKpassword))
            {
                throw new Exception("Пароль не введен");
            }
            if (CHKidrole == null)
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
            Users delUser = db.context.Users.FirstOrDefault(x => x.IDUsers == idUser);
            db.context.Users.Remove(delUser);
            db.context.SaveChanges();
        }
    }
}
