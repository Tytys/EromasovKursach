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

namespace EromasovKursach.PageFolder.ZakazcchikFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazchikAddPage.xaml
    /// </summary>
    public partial class ZakazchikAddPage : Page
    {
        public ZakazchikAddPage()
        {
            InitializeComponent();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Zakazchik.Add(new Zakazchik()
                {
                    ZakazchikName = NameTb.Text,
                    ZakazchikAdress = AdresTb.Text,
                    ZakazchikRaschetniyShet = int.Parse(SchetTb.Text)
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Заказчик успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}
