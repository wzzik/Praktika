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
    /// Логика взаимодействия для OtgruzkaVTD.xaml
    /// </summary>
    public partial class OtgruzkaVTD : Page
    {

        private PraktikaEntities2 _context = new PraktikaEntities2();
        public OtgruzkaVTD()
        {
            InitializeComponent();
            AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();

            CmbMes.SelectedValuePath = "Id";
            CmbMes.DisplayMemberPath = "Месяцц";
            CmbMes.ItemsSource = PraktikaEntities2.GetContext().Месяц.ToList();

        }

        private void BtnObnov_Click_1(object sender, RoutedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PraktikaEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Menu());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new OtgruzkaVTD());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditVTD addEditVTD = new AddEditVTD(null);
            addEditVTD.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PraktForDel = AAA.SelectedItems.Cast<Анализ_ВТД>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({PraktForDel.Count()})",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PraktikaEntities2.GetContext().Анализ_ВТД.RemoveRange(PraktForDel);
                    PraktikaEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }

            }
        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = Convert.ToInt32(CmbMes.SelectedValue);
            AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.Where(x => x.Id_Месяц == k).ToList();
            //Месяц Месяц = _context.Месяц.FirstOrDefault(x => x.Id == k);
            //var n = PraktikaEntities2.GetContext().Анализ_ВТД.ToList().Distinct();
            //switch (CmbMes.SelectedIndex)
            //{
            //    case 0:
            //        n = n.Where(x => x.Id_Месяц == 1).ToList();
            //        break;
            //    case 1:
            //        n = n.Where(x => x.Id_Месяц == 2).ToList();
            //        break;
            //    case 2:
            //        n = n.Where(x => x.Id_Месяц == 3).ToList();
            //        break;
            //    case 3:
            //        n = n.Where(x => x.Id_Месяц == 4).ToList();
            //        break;
            //    case 4:
            //        n = n.Where(x => x.Id_Месяц == 5).ToList();
            //        break;
            //    case 5:
            //        n = n.Where(x => x.Id_Месяц == 6).ToList();
            //        break;
            //    case 6:
            //        n = n.Where(x => x.Id_Месяц == 7).ToList();
            //        break;
            //    case 7:
            //        n = n.Where(x => x.Id_Месяц == 8).ToList();
            //        break;
            //    case 8:
            //        n = n.Where(x => x.Id_Месяц == 9).ToList();
            //        break;
            //    case 9:
            //        n = n.Where(x => x.Id_Месяц == 10).ToList();
            //        break;
            //    case 10:
            //        n = n.Where(x => x.Id_Месяц == 11).ToList();
            //        break;
            //    case 11:
            //        n = n.Where(x => x.Id_Месяц == 12).ToList();
            //        break;
            //    default:
            //        break;
            //}
            //AAA.ItemsSource = n.ToList();
        }

        private void BtnSelectService_Click(object sender, RoutedEventArgs e)
        {
            AddEditVTD addEditVTD = new AddEditVTD((sender as Button).DataContext as Анализ_ВТД);
            addEditVTD.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new VPD.VPD());
        }


        private void BtnOtcet_Click(object sender, RoutedEventArgs e)
        {
            //var catw = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.Месяц).ToList();
            //var cat = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.ВТДномер).ToList();
            //var Spisok1 = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.Количество_тонн_по_ВТД).ToList();
            int k = Convert.ToInt32(CmbMes.SelectedValue);
            var Spisok = PraktikaEntities2.GetContext().Анализ_ВТД.ToList(); 
            if (k > 0)
            {
                 Spisok = PraktikaEntities2.GetContext().Анализ_ВТД.Where(x => x.Id_Месяц == k).ToList();
            }
            else
            {
                 Spisok = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
            }
            //var Spisok2 = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.ОстатокПоВТД).ToList();
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 4;
            worksheet.Cells[2][1] = "ООО 'УК'Разрез Майрыхский'";
            worksheet.Cells[2][2] = "Отчет по остаткам ВТД";
            worksheet.Cells[1][4] = "Месяц";
            worksheet.Cells[2][4] = "ВТД №";
            worksheet.Cells[3][4] = "Количество тонн по ВТД";
            worksheet.Cells[4][4] = "Количество тонн отгружено по накладной";
            worksheet.Cells[5][4] = "Остаток по ВТД";
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
            header.ColumnWidth = 35;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            header.Interior.ColorIndex = 0;
            for (int i = 0; i < Spisok.Count(); i++)
            {
                RowIndex++;
                Excel.Range categ2 = worksheet.Range[worksheet.Cells[RowIndex, 1], worksheet.Cells[RowIndex, 5]];


                worksheet.Cells[1][RowIndex] = Spisok[i].Месяц.Месяцц;
                worksheet.Cells[2][RowIndex] = Spisok[i].СправДек.НомерВТД;
                worksheet.Cells[3][RowIndex] = Spisok[i].КолТоннПоВТД.КоличествоТоннПоВТД;
                worksheet.Cells[4][RowIndex] = Spisok[i].КоличествоТоннОтгруженоПоНакладной.КолТоннПоНакладной;
                worksheet.Cells[5][RowIndex] = Spisok[i].ОстатокПоВТД;
                categ2.BorderAround2();
                categ2.Borders.Value = 1;

                
            }
            RowIndex +=2;
            worksheet.Cells[5][RowIndex] = "_________/Шевелев Е.Е.";
            application.Visible = true;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PraktikaEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();


            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Nakladnaia.NakladnaiaCtr());
        }

        //private void TxtB_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var cur = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
        //    if (TxtB.Text != "")
        //    {
        //        AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.Where(z => z.Количество_отгружено_по_квитанции.ToLower().Contains(TxtB.Text.ToLower())).ToList();
        //    }
        //    else
        //    {
        //        AAA.ItemsSource = PraktikaEntities2.GetContext().Анализ_ВТД.ToList();
        //    }
        //}
    }
}

