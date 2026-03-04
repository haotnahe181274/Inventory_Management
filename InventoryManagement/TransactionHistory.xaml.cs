using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Window
    {
        public TransactionHistory()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            BLL.TransactionBLL transactionBLL = new BLL.TransactionBLL();
            dgTransactions.ItemsSource = transactionBLL.GetAllTransactions();
        }

        private void Button_CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

