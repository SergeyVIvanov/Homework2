using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientProduct> ClientProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pk");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.IdDocIssueDate).HasColumnName("id_doc_issue_date");
            entity.Property(e => e.IdDocKind).HasColumnName("id_doc_kind");
            entity.Property(e => e.IdDocNumber)
                .HasMaxLength(10)
                .HasColumnName("id_doc_number");
            entity.Property(e => e.IdDocSerial)
                .HasMaxLength(10)
                .HasColumnName("id_doc_serial");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<ClientProduct>(entity =>
        {
            entity.HasKey(e => new { e.ClientId, e.ProductId }).HasName("client_product_pk");

            entity.ToTable("client_product");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("currency");
            entity.Property(e => e.DateClose).HasColumnName("date_close");
            entity.Property(e => e.DateOpen).HasColumnName("date_open");
            entity.Property(e => e.InterestRate)
                .HasColumnType("money")
                .HasColumnName("interest_rate");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientProducts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_product_fk_clients_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ClientProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("client_product_fk_products_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });
        modelBuilder.HasSequence("clients_id_seq");
        modelBuilder.HasSequence("products_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
