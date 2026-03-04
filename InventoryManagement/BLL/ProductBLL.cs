using InventoryManagement.DAL;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL
{
    public class ProductBLL
    {
        ProductDAL proDAl = new ProductDAL();
        TransactionDAL TransactionDAL = new TransactionDAL();
        public List<Product> GetAllProducts()
        {
            return proDAl.GetAllProducts();
        }
        public void AddProduct(Product product)
        {
            proDAl.AddProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            proDAl.DeleteProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            proDAl.UpdateProduct(product);
        }

        public void ImportProduct(Product product, int quantity)
        {
            if(product == null) throw new ArgumentNullException(nameof(product));
            if(quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            product.Quantity += quantity;
            proDAl.UpdateProduct(product);
            TransactionDAL.AddTransaction(new Transaction
            {
                ProductId = product.ProductId,
                Quantity = quantity,
                Type = 0,
                Date = DateTime.Now
            });

        }

        public void ExportProduct(Product product, int quantity)
        {
            if(product == null) throw new ArgumentNullException(nameof(product));
            if(quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            if(product.Quantity < quantity) throw new InvalidOperationException("Not enough stock to export the requested quantity.");
            product.Quantity -= quantity;
            proDAl.UpdateProduct(product);
            TransactionDAL.AddTransaction(new Transaction
            {
                ProductId = product.ProductId,
                Quantity = quantity,
                Type = 1,
                Date = DateTime.Now
            });
        }
    }
}
