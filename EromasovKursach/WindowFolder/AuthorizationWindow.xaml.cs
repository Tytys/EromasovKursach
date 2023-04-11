using EromasovKursach.ClassFolder;
using EromasovKursach.DataFolder;
using EromasovKursach.WindowFolder.AdminFolder;
using EromasovKursach.WindowFolder.TovarFolder;
using EromasovKursach.WindowFolder.ZakazchikFolder;
using EromasovKursach.WindowFolder.ZakazFolder;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }


        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DBEntities.GetContext()
                    .User.FirstOrDefault(u => u.UserName == LoginTb.Text);

                if (user == null)
                {
                    MBClass.ErrorMB("Введен не верный логин");
                    LoginTb.Focus();
                    return;
                }
                if (user.UserPassword != PasswordPB.Password)
                {
                    MBClass.ErrorMB("Введен не верный пароль");
                    PasswordPB.Focus();
                    return;
                }
                else
                {
                    switch (user.RoleId)
                    {
                        case 1:
                            new AdminWindow().Show();
                            Close();
                            break;
                        case 2:
                            new TovarWindow().Show();
                            Close();
                            break;
                        case 3:
                            new ZakazchikWindow().Show();
                            Close();
                            break;
                        case 4:
                            new ZakazWindow().Show();
                            Close();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }
    }
}
