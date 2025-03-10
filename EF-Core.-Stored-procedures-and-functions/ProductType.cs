using System;
using System.Collections.Generic;

namespace EF_Core._Stored_procedures_and_functions;

public partial class ProductType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
