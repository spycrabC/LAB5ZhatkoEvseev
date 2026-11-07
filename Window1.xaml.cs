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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public Window1()
        {
            InitializeComponent();
            cbJob.ItemsSource = bd.Jobs.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            if(string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) || string.IsNullOrWhiteSpace(tbSurname.Text) ||string.IsNullOrWhiteSpace(tbSName.Text) || string.IsNullOrWhiteSpace(tbSurname.Text) || string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Заполните все поля для регистрации");

                return;
            }


            string login = tbLogin.Text.Trim();
            string password = HashPassword.Hash(tbPassword.Text.Trim());

            string patternPhone = @"^(?:\+7|8)\d{10}$";

            if(Regex.IsMatch(tbPhone.Text, patternPhone))
            {
                var userLogin = bd.Employes.FirstOrDefault(x => x.Login == login);

                if(userLogin != null)
                {
                    MessageBox.Show("Такой логин уже есть");
                }
                else
                {
                    var job = (Job)cbJob.SelectedItem;
                    var newUser = new Employe
                    {
                        Surname = tbSurname.Text,
                        Name = tbSName.Text,
                        Patronymic = tbPatronymic.Text,
                        Phone = tbPhone.Text,
                        Login = login,
                        Password = password,
                        Bid = Convert.ToDouble(tbBid.Text),
                        FkJob = job.PkJob
                    };

                    bd.Employes.Add(newUser);

                    bd.SaveChanges();

                    MessageBox.Show("Вы успешно зарегестрировались в системе!");
                    Employes form = new Employes();
                    form.Show();
                    this.Close();
                    
                    

                }

            }
            else
            {
                MessageBox.Show("Ваш номер телефона написан неверно");
                return;
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Employes form = new Employes();
            form.Show();
            this.Close();
        }

        private void cbJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
