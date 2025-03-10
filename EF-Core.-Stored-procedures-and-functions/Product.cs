using System;
using System.Collections.Generic;

namespace EF_Core._Stored_procedures_and_functions;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public int Quantity { get; set; }

    public decimal Cost { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
