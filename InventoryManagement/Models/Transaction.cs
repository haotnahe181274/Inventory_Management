using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? ProductId { get; set; }

    public int? Type { get; set; }

    public int? Quantity { get; set; }

    public DateTime? Date { get; set; }

    public virtual Product? Product { get; set; }
}
