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
    /// Логика взаимодействия для ZakazchikEditPage.xaml
    /// </summary>
    public partial class ZakazchikEditPage : Page
    {
        Zakazchik zakazchik = new Zakazchik();
        public ZakazchikEditPage(Zakazchik zakazchik)
        {
            InitializeComponent();
            DataContext = zakazchik;

            this.zakazchik.ZakazchikId = zakazchik.ZakazchikId;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                zakazchik = DBEntities.GetContext().Zakazchik
                    .FirstOrDefault(u => u.ZakazchikId == zakazchik.ZakazchikId);
                zakazchik.ZakazchikName = NameTb.Text;
                zakazchik.ZakazchikAdress = AdresTb.Text;
                zakazchik.ZakazchikRaschetniyShet = int.Parse(SchetTb.Text);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ZakazchikListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
