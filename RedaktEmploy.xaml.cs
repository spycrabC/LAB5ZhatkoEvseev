using LAB5ZhatkoEvseev.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для RedaktEmploy.xaml
    /// </summary>
    public partial class RedaktEmploy : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();

        private Employe _selectEmploy;
        public RedaktEmploy(int RedaktEmploy)
        {
            InitializeComponent();
            cbJob.ItemsSource = bd.Jobs.ToList();

            _selectEmploy = bd.Employes.FirstOrDefault(x => x.PkEmploye == RedaktEmploy);

            var selectjod = bd.Jobs.FirstOrDefault(x => x.PkJob == _selectEmploy.FkJob);

            tbLogin.Text = _selectEmploy.Login;
            tbPassword.Text = _selectEmploy.Password;
            tbSurname.Text = _selectEmploy.Surname;
            tbSName.Text = _selectEmploy.Name;
            tbPatronymic.Text = _selectEmploy.Patronymic;
            tbPhone.Text = _selectEmploy.Phone;
            tbBid.Text = _selectEmploy.Bid.ToString();
            cbJob.SelectedItem = _selectEmploy.FkJobNavigation.NameJob;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) || string.IsNullOrWhiteSpace(tbSurname.Text) || string.IsNullOrWhiteSpace(tbSName.Text) || string.IsNullOrWhiteSpace(tbSurname.Text) || string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Заполните все поля для регистрации");

                return;
            }


            string login = tbLogin.Text.Trim();
            string password = HashPassword.Hash(tbPassword.Text.Trim());

            string patternPhone = @"^(?:\+7|8)\d{10}$";

            if (Regex.IsMatch(tbPhone.Text, patternPhone))
            {
                var userLogin = bd.Employes.FirstOrDefault(x => x.Login == login);

                if (userLogin != null)
                {
                    MessageBox.Show("Такой логин уже есть");
                }
                else
                {

                    try
                    {
                        _selectEmploy.Login = login;

                        if (_selectEmploy.Password != tbPassword.Text)
                        {
                            _selectEmploy.Password = HashPassword.Hash(tbPassword.Text.Trim());
                        }

                        _selectEmploy.Surname = tbSurname.Text.Trim();
                        _selectEmploy.Name = tbSName.Text.Trim();
                        _selectEmploy.Patronymic = tbPatronymic.Text.Trim();
                        _selectEmploy.Phone = tbPhone.Text.Trim();
                        _selectEmploy.Bid = Convert.ToDouble(tbBid.Text);
                        _selectEmploy.FkJob = (int)cbJob.SelectedValue;

                        bd.SaveChanges();

                        MessageBox.Show("Вы успешно зарегестрировались в системе!");
                        Employes emp = new Employes();
                        emp.Show();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, не получилось сохранить изменение");
                    }

                }

            }
            else
            {
                MessageBox.Show("Ваш номер телефона написан неверно");
                return;
            }

            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Employes emp = new Employes();
            emp.Show();
            this.Close();
        }
    }
}
