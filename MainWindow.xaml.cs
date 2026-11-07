using LAB5ZhatkoEvseev.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB5ZhatkoEvseev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text.Trim())) { MessageBox.Show("Вы не заполнили поле логина"); return; }
            if (string.IsNullOrWhiteSpace(TbPassword.Text.Trim())){ MessageBox.Show("Вы не заполнили поле пароля"); return; }

            string login = TbLogin.Text.Trim();
            string password = HashPassword.Hash(TbPassword.Text.Trim());


            var userLogin = bd.Employes.FirstOrDefault(x => x.Login == login && x.Password == password);

            if(userLogin != null)
            {

                Cabinet cabinet = new Cabinet(userLogin);
                cabinet.Show();
                this.Hide();

                MessageBox.Show("Добро пожаловать!");

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();

            window1.Show();

            this.Close();
        }
    }
}