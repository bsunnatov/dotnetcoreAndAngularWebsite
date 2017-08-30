
using IdealSysApp.Models.Entities;
using IdealSysApp.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
      this.Database.SetCommandTimeout(120);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AppUser>().HasOne(a => a.Storage).WithMany(p=>p.Users).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.SetNull);
      base.OnModelCreating(builder);

    }
    public override int SaveChanges()
    {
      foreach (var entry in this.ChangeTracker.Entries<BaseEntity>())
      {
        var ent = entry.Entity;
        if (entry.State == EntityState.Modified)
        {
       
          // use entry.OriginalValues
          if (ent != null)
          {
            entry.Entity.ModifiedDate = DateTime.Now;
          }
         
        }
        if (entry.State == EntityState.Added)
        {

          // use entry.OriginalValues
          if (ent != null)
          {
            entry.Entity.ModifiedDate = DateTime.Now;
            entry.Entity.CreatedDate = DateTime.Now;
           
          }

        }
      }
      return base.SaveChanges();
    }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<DynamicProperty> DynamicProperties { get; set; }
    public DbSet<DynamicPropertyValue> DynamicPropertyValues { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductProperty> ProductProperties { get; set; }

  }
}
