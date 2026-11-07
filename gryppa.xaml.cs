using LAB5ZhatkoEvseev.Models;
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

namespace LAB5ZhatkoEvseev
{
    /// <summary>
    /// Логика взаимодействия для gryppa.xaml
    /// </summary>
    public partial class gryppa : Window
    {
        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public gryppa()
        {
            InitializeComponent();
            dgsemachnaaGroup.ItemsSource = bd.SemachnaaGroups.ToList();

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addGroup addgroup = new addGroup();
            this.Close();
            addgroup.Show();        
        }

        private void Btn_Red_Click(object sender, RoutedEventArgs e)
        {
            if(dgsemachnaaGroup.SelectedItem is Models.SemachnaaGroup group)
            {
                redactGroup editGroup = new redactGroup(group);
                this.Close();
                editGroup.Show();
            }
        }

        private void Btn_del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
