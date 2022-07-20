using InventorySystemBravo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { 
    }

    public DbSet<BrandCatalog> BrandCatalogs { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductCategory> ProductCategory { get; set; }

    public DbSet<ProductHistory> ProductHistory { get; set; }

    public DbSet<ProductMerma> ProductMerma { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder theModelBuilder)
    {
        theModelBuilder.Entity<BrandCatalog>(aEntity =>
        {
            aEntity.HasKey(e => e.Id);
            aEntity.Property(e => e.Name).HasMaxLength(45).IsRequired();
            aEntity.Property(e => e.Status).IsRequired(); 
        });
        
        theModelBuilder.Entity<Product>(aEntity =>
        {
            aEntity.HasKey(e => e.Id);
            aEntity.Property(e => e.ProductName).HasMaxLength(45).IsRequired();
            aEntity.Property(e => e.Price).IsRequired(); 
            aEntity.Property(e => e.Quantity).IsRequired(); 
            aEntity.Property(e => e.InShelf).IsRequired(); 
            aEntity.Property(e => e.Condition);
            aEntity.Property(e => e.UnitOfMeasure).IsRequired();
            
            aEntity.HasOne(x => x.BrandCatalog)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandId);
        }); 
        
        theModelBuilder.Entity<ProductCategory>(aEntity =>
        {
            aEntity.HasKey(e => e.Id);
            aEntity.Property(e => e.Name).HasMaxLength(45).IsRequired(); 
        });
        
        theModelBuilder.Entity<ProductHistory>(aEntity =>
        {
            aEntity.HasKey(e => e.Id);
            aEntity.Property(e => e.Action).HasMaxLength(45).IsRequired();
            aEntity.HasOne(x => x.Product)
                .WithMany(x => x.ProductHistory)
                .HasForeignKey(x => x.ProductId);
        });
        
        theModelBuilder.Entity<ProductMerma>(aEntity =>
        {
            aEntity.HasKey(e => e.Id);
            aEntity.Property(e => e.Reason).HasMaxLength(80).IsRequired();
            aEntity.HasOne(x => x.Product)
                .WithOne(x => x.ProductMerma);
        });
        
        theModelBuilder.Entity<User>(aEntity =>
        {
            aEntity.HasKey(e => e.Id);
            aEntity.Property(e => e.Name).HasMaxLength(45).IsRequired(); 
            aEntity.Property(e => e.LastName).HasMaxLength(45).IsRequired(); 
            aEntity.Property(e => e.UserName).HasMaxLength(45).IsRequired();
        }); 
    }
}