using RentacarApp.Models;
using RentacarApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentacarApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent(); 
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Password;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password)) //Проверка заполнения полей
            {
                Users user = db.context.Users.FirstOrDefault(u => u.Username == username);  // Поиск пользователя в БД

                if (user != null)
                {
                    if (password.Equals(user.Password)) // Сравнение введенного пароля с паролем в БД
                    {
                        int idRole = user.IDRole;
                        switch (idRole) //Открытие страницы в зависимости от роли
                        {
                            case 1:
                                this.NavigationService.Navigate(new MainPageManager()); //Страница Менеджера
                                break;
                            case 2:
                                this.NavigationService.Navigate(new MainPageSysAdmin()); //Страница Системного Администратора
                                break;
                            case 3:
                                this.NavigationService.Navigate(new MainPageDirector()); //Страница Директора
                                break;
                            default:
                                MessageBox.Show("Некорректное значение роли пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
