using LAB5ZhatkoEvseev.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Логика взаимодействия для RedactProject.xaml
    /// </summary>
    public partial class RedactProject : Window
    {
        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        private Models.Project prj;
        public RedactProject(Models.Project project)
        {
            
            InitializeComponent();

            prj = project;
            tbAgeRating.Text = prj.AgeRating.ToString();
            tbNameProject.Text = prj.NameProject;
            dpDateEnd.Text = prj.DateEnd.ToString();
            dpDateStart.Text = prj.DateStart.ToString();

            cbStatusProject.ItemsSource = bd.StatusProjects.ToList();
            cbTypeGenre.ItemsSource = bd.GenreProjects.ToList();
            cbTypeProject.ItemsSource = bd.TypeProjects.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var statusProject = cbStatusProject.SelectedItem as StatusProject;
            var genreProject = cbTypeGenre.SelectedItem as GenreProject;
            var typeProject = cbTypeProject.SelectedItem as TypeProject;

            prj.NameProject = tbNameProject.Text;
            prj.DateEnd = DateOnly.FromDateTime(dpDateEnd.SelectedDate.Value);
            prj.DateStart = DateOnly.FromDateTime(dpDateStart.SelectedDate.Value);
            prj.AgeRating = Convert.ToInt32(tbAgeRating.Text);
            prj.FkStatusProject = statusProject.PkStatusProject;
            prj.FkGenreProject = genreProject.PkGenreProject;
            prj.FkTypeProject = typeProject.PkTypeProject;

            bd.Projects.Update(prj);
            bd.SaveChanges();

            MessageBox.Show("Вы успешно изменили проект!");
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Project prj = new Project();
            this.Close();
            prj.Show();
        }
    }
}
