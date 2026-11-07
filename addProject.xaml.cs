using LAB5ZhatkoEvseev.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LAB5ZhatkoEvseev
{
    /// <summary>
    /// Логика взаимодействия для addProject.xaml
    /// </summary>
    public partial class addProject : Window
    {
        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public addProject()
        {
            InitializeComponent();
            cbType.ItemsSource = bd.TypeProjects.ToList();
            cbGenre.ItemsSource = bd.GenreProjects.ToList();
            cbStatus.ItemsSource = bd.StatusProjects.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSName.Text))
            {
                MessageBox.Show("Заполните поле названия проекта");

                return;
            }


            string Name = tbSName.Text.Trim();

                var userLogin = bd.Projects.FirstOrDefault(x => x.NameProject == Name);

                if (userLogin != null)
                {
                    MessageBox.Show("Такой проект уже есть");
                }

            if (dpStart.SelectedDate == null || dpEnd.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните обе даты: начала и конца проекта!",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateOnly startDate = DateOnly.FromDateTime(dpStart.SelectedDate.Value);
            DateOnly endDate = DateOnly.FromDateTime(dpEnd.SelectedDate.Value);

            if (startDate > endDate)
            {
                MessageBox.Show("Ошибка: Дата начала не может быть позже даты окончания проекта!",
                                "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            else
            {
                    var Type = (TypeProject)cbType.SelectedItem;
                    var Genre = (GenreProject)cbGenre.SelectedItem;
                    var Status = (StatusProject)cbStatus.SelectedItem;
                    var newProject = new LAB5ZhatkoEvseev.Models.Project
                    {
                        NameProject = tbSName.Text,
                        FkTypeProject = Type.PkTypeProject,
                        FkGenreProject = Genre.PkGenreProject,
                        FkStatusProject = Status.PkStatusProject,
                        DateStart = startDate,
                        DateEnd = endDate
                    };

                    bd.Projects.Add(newProject);

                    bd.SaveChanges();

                    MessageBox.Show("Вы успешно добавили новый проект!");
                    Project pr = new Project();
                    pr.Show();
                    this.Close();



            }

            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Project pr = new Project();
            pr.Show();
            this.Close();
        }
    }
}
