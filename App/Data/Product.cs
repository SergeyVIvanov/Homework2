namespace Data;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClientProduct> ClientProducts { get; } = new List<ClientProduct>();
}
