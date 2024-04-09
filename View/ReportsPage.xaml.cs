using RentacarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        //    Core db = new Core();
        //    List<Tasks> arrayTasks = new List<Tasks>();
        //    List<Enrollments> arrayEnrollments = new List<Enrollments>();
        //    List<Users> arrayUsers = new List<Users>();
        //    List<Groups> arrayGroups = new List<Groups>();
        //    List<Marks> arrayMarks = new List<Marks>();
        //    List<GroupsStudents> arrayGroupsStudents = new List<GroupsStudents>();
        //    int idCurrentTask = 0;
        //    public ReportsPage(int idCourse, int idTask)
        //    {
        //        InitializeComponent();

        //        idCurrentTask = idTask;
        //        arrayEnrollments = db.context.Enrollments.Where(x => x.CourseId == idCourse).ToList();
        //        foreach (var enrollment in arrayEnrollments)
        //        {
        //            var user = db.context.Users.Where(x => x.IdUser == enrollment.UserId).ToList();
        //            arrayUsers.AddRange(user);
        //        }

        //        CurrentGroups();


        //        GroupsComboBox.ItemsSource = arrayGroups.Distinct();
        //        GroupsComboBox.DisplayMemberPath = "TitleGroup";
        //        GroupsComboBox.SelectedValuePath = "IdGroup";
        //        GroupsComboBox.SelectedIndex = 0;

        //    }

        //    public void CurrentGroups()
        //    {
        //        foreach (var item in arrayUsers)
        //        {
        //            var group = db.context.GroupsStudents.Where(x => x.UserId == item.IdUser).ToList();
        //            arrayGroupsStudents.AddRange(group);
        //        }
        //        foreach (var item in arrayGroups)
        //        {
        //            var group = db.context.Groups.Where(x => x.IdGroup == item.IdGroup).ToList();
        //            arrayGroups.AddRange(group);
        //        }
        //    }

        //    private void GroupsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {
        //        arrayMarks.Clear();
        //        var selectedGroupId = (int)GroupsComboBox.SelectedValue;
        //        var filteredGroupsStudents = arrayGroupsStudents.Where(x => x.GroupId == selectedGroupId).ToList();

        //        foreach (var item in filteredGroupsStudents)
        //        {
        //            var marks = db.context.Marks.Where(x => x.TaskId == idCurrentTask && x.UserId == item.UserId).ToList();
        //            arrayMarks.AddRange(marks);
        //        }

        //        MarksDataGrid.ItemsSource = null;
        //        MarksDataGrid.ItemsSource = arrayMarks;
        //        MarksDataGrid.Items.Refresh();
        //    }

        //    private void SaveClick(object sender, RoutedEventArgs e)
        //    {
        //        var filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Оценки.csv");

        //        using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
        //        {
        //            sw.WriteLine("ФИО студента;Оценка");

        //            foreach (var item in MarksDataGrid.Items)
        //            {
        //                var row = (Marks)item;

        //                sw.WriteLine($"{row.Users.FIO};{row.MarkValue}");
        //            }
        //            MessageBox.Show("Данные успешно сохранены, возвращение на главную страницу.");
        //            this.NavigationService.Navigate(new MainPage());
        //        }
        //    }

        //    private void MarksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {

        //    }
    }
}
