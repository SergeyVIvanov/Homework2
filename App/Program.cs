using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

using (DatabaseContext db = new DatabaseContextFactory().CreateDbContext())
{
    //RegisterLoggerProvider(db);

    var props = db.GetType().GetProperties();
    foreach (var prop in props)
        if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            OutTableContent(prop.Name, (prop.GetValue(db) as IQueryable)!);

    AddProduct(db);
}

static void AddProduct(DatabaseContext db)
{
    Console.WriteLine();
    Console.Write("Do you want to add a new product (Y/N): ");
    bool add = Console.ReadKey().Key == ConsoleKey.Y;
    Console.WriteLine();
    if (!add)
        return;

    Console.Write("Enter new product's name: ");
    string productName;
    while ((productName = Console.ReadLine()!.Trim()).Length == 0) ;

    Product product = new() { Name = productName };
    db.Products.Add(product);
    if (db.SaveChanges() == 1)
        Console.WriteLine("The product was successfully added.");
}

static void OutTableContent(string tableName, IQueryable table)
{
    Console.WriteLine($"Table {tableName}:");

    bool isFirstRow = true;
    foreach (var entity in table)
    {
        if (!isFirstRow)
            Console.WriteLine("    ====");

        var props = entity.GetType().GetProperties();
        foreach (var prop in props)
            if (prop.CanRead && !prop.GetMethod!.IsVirtual)
                Console.WriteLine($"    {prop.Name}: {prop.GetValue(entity)}");

        isFirstRow = false;
    }
}

#pragma warning disable CS8321 // Local function is declared but never used
static void RegisterLoggerProvider(DbContext db)
{
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
}
#pragma warning restore CS8321 // Local function is declared but never used
