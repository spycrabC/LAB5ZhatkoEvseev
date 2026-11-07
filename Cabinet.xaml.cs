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
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Window
    {
        private Employe user;
        public Cabinet(Employe loginUser)
        {
           
            InitializeComponent();
            user = loginUser;
            tbName.Text = user.Name ?? "";
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            if(btnExit.Visibility == Visibility.Visible)
            {
                btnExit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnExit.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employes emp = new Employes();
            this.Close();
            emp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            plohadki plohadki = new plohadki();
            this.Close();
            plohadki.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Project prj = new Project();
            this.Close();
            prj.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gryppa group = new gryppa();
            this.Close();
            group.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Graphic graph = new Graphic();
            this.Close();
            graph.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Zatrati zat = new Zatrati();
            this.Close();
            zat.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            procat procat = new procat();
            this.Close();
            procat.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MainWindow mnw = new MainWindow();
            this.Close();
            mnw.Show();
        }
    }
}
