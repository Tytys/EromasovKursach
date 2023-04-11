using EromasovKursach.ClassFolder;
using EromasovKursach.DataFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EromasovKursach.PageFolder.ZakazFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazEditPage.xaml
    /// </summary>
    public partial class ZakazEditPage : Page
    {
        Zakaz zakaz = new Zakaz();
        public ZakazEditPage(Zakaz zakaz)
        {
            InitializeComponent();
            DataContext = zakaz;
            this.zakaz.ZakazId = zakaz.ZakazId;
            TovarCb.ItemsSource = DBEntities.GetContext().Tovar.ToList();
            ZakazchikCb.ItemsSource = DBEntities.GetContext().Zakazchik.ToList();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index1 = ZakazchikCb.SelectedIndex + 1;
                int index2 = TovarCb.SelectedIndex + 1;
                zakaz = DBEntities.GetContext().Zakaz
                    .FirstOrDefault(u => u.ZakazId == zakaz.ZakazId);
                zakaz.ZakazchikId = index1;
                zakaz.TovarId = index2;
                zakaz.Count = int.Parse(CountTb.Text);
                zakaz.Price = decimal.Parse(PriceTb.Text);
                zakaz.Date = DateTime.Parse(DateTb.Text);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ZakazListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
