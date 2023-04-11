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
using System.Windows.Shapes;

namespace EromasovKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }



        private void RegistrationBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().User.Add(new User()
                {
                    UserName = LoginTb.Text,
                    UserPassword = PasswordPB.Password,
                    RoleId = 2
                });
                DBEntities.GetContext().SaveChanges();

                MBClass.InfoMB("Вы успешно зарегистрировались");
                new AuthorizationWindow().Show();
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }
    }
}
