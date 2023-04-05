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


namespace Diplom2.Nakladnaia
{
    /// <summary>
    /// Логика взаимодействия для NakladnaiaCtr.xaml
    /// </summary>
    public partial class NakladnaiaCtr : Page
    {
        public NakladnaiaCtr()
        {
            InitializeComponent();
            AAA.ItemsSource = PraktikaEntities2.GetContext().Накладная.ToList();
            
            CmbMes.SelectedValuePath = "Id_КонтрАгент";
            CmbMes.DisplayMemberPath = "Наименование";
            CmbMes.ItemsSource = PraktikaEntities2.GetContext().КонтрАгент.ToList();
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
            AppFrame.frameMain.Navigate(new VPD.VPD());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NakladnaiaAddEdit nakladnaiaAddEdit = new NakladnaiaAddEdit(null);
            nakladnaiaAddEdit.ShowDialog();
        }

        private void BtnSelectService_Click(object sender, RoutedEventArgs e)
        {
            NakladnaiaAddEdit nakladnaiaAddEdit = new NakladnaiaAddEdit((sender as Button).DataContext as Накладная);
            nakladnaiaAddEdit.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PraktForDel = AAA.SelectedItems.Cast<Накладная>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({PraktForDel.Count()})",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PraktikaEntities2.GetContext().Накладная.RemoveRange(PraktForDel);
                    PraktikaEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    AAA.ItemsSource = PraktikaEntities2.GetContext().Накладная.ToList();
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
                AAA.ItemsSource = PraktikaEntities2.GetContext().Накладная.ToList();
            }
        }

        private void BtnOtcet_Click(object sender, RoutedEventArgs e)
        {
            int k = Convert.ToInt32(CmbMes.SelectedValue);
            var Spisok = PraktikaEntities2.GetContext().Накладная.ToList();
            if (k > 0)
            {
                Spisok = PraktikaEntities2.GetContext().Накладная.Where(x => x.Id_КонтрАгента == k).ToList();
            }
            else
            {
                Spisok = PraktikaEntities2.GetContext().Накладная.ToList();
            }
            //var Spisok2 = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.ОстатокПоВТД).ToList();
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 4;
            worksheet.Cells[2][1] = "ООО 'УК'Разрез Майрыхский'";
            worksheet.Cells[2][2] = "Накладная";
            worksheet.Cells[1][4] = "№ Квмианции";
            worksheet.Cells[2][4] = "Отправитель";
            worksheet.Cells[3][4] = "Контагент";
            worksheet.Cells[4][4] = "Станция отбытия";
            worksheet.Cells[5][4] = "Станция прибытия";
            worksheet.Cells[6][4] = "Марка угля";
            worksheet.Cells[7][4] = "Номер вагонов";
            worksheet.Cells[8][4] = "Упаковка";
            worksheet.Cells[9][4] = "Номер заявки";
            worksheet.Cells[10][4] = "Справка декларации";


            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 10]];
            header.ColumnWidth = 35;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            header.Interior.ColorIndex = 0;
            for (int i = 0; i < Spisok.Count(); i++)
            {
                RowIndex++;
                Excel.Range categ2 = worksheet.Range[worksheet.Cells[RowIndex, 1], worksheet.Cells[RowIndex, 10]];


                worksheet.Cells[1][RowIndex] = Spisok[i].НомерКвитанции;
                worksheet.Cells[2][RowIndex] = Spisok[i].Отправитель.Наименованиее;
                worksheet.Cells[3][RowIndex] = Spisok[i].КонтрАгент.Наименование;
                worksheet.Cells[4][RowIndex] = Spisok[i].Станция.Станцияя;
                worksheet.Cells[5][RowIndex] = Spisok[i].Станция2.Станцияяя;
                worksheet.Cells[6][RowIndex] = Spisok[i].МаркаУгля.Марка;
                worksheet.Cells[7][RowIndex] = Spisok[i].НомерВагона;
                worksheet.Cells[8][RowIndex] = Spisok[i].Упаковка;
                worksheet.Cells[9][RowIndex] = Spisok[i].НомерЗаявки;
                worksheet.Cells[10][RowIndex] = Spisok[i].СправДек.НомерВТД;

                categ2.BorderAround2();
                categ2.Borders.Value = 1;


            }
            RowIndex += 2;
            worksheet.Cells[10][RowIndex] = "_________/Шевелев Е.Е.";
            application.Visible = true;
        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = Convert.ToInt32(CmbMes.SelectedValue);
            AAA.ItemsSource = PraktikaEntities2.GetContext().Накладная.Where(x => x.Id_КонтрАгента == k).ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new NakladnaiaCtr());
        }
    }
}
