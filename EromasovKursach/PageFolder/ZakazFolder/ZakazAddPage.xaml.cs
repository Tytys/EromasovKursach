using EromasovKursach.ClassFolder;
using EromasovKursach.DataFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EromasovKursach.PageFolder.ZakazFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazAddPage.xaml
    /// </summary>
    public partial class ZakazAddPage : Page
    {
        public ZakazAddPage()
        {
            InitializeComponent();
            TovarCb.ItemsSource = DBEntities.GetContext().Tovar.ToList();
            ZakazchikCb.ItemsSource = DBEntities.GetContext().Zakazchik.ToList();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index1 = ZakazchikCb.SelectedIndex + 1;
                int index2 = TovarCb.SelectedIndex + 1;
                DBEntities.GetContext().Zakaz.Add(new Zakaz()
                {
                    ZakazchikId = index1,
                    TovarId = index2,
                    Count = int.Parse(CountTb.Text),
                    Price= int.Parse(PriceTb.Text),
                    Date = DateTime.Parse(DateTb.Text)
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Заказ успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZakazListPage());
        }
    }
}
