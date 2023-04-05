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
    /// Логика взаимодействия для AddEditPeectr.xaml
    /// </summary>
    public partial class AddEditPeectr : Window
    {
        private Реестр _currentPrakt = new Реестр();
        public AddEditPeectr(Реестр реестр)
        {
            InitializeComponent();
            if (реестр != null)
                _currentPrakt = реестр;
            CmbKachestvo.ItemsSource = PraktikaEntities2.GetContext().Качество.ToList();
            DataContext = _currentPrakt;
        }
        public AddEditPeectr()
        {
            InitializeComponent();
            CmbKachestvo.ItemsSource = PraktikaEntities2.GetContext().Качество.ToList();
            DataContext = _currentPrakt;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPrakt.КачествоТовара == 0)
                PraktikaEntities2.GetContext().Реестр.Add(_currentPrakt);
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

        private void CmbKachestvo_SelectionChanged()
        {

        }
    }
}
