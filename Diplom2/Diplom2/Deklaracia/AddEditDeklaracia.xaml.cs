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

namespace Diplom2.Deklaracia
{
    /// <summary>
    /// Логика взаимодействия для AddEditDeklaracia.xaml
    /// </summary>
    public partial class AddEditDeklaracia : Window
    {
        private Декларация _currentPrakt = new Декларация();
        public AddEditDeklaracia()
        {
            InitializeComponent();
            CmbPeectr.ItemsSource = PraktikaEntities2.GetContext().Реестр.ToList();
            CmbStrana.ItemsSource = PraktikaEntities2.GetContext().Страна.ToList();
            CmbGruzopoluch.ItemsSource = PraktikaEntities2.GetContext().Грузополучатель.ToList();
            CmbVPD.ItemsSource = PraktikaEntities2.GetContext().ВПД.ToList();
            CmbVTD.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
            CmbOtchetSklad.ItemsSource = PraktikaEntities2.GetContext().Отчет_по_складам.ToList();
            DataContext = _currentPrakt;
        }

        public AddEditDeklaracia(Декларация декларация)
        {
            InitializeComponent();
            if (декларация != null)
                _currentPrakt = декларация;
            CmbPeectr.ItemsSource = PraktikaEntities2.GetContext().Реестр.ToList();
            CmbStrana.ItemsSource = PraktikaEntities2.GetContext().Страна.ToList();
            CmbGruzopoluch.ItemsSource = PraktikaEntities2.GetContext().Грузополучатель.ToList();
            CmbVPD.ItemsSource = PraktikaEntities2.GetContext().ВПД.ToList();
            CmbVTD.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
            CmbOtchetSklad.ItemsSource = PraktikaEntities2.GetContext().Отчет_по_складам.ToList();
            DataContext = _currentPrakt;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPrakt.Id_Декларация == 0)
                PraktikaEntities2.GetContext().Декларация.Add(_currentPrakt);
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
    }
}
