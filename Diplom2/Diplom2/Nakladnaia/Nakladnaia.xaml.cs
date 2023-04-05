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

namespace Diplom2.Nakladnaia
{
    /// <summary>
    /// Логика взаимодействия для Nakladnaia.xaml
    /// </summary>
    public partial class Nakladnaia : Page
    {
        private Накладная _currentPrakt = new Накладная();
        public Nakladnaia()
        {
            InitializeComponent();
            DataContext = _currentPrakt;
            CmbPoluch.ItemsSource = PraktikaEntities2.GetContext().КонтрАгент.ToList();
            CmbOtpravka.ItemsSource = PraktikaEntities2.GetContext().Станция.ToList();
            CmbNaznach.ItemsSource = PraktikaEntities2.GetContext().Станция2.ToList();
            CmbGruz.ItemsSource = PraktikaEntities2.GetContext().МаркаУгля.ToList();
            CmbDek.ItemsSource = PraktikaEntities2.GetContext().СправДек.ToList();
            CmbOtprav.ItemsSource = PraktikaEntities2.GetContext().Отправитель.ToList();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPrakt.Id_Накладная == 0)
                PraktikaEntities2.GetContext().Накладная.Add(_currentPrakt);
            try
            {
                PraktikaEntities2.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Menu());
        }
    }
}
