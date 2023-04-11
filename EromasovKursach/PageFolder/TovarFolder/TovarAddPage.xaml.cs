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
    /// Логика взаимодействия для TovarAddPage.xaml
    /// </summary>
    public partial class TovarAddPage : Page
    {
        public TovarAddPage()
        {
            InitializeComponent();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Tovar.Add(new Tovar()
                {
                    TovarName = NameTb.Text,
                    TovarPrice = decimal.Parse(PriceTb.Text),
                    TovarCount = int.Parse(CountTb.Text)
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Товар успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}
