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
    /// Логика взаимодействия для SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Page
    {
        public SupplyPage()
        {
            InitializeComponent();
        }
        private void BtnSupply_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplyPage((sender as Button).DataContext as Supply));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SupplyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGSupply.ItemsSource = SupplyEntities.GetContext().Supply.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplyPage(null));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var supplyForRemoving = DGSupply.SelectedItems.Cast<Supply>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить слeдующие {supplyForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SupplyEntities.GetContext().Supply.RemoveRange(supplyForRemoving);
                    SupplyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGSupply.ItemsSource = SupplyEntities.GetContext().Supply.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = DPSearch.Text;

            var Supply = SupplyEntities.GetContext().Supply.ToList();
            DGSupply.ItemsSource = Supply.Where(c => (c.Date_Supply+"").Contains(search));
        }
    }
}
