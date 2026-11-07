using LAB5ZhatkoEvseev.Models;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using QRCoder.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static MaterialDesignThemes.Wpf.Theme;
using System.IO;

namespace LAB5ZhatkoEvseev
{
    /// <summary>
    /// Логика взаимодействия для Project.xaml
    /// </summary>
    public partial class Project : Window
    {

        CinimaEvseevZhatkoContext bd = new CinimaEvseevZhatkoContext();
        public Project()
        {
            InitializeComponent();
            LoadDate();

            ICollectionView view = CollectionViewSource.GetDefaultView(dgProject.ItemsSource);

            view.Filter = item =>
            {
                if (item is Models.Project project)
                {
                    if (string.IsNullOrWhiteSpace(tbSearchProject.Text))
                    {
                        return true;


                    }
                    return project.FkStatusProjectNavigation.NameProject.ToLower().Contains(tbSearchProject.Text.ToLower());



     }
                return false;
            };

        }

        private void LoadDate()
        {
            dgProject.ItemsSource = bd.Projects.Include(e => e.FkGenreProjectNavigation).ToList();
            dgProject.ItemsSource = bd.Projects.Include(e => e.FkTypeProjectNavigation).ToList();
            dgProject.ItemsSource = bd.Projects.Include(e => e.FkStatusProjectNavigation).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addProject addp = new addProject();
            this.Close();
            addp.Show();
        }

        private void Btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (dgProject.SelectedItem == null)
            {
                MessageBox.Show("Выберите проект");
                return;
            }

            var selectedProject = dgProject.SelectedItem as LAB5ZhatkoEvseev.Models.Project;

            if (selectedProject != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить проект ?", "Подтверждение", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var bd = new CinimaEvseevZhatkoContext())
                        {
                            bd.Projects.Remove(selectedProject);
                            bd.SaveChanges();
                        }

                        LoadDate();

                    }
                    catch
                    {
                        MessageBox.Show("Не получилось удалить проект");
                    }
                }
            }
        }

        private void Btn_Red_Click(object sender, RoutedEventArgs e)
        {
            if (dgProject.SelectedItem is Models.Project selectedProject)
            {
                RedactProject editpr = new RedactProject(selectedProject);
                this.Close();
                editpr.Show();
            }
            else
            {
                var selectedProject1 = dgProject.SelectedItem ;
                MessageBox.Show("Выберите проект для редактирования " + selectedProject1);
                return;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dgProject.ItemsSource);

            view?.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dgProject.SelectedItem is Models.Project)
            {

                var selectProject = dgProject.SelectedItem as Models.Project;

                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(selectProject.NameProject.ToString(), QRCodeGenerator.ECCLevel.Q))
                {

                    var qrCode = new VideoDrawing();

                   
                    var wpfQrCode = new XamlQRCode(qrCodeData);
                    DrawingImage qrDrawingImage = wpfQrCode.GetGraphic(20);


                    Window qrWindow = new Window
                    {
                        Title = "QR-код проекта",
                        Width = 400,
                        Height = 400,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                        Owner = this
                    };

                   
                    Image imageControl = new Image
                    {
                        Source = qrDrawingImage,
                        Margin = new Thickness(20)
                    };
                  
                    RenderOptions.SetBitmapScalingMode(imageControl, BitmapScalingMode.NearestNeighbor);

                    qrWindow.Content = imageControl;
                    qrWindow.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Выберите проект для того, чтобы сгенерировать qr-code");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgProject.ItemsSource == null) return;

            StringBuilder csvContent = new StringBuilder();


            foreach (var column in dgProject.Columns)
            {
                csvContent.Append(column.Header + ";");
            }
            csvContent.AppendLine();


            foreach (var item in dgProject.Items)
            {
                foreach (var column in dgProject.Columns)
                {
                    var cellContent = column.GetCellContent(item) as TextBlock;
                    string value = cellContent != null ? cellContent.Text : "";
                    csvContent.Append(value + ";");
                }
                csvContent.AppendLine();
            }


            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Export.csv");
            File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);


            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }
    }
}
