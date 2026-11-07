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
    /// Логика взаимодействия для addplatform.xaml
    /// </summary>
    public partial class addplatform : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public addplatform()
        {
            InitializeComponent();

            cbType.ItemsSource = bd.FkTypeplatforms.ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Employes form = new Employes();
            form.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAdres.Text) || string.IsNullOrWhiteSpace(tbsumarendi.Text) || string.IsNullOrWhiteSpace(tbVmestimost.Text))
            {
                MessageBox.Show("Заполните все поля для создания площадки");

                return;
            }

            var Type = (FkTypeplatform)cbType.SelectedItem;
            var newPlatform = new Platform
            {
                Adres = tbAdres.Text,
                Vmestimost = Convert.ToInt32(tbVmestimost.Text),
                Sumarendi = Convert.ToDouble(tbsumarendi.Text),
                FkTypeplatform = Type.PkTypeplatform
            };

            bd.Platforms.Add(newPlatform);

            bd.SaveChanges();

            MessageBox.Show("Вы успешно создали площадку");
            plohadki form = new plohadki();
            form.Show();
            this.Close();
        }
    }
}
