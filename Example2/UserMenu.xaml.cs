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
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Page
    {
        public UserMenu(bool isAdmin)
        {
            InitializeComponent();
           if(isAdmin) AdmButton.Visibility = Visibility.Visible;
        }

        private void GoToSitizens(object sender, RoutedEventArgs e)
        {
            UserData.MyFrame.Navigate(new Citizenss());
        }

        private void GoToAdmPage(object sender, RoutedEventArgs e)
        {
            UserData.MyFrame.Navigate(new AdmPage());
        }
    }
}
