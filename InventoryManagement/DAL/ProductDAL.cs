using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL
{
    public class ProductDAL
    {
        InventoryManagementContext inventory = new InventoryManagementContext();
        public List<Product> GetAllProducts()
        {
            return inventory.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            inventory.Products.Add(product);
            inventory.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            inventory.Products.Update(product);
            inventory.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            var transactions = inventory.Transactions.Where(t => t.ProductId == product.ProductId);
            inventory.Transactions.RemoveRange(transactions);
            inventory.Products.Remove(product);
            inventory.SaveChanges();
        }


    }
}
