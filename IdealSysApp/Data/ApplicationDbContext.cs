
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
    }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<SiteLink> SiteLinks { get; set; }
  }
}
