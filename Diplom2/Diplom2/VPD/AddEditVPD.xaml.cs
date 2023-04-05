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

namespace Diplom2.VPD
{
    /// <summary>
    /// Логика взаимодействия для AddEditVPD.xaml
    /// </summary>
    public partial class AddEditVPD : Window
    {
        private ВПД _currentPrakt = new ВПД();
        public AddEditVPD()
        {
            InitializeComponent();
            DataContext = _currentPrakt;
            CmbMess.ItemsSource = PraktikaEntities2.GetContext().Месяц1.ToList();
            CmbStranaa.ItemsSource = PraktikaEntities2.GetContext().Страны.ToList();
            CmbKolVTD.ItemsSource = PraktikaEntities2.GetContext().СправДек.ToList();
        }
        public AddEditVPD(ВПД впд)
        {
            InitializeComponent();
            if (впд != null)
                _currentPrakt = впд;
            DataContext = _currentPrakt;
            CmbMess.ItemsSource = PraktikaEntities2.GetContext().Месяц1.ToList();
            CmbStranaa.ItemsSource = PraktikaEntities2.GetContext().Страны.ToList();
            CmbKolVTD.ItemsSource = PraktikaEntities2.GetContext().СправДек.ToList();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPrakt.Id_ВПД == 0) PraktikaEntities2.GetContext().ВПД.Add(_currentPrakt);

            _currentPrakt.КолПоПТДзакрыто = Convert.ToString(Convert.ToInt32(TxbKolVTDD.Text) - Convert.ToInt32(TxbKollVTDD.Text));
            
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

        private void CmbKolVTD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
