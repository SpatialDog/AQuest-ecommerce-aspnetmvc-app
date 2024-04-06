using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
    {
        
    }

    public DbSet<Product> Product { get; set; }
}