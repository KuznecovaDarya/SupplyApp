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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)// обработчик для вывода данных в датагрид по привязке 
        {
            if (Visibility == Visibility.Visible)
            {
                SupplyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGProduct.ItemsSource = SupplyEntities.GetContext().Product.ToList();
            }
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductPage((sender as Button).DataContext as Product)); // подгружаем контекст продукта для изменения на страницеAddEditProductPage
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductPage(null));// переход на страницу AddEditProductPage
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)// кнопка для поиска продуктов 
        {
            string search = TxtSearch.Text;

            var Products = SupplyEntities.GetContext().Product.ToList();
            DGProduct.ItemsSource = Products.Where(c => c.Name.Contains(search));
        }
    }
}
