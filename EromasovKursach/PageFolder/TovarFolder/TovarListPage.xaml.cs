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

namespace EromasovKursach.PageFolder.TovarFolder
{
    /// <summary>
    /// Логика взаимодействия для TovarListPage.xaml
    /// </summary>
    public partial class TovarListPage : Page
    {
        public TovarListPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Tovar
                .ToList().OrderBy(u => u.TovarName);
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт товаров");
        }

        
        

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "товар для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new TovarEditPage(DgUser.SelectedItem as Tovar));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Tovar.Where(u => u.TovarName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.TovarName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}
