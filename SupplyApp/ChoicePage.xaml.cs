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
    /// Логика взаимодействия для ChoicePage.xaml
    /// </summary>
    public partial class ChoicePage : Page
    {
        public ChoicePage()
        {
            InitializeComponent();
        }

        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplierPage());// переход на страницу поставщиков 
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductPage());// переход на страницу продуктов
        }

        private void BtnReporting_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ReportingPage());// переход на страницу отчётов
        }

        private void BtnSupply_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplyPage());// переход на страницу поставок
        }
    }
}
