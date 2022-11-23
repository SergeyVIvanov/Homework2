using System;
using System.Collections.Generic;

namespace Data;

public partial class ClientProduct
{
    public long ClientId { get; set; }

    public long ProductId { get; set; }

    public DateOnly DateOpen { get; set; }

    public DateOnly? DateClose { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;

    public decimal InterestRate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
