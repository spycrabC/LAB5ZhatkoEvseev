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
    /// Логика взаимодействия для redactGroup.xaml
    /// </summary>
    public partial class redactGroup : Window
    {
        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        private SemachnaaGroup semachnaaGroup;
        public redactGroup(SemachnaaGroup group)
        {
            InitializeComponent();
            semachnaaGroup = group;
            cbProjects.ItemsSource = bd.Projects.ToList();
            cbСотрудники.ItemsSource = bd.Employes.ToList();

            cbProjects.SelectedItem = bd.Projects.FirstOrDefault(b => b.PkProject == group.FkProject);
            cbСотрудники.SelectedItem = bd.Employes.FirstOrDefault(b => b.PkEmploye == group.FkTabnomer);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbProjects.SelectedItem is Models.Project && cbСотрудники.SelectedItem is Models.Employe)
            {

                var selectEmploye = cbСотрудники.SelectedItem as Employe;
                var selectProject = cbProjects.SelectedItem as Models.Project;

                semachnaaGroup.FkTabnomer = selectEmploye.PkEmploye;
                semachnaaGroup.FkProject = selectProject.PkProject;

                bd.Update(semachnaaGroup);
                bd.SaveChanges();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            gryppa group = new gryppa();
            this.Close();
            group.Show();
        }

        private void cbProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbСотрудники_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
