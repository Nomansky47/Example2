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
    /// Логика взаимодействия для AdmPage.xaml
    /// </summary>
    public partial class AdmPage : Page
    {
        public AdmPage()
        {
            InitializeComponent();
            var a= MyContext.Get().Citizens.ToList();
            var list=new List<string>();
            foreach (var item in a)
            {
                list.Add(item.LastName);
            }
            First.ItemsSource = list;
            Second.ItemsSource = list;
                

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var a=First.SelectedItem as string;
            var b=Second.SelectedItem as string;
            var first = MyContext.Get().Citizens.FirstOrDefault(p => p.LastName == a);
            var second = MyContext.Get().Citizens.FirstOrDefault(p => p.LastName == a);
            var marriage = new Marriages();
            marriage.MarriageDate = DateTime.Today;
            marriage.HusbandPassportNumber = first.PassportNumber.ToString();
            marriage.WifePassportNumber = second.PassportNumber.ToString();
            marriage.DivorceDate = null;
            MyContext.Get().Marriages.Add(marriage);
            MyContext.Get().SaveChanges();
        }
    }
}
