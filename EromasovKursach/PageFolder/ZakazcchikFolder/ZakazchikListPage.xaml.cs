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
    /// Логика взаимодействия для ZakazchikListPage.xaml
    /// </summary>
    public partial class ZakazchikListPage : Page
    {
        public ZakazchikListPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Zakazchik
                .ToList().OrderBy(u => u.ZakazchikName);
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт заказчиков");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Zakazchik zakazchik = DgUser.SelectedItem as Zakazchik;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите заказчика" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"заказачика с названием " +
                    $"{zakazchik.ZakazchikName}?"))
                {
                    DBEntities.GetContext().Zakazchik
                        .Remove(DgUser.SelectedItem as Zakazchik);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("закзачик удален");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Zakazchik.ToList().OrderBy(u => u.ZakazchikName);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "Заказчика для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new ZakazchikEditPage(DgUser.SelectedItem as Zakazchik));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext() 
                .Zakazchik.Where(u => u.ZakazchikName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.ZakazchikName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}
