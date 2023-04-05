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

namespace Diplom2.Deklaracia
{
    /// <summary>
    /// Логика взаимодействия для Deklaricia.xaml
    /// </summary>
    public partial class Deklaricia : Page
    {
        private PraktikaEntities2 _context = new PraktikaEntities2();
        public Deklaricia()
        {
            InitializeComponent();
            AAA.ItemsSource = PraktikaEntities2.GetContext().Декларация.ToList();

            CmbMes.SelectedValuePath = "Странаа";
            CmbMes.DisplayMemberPath = "НазваниеСтраны";
            CmbMes.ItemsSource = _context.Страна.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Menu());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new VPD.VPD());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new OtgruzkaVTD());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditDeklaracia addEditPeectr = new AddEditDeklaracia(null);
            addEditPeectr.ShowDialog();
        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = PraktikaEntities2.GetContext().Декларация.ToList().Distinct();
            switch (CmbMes.SelectedIndex)
            {
                case 0:
                    n = n.Where(x => x.Странаа == 1).ToList();
                    break;
                case 1:
                    n = n.Where(x => x.Странаа == 2).ToList();
                    break;
                case 2:
                    n = n.Where(x => x.Странаа == 3).ToList();
                    break;
                default:
                    break;
            }
            AAA.ItemsSource = n.ToList();
        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PraktForDel = AAA.SelectedItems.Cast<Декларация>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({PraktForDel.Count()})",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PraktikaEntities2.GetContext().Декларация.RemoveRange(PraktForDel);
                    PraktikaEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    AAA.ItemsSource = PraktikaEntities2.GetContext().Декларация.ToList();
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
                AAA.ItemsSource = PraktikaEntities2.GetContext().Декларация.ToList();
            }
        }

        private void BtnSelectService_Click(object sender, RoutedEventArgs e)
        {
            AddEditDeklaracia addEditPeectr = new AddEditDeklaracia((sender as Button).DataContext as Декларация);
            addEditPeectr.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Peectp());
        }

        private void BtnOtcet_Click(object sender, RoutedEventArgs e)
        {
            var catw = PraktikaEntities2.GetContext().Декларация.Select(x => x.Id_Декларация).ToList();
            var cat = PraktikaEntities2.GetContext().Декларация.Select(x => x.Страна).ToList();
            var Spisok = PraktikaEntities2.GetContext().Декларация.Select(x => x.Грузополучатель).ToList();
            //var Spisok1 = PraktikaEntities2.GetContext().Декларация.Select(x => x.ВПД).ToList();
            //var catw1 = PraktikaEntities2.GetContext().Декларация.Select(x => x.Анализ_ВТД).ToList();
            var cat1 = PraktikaEntities2.GetContext().Декларация.Select(x => x.Отчет_по_складам).ToList();
            var cat2 = PraktikaEntities2.GetContext().Декларация.Select(x => x.Контакт_номер).ToList();
            var cat3 = PraktikaEntities2.GetContext().Декларация.OrderBy(x => x.Контакт_дата).ToList();
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 3;
            worksheet.Cells[4][1] = "ООО 'УК'Разрез Майрыхский'";
            worksheet.Cells[1][3] = "№п/п";
            worksheet.Cells[2][3] = "ВТД";
            worksheet.Cells[3][3] = "Контракт №";
            worksheet.Cells[4][3] = "Контракт дата";
            worksheet.Cells[5][3] = "Страна";
            worksheet.Cells[6][3] = "Грузополучатель";
            worksheet.Cells[7][3] = "ПТД";
            worksheet.Cells[8][3] = "Тонн отгруженно";
            worksheet.Cells[8][9] = "М.П";
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[3, 9]];
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            header.Interior.ColorIndex = 0;
            for (int i = 0; i < cat.Count(); i++)
            {
                RowIndex++;
                Excel.Range categ2 = worksheet.Range[worksheet.Cells[RowIndex, 1], worksheet.Cells[RowIndex, 8]];


                worksheet.Cells[1][RowIndex] = cat3[i].Id_Декларация;
                worksheet.Cells[5][RowIndex] = cat3[i].Страна.НазваниеСтраны;
                worksheet.Cells[6][RowIndex] = cat3[i].Грузополучатель.Грузополучатеель;
                //worksheet.Cells[7][RowIndex] = cat3[i].ВПД.МаркаУгля;
                //worksheet.Cells[2][RowIndex] = cat3[i].Анализ_ВТД.Количество_по_ВТД;
                //worksheet.Cells[8][RowIndex] = cat3[i].Анализ_ВТД.Количество_отгружено_по_квитанции;
                worksheet.Cells[3][RowIndex] = cat3[i].Контакт_номер;
                worksheet.Cells[4][RowIndex] = cat3[i].Контакт_дата;
                categ2.BorderAround2();
                categ2.Borders.Value = 1;

                application.Visible = true;
            }
        }
    }
}
