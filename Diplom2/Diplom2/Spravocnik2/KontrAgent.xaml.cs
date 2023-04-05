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

namespace Diplom2.Spravocnik2
{
    /// <summary>
    /// Логика взаимодействия для KontrAgent.xaml
    /// </summary>
    public partial class KontrAgent : Page
    {
        public KontrAgent()
        {
            InitializeComponent();
            AAA.ItemsSource = PraktikaEntities2.GetContext().КонтрАгент.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Menu());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.MarkaUgla());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.Sklad());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.SpravDek());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.SpravVTD());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.Stancia());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.Strana());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.KontrAgent());
        }

        private void TxtPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            var cur = PraktikaEntities2.GetContext().КонтрАгент.ToList();
            if (TxtPoisk.Text != "")
            {
                AAA.ItemsSource = PraktikaEntities2.GetContext().КонтрАгент.Where(z => z.Наименование.ToLower().Contains(TxtPoisk.Text.ToLower())).ToList();
            }
            else
            {
                AAA.ItemsSource = PraktikaEntities2.GetContext().КонтрАгент.ToList();
            }
        }
    }
}
