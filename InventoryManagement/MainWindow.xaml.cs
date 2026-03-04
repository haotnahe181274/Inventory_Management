using InventoryManagement.BLL;
using InventoryManagement.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManagement
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        ProductBLL productBLL = new ProductBLL();
        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product? selectedProduct = dgProducts.SelectedItem as dynamic;
            if (selectedProduct != null)
            {
                txtName.Text = selectedProduct.ProductName;
                txtPrice.Text = selectedProduct.Price.ToString();
                txtQuantity.Text = selectedProduct.Quantity.ToString();
            }
        }

        private void FillDataGrid()
        {
            dgProducts.ItemsSource = productBLL.GetAllProducts();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClearInputFields();
            FillDataGrid();
        }
        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            string productName = txtName.Text.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please enter a product name.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid non-negative quantity.");
                return;
            }

            Product newProduct = new Product
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity
            };

            productBLL.AddProduct(newProduct);
            FillDataGrid();
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

        private void Button_UpdateClick(object sender, RoutedEventArgs e)
        {
            Product? product = dgProducts.SelectedItem as Product;
            if (product != null)
            {
                string productName = txtName.Text.Trim();
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Please enter a product name.");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid positive price.");
                    return;
                }

                if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative quantity.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to update this product?", "Confirm Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    product.ProductName = productName;
                    product.Price = price;
                    product.Quantity = quantity;

                    productBLL.UpdateProduct(product);
                    FillDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private void Button_DeleteClick(object sender, RoutedEventArgs e)
        {
            Product? product = dgProducts.SelectedItem as Product;
            if (product != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        productBLL.RemoveProduct(product);
                        FillDataGrid();
                        ClearInputFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_ImportClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProducts.SelectedItem is Product p)
                {
                    int qty = int.Parse(txtQuantity.Text);
                    productBLL.ImportProduct(p, qty);
                    MessageBox.Show("Import successful.");
                    FillDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing product: {ex.Message}");
            }
        }

        private void Button_ExportClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dgProducts.SelectedItem is Product p)
                {
                    int qty = int.Parse(txtQuantity.Text);
                    productBLL.ExportProduct(p, qty);
                    MessageBox.Show("Export successful.");
                    FillDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting product: {ex.Message}");
            }
        }

        private void Button_TransactionHistoryClick(object sender, RoutedEventArgs e)
        {
            var form = new TransactionHistory()
            {
                Owner = this
            };
            form.ShowDialog();
        }
    }
}