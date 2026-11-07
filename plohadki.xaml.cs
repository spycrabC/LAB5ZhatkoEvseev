using LAB5ZhatkoEvseev.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для plohadki.xaml
    /// </summary>
    public partial class plohadki : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public plohadki()
        {
            InitializeComponent();
            LoadDate();
        }
        private void LoadDate()
        {
            dgPloshadka.ItemsSource = bd.Platforms.Include(e => e.FkTypeplatformNavigation).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addplatform form = new addplatform();
            form.Show();
            this.Close();
        }

        private void Btn_Red_Click(object sender, RoutedEventArgs e)
        {
            if (dgPloshadka.SelectedItem == null)
            {
                MessageBox.Show("Выберите площадку");
                return;
            }

            var selectedPlosh = dgPloshadka.SelectedItem as LAB5ZhatkoEvseev.Models.Platform; ;

            if (selectedPlosh != null)
            {
                int idPlosh = selectedPlosh.PkPlatform;

                redactPlatform red = new redactPlatform(idPlosh);
                red.Show();
                this.Close();
            }
        }

        private void Btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (dgPloshadka.SelectedItem == null)
            {
                MessageBox.Show("Выберите плозадку");
                return;
            }

            var selectedEmploy = dgPloshadka.SelectedItem as LAB5ZhatkoEvseev.Models.Employe; ;

            if (selectedEmploy != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить площадку ?", "Подтверждение", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var bd = new CinimaEvseevZhatkoContext())
                        {
                            bd.Employes.Remove(selectedEmploy);
                            bd.SaveChanges();
                        }

                        LoadDate();



                    }
                    catch
                    {
                        MessageBox.Show("Не получилось удалить площадку");
                    }
                }
            }
        }
    }
}
