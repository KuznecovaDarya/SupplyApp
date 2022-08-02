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
using Word = Microsoft.Office.Interop.Word;

namespace SupplyApp
{
    /// <summary>
    /// Логика взаимодействия для ReportingPage.xaml
    /// </summary>
    public partial class ReportingPage : Page
    {
        public ReportingPage()
        {
            InitializeComponent();

            ComboProduct.ItemsSource = SupplyEntities.GetContext().Product.ToList();
            ComboSupplier.ItemsSource = SupplyEntities.GetContext().Supplier.ToList();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string data1 = date1.Text;
            string data2 = date2.Text;
            string Supplier = ComboSupplier.Text;
            string Product = ComboProduct.Text;

            if (data1 != "" && data2 != "" && Supplier != "" && Product != "")
            {
                MessageBox.Show("Будет составлен отчет с " + data1 + " по " + data2 + "\nПо поставщику " + Supplier + "\nПо продукту " + Product);
                var AllSupply = SupplyEntities.GetContext().Supply.Where((u) => u.Supplier.Name == Supplier && u.Product.Name == Product
                && u.Date_Supply >= date1.SelectedDate && u.Date_Supply <= date2.SelectedDate).ToList();


                var application = new Word.Application();

                Word.Document document = application.Documents.Add();
                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range range = paragraph.Range;
                range.Text = "Отчетность по закупкам";
                paragraph.set_Style("Заголовок");
                paragraph.Range.Font.Name = "Times New Roman";
                range.InsertParagraphAfter();//создаем новый параграф для таблицы


                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table supplyTable = document.Tables.Add(tableRange, AllSupply.Count() + 1, 7);//строки и столбцы
                supplyTable.Borders.InsideLineStyle = supplyTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;//значение границ внутр и внеш
                supplyTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//выравнивание по центру

                Word.Range cellRange;
                //заголовки
                cellRange = supplyTable.Cell(1, 1).Range;
                cellRange.Text = "Номер закупки";
                cellRange = supplyTable.Cell(1, 2).Range;
                cellRange.Text = "Товар";
                cellRange = supplyTable.Cell(1, 3).Range;
                cellRange.Text = "Поставщик";
                cellRange = supplyTable.Cell(1, 4).Range;
                cellRange.Text = "Сумма закупки";
                cellRange = supplyTable.Cell(1, 5).Range;
                cellRange.Text = "Объем закупки";
                cellRange = supplyTable.Cell(1, 6).Range;
                cellRange.Text = "Дата закупки";
                cellRange = supplyTable.Cell(1, 7).Range;
                cellRange.Text = "Сотрудник";
                //форматирование заголовков
                supplyTable.Rows[1].Range.Bold = 1;//жирный текст
                supplyTable.Range.Font.Name = "Times New Roman";
                supplyTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//выравнивание по центру

                Word.Paragraph sumParagraph = document.Paragraphs.Add();//новый параграф для суммы
                Word.Range sumRange = sumParagraph.Range;

                foreach (var supply in AllSupply)
                {

                    for (int i = 0; i < AllSupply.Count(); i++)
                    {
                        var currentSupply = AllSupply[i];

                        cellRange = supplyTable.Cell(i + 2, 1).Range;
                        cellRange.Text = currentSupply.Id_Supply + "";
                        cellRange = supplyTable.Cell(i + 2, 2).Range;
                        cellRange.Text = currentSupply.Product.Name + "";
                        cellRange = supplyTable.Cell(i + 2, 3).Range;
                        cellRange.Text = currentSupply.Supplier.Name + "";
                        cellRange = supplyTable.Cell(i + 2, 4).Range;
                        cellRange.Text = currentSupply.Price_Supply + "";
                        cellRange = supplyTable.Cell(i + 2, 5).Range;
                        cellRange.Text = currentSupply.Scope_Supply + "";
                        cellRange = supplyTable.Cell(i + 2, 6).Range;
                        cellRange.Text = currentSupply.Date_Supply + "";
                        cellRange = supplyTable.Cell(i + 2, 7).Range;
                        cellRange.Text = currentSupply.Worker.Login + "";
                    }
                    double sum = 0;
                    for (int i = 0; i < AllSupply.Count(); i++)
                    {
                        sum = sum + Convert.ToDouble(AllSupply[i].Price_Supply);
                    }
                    if (sum != 0)
                    {
                        sumRange.Text = $"Общая сумма закупок = {sum} руб.";
                        sumParagraph.Range.Font.Name = "Times New Roman";
                        sumRange.Font.Color = Word.WdColor.wdColorDarkRed;
                    }

                }
                
                application.Visible = true;//отображение приложения

                //document.SaveAs2(@"C:\Users\User\Desktop\Reporting.docx");
                //document.SaveAs2(@"C:\Users\User\Desktop\Reporting.pdf", Word.WdExportFormat.wdExportFormatPDF);
            }
            else MessageBox.Show("Проверьте введенные данные!");
        }
    }
}
