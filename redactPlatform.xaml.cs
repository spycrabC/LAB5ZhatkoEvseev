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
    /// Логика взаимодействия для redactPlatform.xaml
    /// </summary>
    public partial class redactPlatform : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();

        Platform _selectPlatform;
        public redactPlatform(int idPlosh)
        {
            InitializeComponent();

            cbType.ItemsSource = bd.FkTypeplatforms.ToList();

            _selectPlatform = bd.Platforms.FirstOrDefault(x => x.PkPlatform == idPlosh);

            var selectjod = bd.Jobs.FirstOrDefault(x => x.PkJob == _selectPlatform.FkTypeplatform);

            tbAdres.Text = _selectPlatform.Adres;
            tbVmestimost.Text = _selectPlatform.Vmestimost.ToString();
            tbSumarendi.Text = _selectPlatform.Sumarendi.ToString();
            cbType.SelectedValue = cbType.SelectedValue = _selectPlatform.FkTypeplatform;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var typePlatform = cbType.SelectedItem as FkTypeplatform;

            if (typePlatform == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип платформы из списка!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _selectPlatform.Adres = tbAdres.Text;
            _selectPlatform.Sumarendi = Convert.ToDouble(tbSumarendi.Text);
            _selectPlatform.Vmestimost = Convert.ToInt32(tbVmestimost.Text);

            
            _selectPlatform.FkTypeplatform = typePlatform.PkTypeplatform;

            bd.Update(_selectPlatform);
            bd.SaveChanges();

            MessageBox.Show("Данные успешно изменены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            plohadki emp = new plohadki();
            emp.Show();
            this.Close();
        }
    }
}
