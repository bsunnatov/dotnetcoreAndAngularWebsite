
using IdealSysApp.Models.Entities;
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
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

  }
}
