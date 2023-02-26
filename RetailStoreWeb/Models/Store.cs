using System;
using System.Collections.Generic;

namespace RetailStoreWeb.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; }=null!;

    public bool Active { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
