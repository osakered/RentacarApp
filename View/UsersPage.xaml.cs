using RentacarApp.Models;
using RentacarApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace RentacarApp.View
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Core db = new Core();
        int idUser = 0;
        public UsersPage()
        {
            InitializeComponent();

            DataGridUsers.ItemsSource = db.context.Users.ToList(); // Обновление DataGrid
            RoleComboBox.ItemsSource = db.context.Roles.ToList();
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "IDRole"; // Подключение ComboBox'а к БД
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersVM usersVM = new UsersVM(); //подключение класса
                bool checker = usersVM.CheckUsers(UsernameTextBox.Text, PasswordTextBox.Text, RoleComboBox.SelectedValue); // проверка заполнения полей
                if (checker)
                {
                    usersVM.AddUsers(UsernameTextBox.Text, PasswordTextBox.Text, (int)RoleComboBox.SelectedValue);
                    MessageBox.Show("Данные о клиенте внесены");
                    DataGridUsers.ItemsSource = db.context.Users.ToList(); //Добавляет данные о клиентах и обновляет DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить пользователя?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedUsers = ((Users)DataGridUsers.SelectedItem).IDUsers; //Получение ID выбранного в DataGrid пользователя
                        idUser = selectedUsers;
                        UsersVM usersVM = new UsersVM(); //подключение класса
                        usersVM.DeleteUser(idUser); // вызов метода в классе
                        MessageBox.Show("Данные о пользователе удалены");
                    }
                    catch
                    {
                        throw new Exception("Ошибка при удалении данных");
                    }
                    DataGridUsers.ItemsSource = db.context.Users.ToList(); // Обновление DataGrid
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack(); // Возврат на прошлую страницу
            }
            else
            {
                MessageBox.Show("До этого не было открыто ни одной страницы");
            }
        }

        private void DataGridUsers_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var EditRow = e.Row.Item as Users;
                db.context.Entry(EditRow).State = EntityState.Modified;
                db.context.SaveChanges();
            }
        }

        //private void EditButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DataGridUsers.SelectedItem != null)
        //    {
        //        try
        //        {
        //            var selectedUser = ((Users)DataGridUsers.SelectedItem).IDUsers;
        //            idUser = selectedUser;
        //            UsersVM usersVM = new UsersVM(); //подключение класса
        //            bool checker = usersVM.CheckUsers(UsernameTextBox.Text, PasswordTextBox.Text, RoleComboBox.SelectedValue); // проверка заполнения полей
        //            if (checker)
        //            {
        //                usersVM.EditUser(idUser, UsernameTextBox.Text, PasswordTextBox.Text, (int)RoleComboBox.SelectedValue);
        //                MessageBox.Show("Данные о клиенте внесены");
        //                DataGridUsers.ItemsSource = db.context.Users.ToList(); //Добавляет данные о клиентах и обновляет DataGrid
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Данные для редактирования не выбраны");
        //    }
        //}

    }
}
