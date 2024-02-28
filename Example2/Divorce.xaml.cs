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
    /// Логика взаимодействия для Divorce.xaml
    /// </summary>
    public partial class Divorce : Page
    {
        public Divorce()
        {
            InitializeComponent();
            var a = MyContext.Get().Citizens.ToList();
            var list = new List<string>();
            foreach (var item in a)
            {
                list.Add(item.LastName);
            }
            First.ItemsSource = list;
            Second.ItemsSource = list;


        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var a = First.SelectedItem as string;
            var b = Second.SelectedItem as string;
            var first = MyContext.Get().Citizens.FirstOrDefault(p => p.LastName == a);
            var second = MyContext.Get().Citizens.FirstOrDefault(p => p.LastName == a);
            var fvar = MyContext.Get().Marriages.FirstOrDefault(p => p.WifePassportNumber == first.PassportNumber && p.HusbandPassportNumber == second.PassportNumber);
            var secvar = MyContext.Get().Marriages.FirstOrDefault(p => p.WifePassportNumber == second.PassportNumber && p.HusbandPassportNumber == first.PassportNumber);
            if (fvar!=null)
            {
                fvar.DivorceDate= DateTime.Today;
                MyContext.Get().SaveChanges();
            }
            if ( secvar!= null)
            {
                secvar.DivorceDate = DateTime.Today;
                MyContext.Get().SaveChanges();
            }
        }
    }
}
