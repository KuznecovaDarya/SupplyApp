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
    /// Логика взаимодействия для AddEditSupplierPage.xaml
    /// </summary>
    public partial class AddEditSupplierPage : Page
    {
        private Supplier _currentSupplier = new Supplier();
        public AddEditSupplierPage(Supplier selectedSupplier)
        {
            InitializeComponent();
            if (selectedSupplier != null)
                _currentSupplier = selectedSupplier;

            DataContext = _currentSupplier;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int right = 0;
            int kol = 0;
            string numbers = "0123456789";

            if (TBName.Text == "") MessageBox.Show("Введите имя поставщика!");
            else right++;

            if (TBAddress.Text == "") MessageBox.Show("Введите адрес!");
            else right++;

            if (TBPhone.Text == "") MessageBox.Show("Введите номер телефона!");
            else if ("+".CompareTo(Convert.ToString(TBPhone.Text[0])) == 0)//проверка на правильность введенного н.телефона
            {
                TBPhone.Text = TBPhone.Text.Trim(' ');
                kol = 0;
                for (int i = 1; i < TBPhone.Text.Length; i++)
                {
                    if (Convert.ToChar(TBPhone.Text[i]) >= 48 && 57 >= Convert.ToChar(TBPhone.Text[i]))
                    {
                        kol++;
                    }
                }
                if (kol != 11)
                {
                    MessageBox.Show("Некорректно введен номер телефона!");
                }
                else right++;
            }
            else
            {
                TBPhone.Text = TBPhone.Text.Trim(' ');
                if (TBPhone.Text.Length == 11)
                {
                    kol = 0;
                    for (int i = 0; i < TBPhone.Text.Length; i++)
                    {
                        if (Convert.ToChar(TBPhone.Text[i]) >= 48 && 57 >= Convert.ToChar(TBPhone.Text[i]))
                        {
                            kol++;
                        }
                    }
                    if (kol != 11)
                    {
                        MessageBox.Show("Некорректно введен номер телефона!");
                    }
                    else right++;
                }
                else MessageBox.Show("Некорректно введен номер телефона!");
            }

            kol = 0;
            if (TBFax.Text == "") MessageBox.Show("Введите факс!");
            else if ("+".CompareTo(Convert.ToString(TBFax.Text[0])) == 0)//проверка на правильность введенного н.факса
            {
                for (int i = 1; i < TBFax.Text.Length; i++)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (TBFax.Text[i] == numbers[j])
                        {
                            kol++;
                        }
                    }
                }
                if (kol != 11)
                {
                    MessageBox.Show("Некорректно введен номер факса!");
                }
                else right++;
            }
            else
            {
                for (int i = 0; i < TBFax.Text.Length; i++)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (TBFax.Text[i] == numbers[j])
                        {
                            kol++;
                        }
                    }
                }
                if (kol != 11)
                {
                    MessageBox.Show("Некорректно введен номер факса!");
                }
                else right++;
            }

            kol = 0;
            if (TBTIN.Text == "") MessageBox.Show("Введите ИНН!");
            else
            {
                for (int i = 0; i < TBTIN.Text.Length; i++)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (TBTIN.Text[i] == numbers[j])
                        {
                            kol++;
                        }
                    }
                }
                if (kol != 12)
                {
                    MessageBox.Show("Некорректно введен ИНН!");
                }
                else right++;
            }

            kol = 0;
            if (TBSa.Text == "") MessageBox.Show("Введите номер расчетного счета!");
            else
            {
                for (int i = 0; i < TBSa.Text.Length; i++)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (TBSa.Text[i] == numbers[j])
                        {
                            kol++;
                        }
                    }
                }
                if (kol != 20)
                {
                    MessageBox.Show("Некорректно введен номер расчетного счета!");
                }
                else right++;
            }
            
            if (right==6)
            {

                if (_currentSupplier.Id_Supplier == 0)
                {
                    SupplyEntities.GetContext().Supplier.Add(_currentSupplier);
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