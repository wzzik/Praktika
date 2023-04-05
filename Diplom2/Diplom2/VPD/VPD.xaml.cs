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

namespace Diplom2.VPD
{
    /// <summary>
    /// Логика взаимодействия для VPD.xaml
    /// </summary>
    public partial class VPD : Page
    {
        private PraktikaEntities2 _context = new PraktikaEntities2();
        public VPD()
        {
            InitializeComponent();
            AAA.ItemsSource = PraktikaEntities2.GetContext().ВПД.ToList();
            CmbMes.SelectedValuePath = "Id_месяц";
            CmbMes.DisplayMemberPath = "Месяц2";
            CmbMes.ItemsSource = _context.Месяц1.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Menu());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new OtgruzkaVTD());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new VPD());
        }

        private void BtnObnov_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PraktForDel = AAA.SelectedItems.Cast<ВПД>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({PraktForDel.Count()})",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PraktikaEntities2.GetContext().ВПД.RemoveRange(PraktForDel);
                    PraktikaEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    AAA.ItemsSource = PraktikaEntities2.GetContext().ВПД.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }

            }
        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = Convert.ToInt32(CmbMes.SelectedValue);
            AAA.ItemsSource = PraktikaEntities2.GetContext().ВПД.Where(x => x.Id_Месяц3 == k).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditVPD addEditVPD = new AddEditVPD(null);
            addEditVPD.ShowDialog();
        }

        private void BtnSelectService_Click(object sender, RoutedEventArgs e)
        {
            AddEditVPD addEditVPD = new AddEditVPD((sender as Button).DataContext as ВПД);
            addEditVPD.ShowDialog();
        }

        private void BtnOtcet_Click(object sender, RoutedEventArgs e)
        {
            int k = Convert.ToInt32(CmbMes.SelectedValue);
            var Spisok = PraktikaEntities2.GetContext().ВПД.ToList();
            if (k > 0)
            {
                Spisok = PraktikaEntities2.GetContext().ВПД.Where(x => x.Id_Месяц3 == k).ToList();
            }
            else
            {
                Spisok = PraktikaEntities2.GetContext().ВПД.ToList();
            }
            //var Spisok2 = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.ОстатокПоВТД).ToList();
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 4;
            worksheet.Cells[2][1] = "ООО 'УК'Разрез Майрыхский'";
            worksheet.Cells[2][2] = "Отчет по закрытию ВТД";
            worksheet.Cells[1][4] = "Месяц";
            worksheet.Cells[2][4] = "ВТД №";
            worksheet.Cells[3][4] = "Количество тонн по ВТД";
            worksheet.Cells[4][4] = "ПТД №";
            worksheet.Cells[5][4] = "Количество тонн по ПТД";
            worksheet.Cells[6][4] = "Страна по ПТД";
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 6]];
            header.ColumnWidth = 35;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            header.Interior.ColorIndex = 0;
            for (int i = 0; i < Spisok.Count(); i++)
            {
                RowIndex++;
                Excel.Range categ2 = worksheet.Range[worksheet.Cells[RowIndex, 1], worksheet.Cells[RowIndex, 6]];


                worksheet.Cells[1][RowIndex] = Spisok[i].Месяц1.Месяц2;
                worksheet.Cells[2][RowIndex] = Spisok[i].СправДек.НомерВТД;
                worksheet.Cells[3][RowIndex] = Spisok[i].КолТоннПоВТД.КоличествоТоннПоВТД;
                worksheet.Cells[4][RowIndex] = Spisok[i].ПТДномер;
                worksheet.Cells[5][RowIndex] = Spisok[i].КолПоПТДзакрыто;
                worksheet.Cells[6][RowIndex] = Spisok[i].Страны.СтранаП;
                categ2.BorderAround2();
                categ2.Borders.Value = 1;


            }
            RowIndex += 2;
            worksheet.Cells[6][RowIndex] = "_________/Шевелев Е.Е.";
            application.Visible = true;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PraktikaEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AAA.ItemsSource = PraktikaEntities2.GetContext().ВПД.ToList();


            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Nakladnaia.NakladnaiaCtr());
        }
    }
}
