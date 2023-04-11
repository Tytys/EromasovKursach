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
    /// Логика взаимодействия для TovarEditPage.xaml
    /// </summary>
    public partial class TovarEditPage : Page
    {
        Tovar tovar = new Tovar();
        public TovarEditPage(Tovar tovar)
        {
            InitializeComponent();
            DataContext = tovar;

            this.tovar.TovarId = tovar.TovarId;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tovar = DBEntities.GetContext().Tovar
                    .FirstOrDefault(u => u.TovarId == tovar.TovarId);
                tovar.TovarName = NameTb.Text;
                tovar.TovarPrice = decimal.Parse(PriceTb.Text);
                tovar.TovarCount = int.Parse(CountTb.Text);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new TovarListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
