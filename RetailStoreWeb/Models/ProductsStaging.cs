using System;
using System.Collections.Generic;

namespace RetailStoreWeb.Models;

public partial class ProductsStaging
{
    public Guid? Sku { get; set; }

    public int? StoreId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public DateTime? EffectiveStartDate { get; set; }

    public DateTime? EffectiveEndDate { get; set; }

    public bool? Active { get; set; }
}
