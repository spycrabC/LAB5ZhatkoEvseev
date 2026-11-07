using LAB5ZhatkoEvseev.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace LAB5ZhatkoEvseev
{
    /// <summary>
    /// Логика взаимодействия для Employes.xaml
    /// </summary>
    public partial class Employes : Window
    {
        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public Employes()
        {
            
            InitializeComponent();
            LoadDate();
            ICollectionView view = CollectionViewSource.GetDefaultView(dgEmployees.ItemsSource);


            view.Filter = item =>
            {
                if (item is Employe emp)
                {

                    if (string.IsNullOrWhiteSpace(tbSearch.Text))
                        return true;

                    return emp.Surname.ToLower().Contains(tbSearch.Text.ToLower());
                }
                return false;
            };

        }

        private void LoadDate()
        {
            dgEmployees.ItemsSource = bd.Employes.Include(e => e.FkJobNavigation).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 form = new Window1();
            form.Show();
            this.Close();
        }

        private void Btn_del_Click(object sender, RoutedEventArgs e)
        {
            if(dgEmployees.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            var selectedEmploy = dgEmployees.SelectedItem as LAB5ZhatkoEvseev.Models.Employe; ;

            if(selectedEmploy != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить сотрудника ?", "Подтверждение", MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
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
                        MessageBox.Show("Не получилось удалить сотрудника");
                    }
                }    
            }
        }

        private void Btn_Red_Click(object sender, RoutedEventArgs e)
        {
            if(dgEmployees.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            var selectedEmploy = dgEmployees.SelectedItem as LAB5ZhatkoEvseev.Models.Employe; ;

            if (selectedEmploy != null)
            {
                int idEmploy = selectedEmploy.PkEmploye;

                RedaktEmploy red = new RedaktEmploy(idEmploy);
                red.Show();
                this.Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dgEmployees.ItemsSource);

            view?.Refresh();
        }
    }
}
