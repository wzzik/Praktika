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

namespace Diplom2
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new OtgruzkaVTD());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Spravocnik2.KontrAgent());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Peectp());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new VPD.VPD());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Deklaracia.Deklaricia());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Nakladnaia.NakladnaiaCtr());
        }
    }
}
