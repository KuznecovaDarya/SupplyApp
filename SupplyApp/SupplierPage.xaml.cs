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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();
        }

        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplierPage((sender as Button).DataContext as Supplier));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SupplyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGSupplier.ItemsSource = SupplyEntities.GetContext().Supplier.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplierPage(null));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TxtSearch.Text;

            var Suppliers = SupplyEntities.GetContext().Supplier.ToList();
            DGSupplier.ItemsSource = Suppliers.Where(c => c.Name.Contains(search));
        }
    }
}
