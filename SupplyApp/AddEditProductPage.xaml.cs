using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        private Product _currentProduct = new Product();

        public AddEditProductPage(Product selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
                _currentProduct = selectedProduct;

            DataContext = _currentProduct;
            ComboCategory.ItemsSource = SupplyEntities.GetContext().Product_Сategory.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int kol = 0;

            if (TBProduct_Сode.Text == "") MessageBox.Show("Введите Код продукта!");
            else kol++;

            if (TBName.Text == "") MessageBox.Show("Введите Название!");
            else
            {
                TBName.Text = TBName.Text.Trim(' ');// удаление пробелов в конце при загрузке из бд 
                kol++;
            }

            if (TBSales_start_date.Text == "") MessageBox.Show("Введите Дату начала продаж!");
            else
            {
                int error = 0;
                string[] date = TBSales_start_date.Text.Split('.');

                for (int g = 0; g < date.Length; g++)
                {
                    for (int i = 0; i < date[g].Length; i++)
                    {
                        if (Convert.ToChar(date[g][i]) < 48 || 57 < Convert.ToChar(date[g][i]))// проверка символа по таблицы ASCII
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    if (Convert.ToDateTime(TBSales_start_date.Text) > DateTime.Now)// Дата должна быть <= сегодняшней даты 
                    {
                        MessageBox.Show("Некорректно введена дата начала продаж!");
                    }
                    else
                    {
                        kol++;
                    }
                }
                else
                {
                    MessageBox.Show("Некорректно введена дата начала продаж!");
                }
            }

            if (TBRecommended_Price.Text == "") MessageBox.Show("Введите Рекомендованную цену!");
            else
            {
                int error = 0;
                string[] price = TBRecommended_Price.Text.Split('.');

                for (int g = 0; g < price.Length; g++)
                {
                    for (int i = 0; i < price[g].Length; i++)
                    {
                        if (Convert.ToChar(price[g][i]) < 48 || 57 < Convert.ToChar(price[g][i]))
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    kol++;
                }
                else
                {
                    MessageBox.Show("Некорректно введена Рекомендованная цена!");
                }
            }

            if (TBDealer_Price.Text == "") MessageBox.Show("Введите Цену для дилера!");
            else
            {
                int error = 0;
                string[] price = TBDealer_Price.Text.Split('.');

                for (int g = 0; g < price.Length; g++)
                {
                    for (int i = 0; i < price[g].Length; i++)
                    {
                        if (Convert.ToChar(price[g][i]) < 48 || 57 < Convert.ToChar(price[g][i]))
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    kol++;
                }
                else
                {
                    MessageBox.Show("Некорректно введена цена для дилера!");
                }
            }

            if (TBPostpartner_Price.Text == "") MessageBox.Show("Введите Цену пост партнера!");
            else
            {
                int error = 0;
                string[] price = TBPostpartner_Price.Text.Split('.');

                for (int g = 0; g < price.Length; g++)
                {
                    for (int i = 0; i < price[g].Length; i++)
                    {
                        if (Convert.ToChar(price[g][i]) < 48 || 57 < Convert.ToChar(price[g][i]))
                        {
                            error++;
                        }
                    }
                }
                if (error == 0)
                {
                    kol++;
                }
                else
                {
                    MessageBox.Show("Некорректно введена цена для пост партнера!");
                }
            }

            if (TBRF_VAT_Rate.Text == "") MessageBox.Show("Введите Ставку НДС РФ!");
            else kol++;

            if (TBCurrency.Text == "") MessageBox.Show("Введите Валюту!");
            else kol++;

            if (ComboCategory.SelectedItem == null) MessageBox.Show("Выберите Категорию товара!");
            else kol++;
            if (kol == 9)
            {

                if (_currentProduct.Id_Product == 0)// если Id_Product = 0 добавляем новый продукт 
                {
                    SupplyEntities.GetContext().Product.Add(_currentProduct);
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