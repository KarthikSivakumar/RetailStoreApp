using System;
using System.Collections.Generic;

namespace RetailStoreWeb.Models;

public partial class Product
{
    public Guid Sku { get; set; }

    public int StoreId { get; set; }

    public string ProductName { get; set; }=null!;

    public decimal Price { get; set; }

    public DateTime EffectiveStartDate { get; set; }

    public DateTime? EffectiveEndDate { get; set; }

    public bool Active { get; set; }

    public virtual Store? Store { get; set; }
}
