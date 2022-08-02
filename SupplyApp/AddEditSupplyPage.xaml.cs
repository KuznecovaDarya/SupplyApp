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

namespace SupplyApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditSupplyPage.xaml
    /// </summary>
    public partial class AddEditSupplyPage : Page
    {
        private Supply _currentSupply = new Supply();
        public AddEditSupplyPage(Supply selectedSupply)
        {
            InitializeComponent();
            if (selectedSupply != null)
                _currentSupply = selectedSupply;

            DataContext = _currentSupply;
            ComboProduct.ItemsSource = SupplyEntities.GetContext().Product.ToList();
            ComboSupplier.ItemsSource = SupplyEntities.GetContext().Supplier.ToList();
            ComboWorker.ItemsSource = SupplyEntities.GetContext().Worker.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int right = 0;
            int kol = 0;
            string numbers = "0123456789";

            if (ComboProduct.SelectedItem == null) MessageBox.Show("Выберите Товар!");
            else right++;

            if (ComboSupplier.SelectedItem == null) MessageBox.Show("Выберите Поставщика!");
            else right++;

            if (TBScope_Supply.Text == "") MessageBox.Show("Введите Объем закупки!");
            else
            {
                for (int i = 0; i < TBScope_Supply.Text.Length; i++)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (TBScope_Supply.Text[i] == numbers[j])
                        {
                            kol++;
                        }
                    }
                }
                if (kol != TBScope_Supply.Text.Length)
                {
                    MessageBox.Show("Некорректно введен Объем закупки!");
                }
                else right++;
            }
            kol = 0;

            if (TBDate_Supply.Text == "") MessageBox.Show("Введите Дату закупки!");
            else
            {
                int error = 0;
                string[] date = TBDate_Supply.Text.Split('.');

                for (int g = 0; g < date.Length; g++)
                {
                    for (int i = 0; i < date[g].Length; i++)
                    {
                        if (Convert.ToChar(date[g][i]) < 48 || 57 < Convert.ToChar(date[g][i]))
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    if (Convert.ToDateTime(TBDate_Supply.Text)>DateTime.Now)
                    {
                        MessageBox.Show("Некорректно введена дата закупки!");
                    }
                    else
                    {
                        right++;
                    }
                }
                else
                {
                    MessageBox.Show("Некорректно введена дата закупки!");
                }
            }
            kol = 0;

            if (ComboWorker.SelectedItem == null) MessageBox.Show("Выберите Сотрудника!");
            else right++;

            if (right == 5)
            {
                double price = 0;
                SupplyEntities context = new SupplyEntities();
                var product = context.Product;
                foreach (Product Product in product.Where(c => c.Name == ComboProduct.Text ))
                {
                    price = Convert.ToDouble(Product.Dealer_Price);//подсчет цены закупки
                }
                double text = Convert.ToInt32(TBScope_Supply.Text) * price;
                _currentSupply.Price_Supply = Convert.ToDecimal(text);
                TBPrice_Supply.Text = text+"";

                if (_currentSupply.Id_Supply == 0)
                {
                    SupplyEntities.GetContext().Supply.Add(_currentSupply);
                }

                try
                {
                    SupplyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}
