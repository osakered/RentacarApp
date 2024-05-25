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
using RentacarApp.ViewModel;

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
            Users user = db.context.Users.FirstOrDefault(u => u.Username == username);
            try
            {
                bool checker = AuthVM.CheckAuth(username, password);
                if (checker)
                {
                    if (password.Equals(user.Password))
                    {
                        int idRole = user.IDRole;
                        switch (idRole)
                        {
                            case 1:
                                this.NavigationService.Navigate(new MainPageManager());
                                break;
                            case 2:
                                this.NavigationService.Navigate(new MainPageSysAdmin());
                                break;
                            case 3:
                                this.NavigationService.Navigate(new MainPageDirector());
                                break;
                            default:
                                MessageBox.Show("Некорректное значение роли пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
