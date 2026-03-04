using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL
{
    public class TransactionBLL
    {
            DAL.TransactionDAL transactionDAL = new DAL.TransactionDAL();
            public List<TransactionDTO> GetAllTransactions()
            {
                var transactions = transactionDAL.GetAllTransactions();
                return transactions.Select(t => new TransactionDTO
                {
                    ProductName = t.Product?.ProductName,
                    Quantity = t.Quantity,
                    Price = t.Product?.Price,
                    Date = t.Date,
                    Type = t.Type == 0 ? "Import" : "Export"
                }).ToList();
            }
            public void AddTransaction(Models.Transaction transaction)
            {
                if (transaction == null) throw new ArgumentNullException(nameof(transaction));
                transactionDAL.AddTransaction(transaction);
            }
    }
}

