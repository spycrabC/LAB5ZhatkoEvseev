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
    /// Логика взаимодействия для addGroup.xaml
    /// </summary>
    public partial class addGroup : Window
    {
        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public addGroup()
        {
            InitializeComponent();

            cbProjects.ItemsSource = bd.Projects.ToList();
            cbСотрудники.ItemsSource = bd.Employes.ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            gryppa group = new gryppa();
            this.Close();
            group.Show();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cbProjects.SelectedItem is Models.Project && cbСотрудники.SelectedItem is Models.Employe)
            {
                var newGroup = new SemachnaaGroup();

                var selectEmploye = cbСотрудники.SelectedItem as Employe;
                var selectProject = cbProjects.SelectedItem as Models.Project;

                newGroup.FkTabnomer = selectEmploye.PkEmploye;
                newGroup.FkProject = selectProject.PkProject;

                bd.SemachnaaGroups.Add(newGroup);
                bd.SaveChanges();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }
        }
    }
}
