using System;
using System.Collections.Generic;

namespace Data;

public partial class Client
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly Birthday { get; set; }

    public short IdDocKind { get; set; }

    public string? IdDocSerial { get; set; }

    public string IdDocNumber { get; set; } = null!;

    public DateOnly IdDocIssueDate { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<ClientProduct> ClientProducts { get; } = new List<ClientProduct>();
}
