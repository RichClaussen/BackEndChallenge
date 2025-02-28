using Microsoft.EntityFrameworkCore;

public class CrmDataContext : DbContext
{
    public CrmDataContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}
