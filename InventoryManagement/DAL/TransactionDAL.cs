using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL
{
    public class TransactionDAL
    {
        public InventoryManagementContext db = new InventoryManagementContext();
        public List<Transaction> GetAllTransactions()
        {
            return db.Transactions.Include(t => t.Product).ToList();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }

    
}
