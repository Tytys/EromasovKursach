using EromasovKursach.ClassFolder;
using EromasovKursach.PageFolder.AdminFolder;
using EromasovKursach.PageFolder.ZakazcchikFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EromasovKursach.WindowFolder.ZakazchikFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazchikWindow.xaml
    /// </summary>
    public partial class ZakazchikWindow : Window
    {
        public ZakazchikWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ZakazchikListPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazchikListPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazchikAddPage());
        }
    }
}
