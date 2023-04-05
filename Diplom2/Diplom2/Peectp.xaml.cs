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
using Excel = Microsoft.Office.Interop.Excel;

namespace Diplom2
{
    /// <summary>
    /// Логика взаимодействия для Peectp.xaml
    /// </summary>
    public partial class Peectp : Page
    {
        private PraktikaEntities2 _context = new PraktikaEntities2();
        public Peectp()
        {
            InitializeComponent();
            AAA.ItemsSource = PraktikaEntities2.GetContext().Реестр.ToList();


            CmbMes.SelectedValuePath = "КачествоТовара";
            CmbMes.DisplayMemberPath = "Качествоо";
            CmbMes.ItemsSource = _context.Качество.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new VPD.VPD());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Menu());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditPeectr addEditPeectr  = new AddEditPeectr(null);
            addEditPeectr.ShowDialog();
        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = PraktikaEntities2.GetContext().Реестр.ToList().Distinct();
            switch (CmbMes.SelectedIndex)
            {
                case 0:
                    n = n.Where(x => x.КачествоТовара == 1).ToList();
                    break;
                case 1:
                    n = n.Where(x => x.КачествоТовара == 2).ToList();
                    break;
                case 2:
                    n = n.Where(x => x.КачествоТовара == 3).ToList();
                    break;
                default:
                    break;
            }
            AAA.ItemsSource = n.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PraktForDel = AAA.SelectedItems.Cast<Реестр>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({PraktForDel.Count()})",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PraktikaEntities2.GetContext().Реестр.RemoveRange(PraktForDel);
                    PraktikaEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    AAA.ItemsSource = PraktikaEntities2.GetContext().Реестр.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }

            }
        }

        private void BtnObnov_Click_1(object sender, RoutedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PraktikaEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AAA.ItemsSource = PraktikaEntities2.GetContext().Реестр.ToList();


            }
        }

        private void BtnSelectService_Click(object sender, RoutedEventArgs e)
        {
            AddEditPeectr addEditPeectr = new AddEditPeectr((sender as Button).DataContext as Реестр);
            addEditPeectr.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new OtgruzkaVTD());
        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {

            var catw = PraktikaEntities2.GetContext().Реестр.Select(x => x.СоставНетто).ToList();
            var cat = PraktikaEntities2.GetContext().Реестр.Select(x => x.СоставГрузоподьемности).Distinct().ToList();            
            var Spisok = PraktikaEntities2.GetContext().Реестр.OrderBy(x => x.КачествоТовара).ToList();
            var Spisok1 = PraktikaEntities2.GetContext().Реестр.Select(x => x.СрокДоставки).ToList();
            var catw1 = PraktikaEntities2.GetContext().Реестр.Select(x => x.Дата).ToList();
            var cat1 = PraktikaEntities2.GetContext().Реестр.Select(x => x.КолПВ).Distinct().ToList();
            var cat2 = PraktikaEntities2.GetContext().Реестр.Select(x => x.КолТонн).Distinct().ToList();
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 3;
            worksheet.Cells[2][1] = "ООО 'УК'Разрез Майрыхский'";
            worksheet.Cells[1][3] = "Состав Нетто";
            worksheet.Cells[2][3] = "Состав  грузоподьемности";
            worksheet.Cells[3][3] = "Качество товара";
            worksheet.Cells[4][3] = "Срок доставки";
            worksheet.Cells[5][3] = "Дата";
            worksheet.Cells[6][3] = "Кол-ПВ";
            worksheet.Cells[7][3] = "Кол-Тонн";
            worksheet.Cells[7][7] = "М.П";
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 7]];
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            header.Interior.ColorIndex = 0;
            for (int i = 0; i < cat.Count(); i++)
            {
                RowIndex++;
                Excel.Range categ2 = worksheet.Range[worksheet.Cells[RowIndex, 1], worksheet.Cells[RowIndex, 7]];


                worksheet.Cells[1][RowIndex] = Spisok[i].СоставНетто;
                worksheet.Cells[2][RowIndex] = Spisok[i].СоставГрузоподьемности;               
                worksheet.Cells[3][RowIndex] = Spisok[i].Качество.Качествоо;
                worksheet.Cells[4][RowIndex] = Spisok[i].СрокДоставки;
                worksheet.Cells[5][RowIndex] = Spisok[i].Дата;
                worksheet.Cells[6][RowIndex] = Spisok[i].КолПВ;
                worksheet.Cells[7][RowIndex] = Spisok[i].КолТонн;
                categ2.BorderAround2();
                categ2.Borders.Value = 1;

                application.Visible = true;
            }
        }

        private void BtnOtcet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
