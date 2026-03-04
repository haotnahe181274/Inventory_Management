using System;

namespace InventoryManagement.Models
{
    public class TransactionDTO
    {
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
