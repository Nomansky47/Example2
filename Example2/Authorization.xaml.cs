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

namespace Example2
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            var users = MyContext.Get().UserAccounts.ToList();
            if (!string.IsNullOrWhiteSpace(Login.Text) && !string.IsNullOrWhiteSpace(Password.Text))
            {
                var user = users.FirstOrDefault(p => p.UserName == Login.Text && p.Password == Password.Text);


                if (user != null)
                {
                    if (user.IsAdmin != true)
                        UserData.MyFrame.Navigate(new UserMenu(false));
                    else UserData.MyFrame.Navigate(new UserMenu(true));
                }
            }
        }
    }
}
