using System;
using System.Collections.Generic;

namespace EF_Core._Stored_procedures_and_functions;

public partial class Sale
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ManagerId { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public DateOnly DateSale { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Manager Manager { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
