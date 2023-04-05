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

namespace Diplom2
{
    /// <summary>
    /// Логика взаимодействия для AddEditVTD.xaml
    /// </summary>
    public partial class AddEditVTD : Window
    {
        private Анализ_ВТД _currentPrakt = new Анализ_ВТД();
        public AddEditVTD(Анализ_ВТД анализ_ВТД)
        {
            InitializeComponent();
            if (анализ_ВТД != null)
                _currentPrakt = анализ_ВТД;
            CmbMes.ItemsSource = PraktikaEntities2.GetContext().Месяц.ToList();
            CmbKolVTD.ItemsSource = PraktikaEntities2.GetContext().СправДек.ToList();
            DataContext = _currentPrakt;
        }
        public AddEditVTD()
        {
            InitializeComponent();
            CmbMes.ItemsSource = PraktikaEntities2.GetContext().Месяц.ToList();
            CmbKolVTD.ItemsSource = PraktikaEntities2.GetContext().СправДек.ToList();
            DataContext = _currentPrakt;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPrakt.Id_Месяц == 0) PraktikaEntities2.GetContext().Анализ_ВТД.Add(_currentPrakt);

            _currentPrakt.ОстатокПоВТД = Convert.ToString(Convert.ToInt32(TxbKolKvita.Text) - Convert.ToInt32(TxbKolOtguzponak.Text));

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

        private void CmbMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
