using IdealSysApp.Data;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IdealSysApp.Helpers
{
  public static class DataSeeder
  {
    // TODO: Move this code when seed data is implemented in EF 7

    /// <summary>
    /// This is a workaround for missing seed data functionality in EF 7.0-rc1
    /// More info: https://github.com/aspnet/EntityFramework/issues/629
    /// </summary>
    /// <param name="app">
    /// An instance that provides the mechanisms to get instance of the database context.
    /// </param>
    public static void SeedData(this IApplicationBuilder app)
    {
      var db = app.ApplicationServices.GetService<ApplicationDbContext>();
      // TODO: Add seed logic here
      if (!db.Users.Any())
      {
        var app_admin = new AppUser() { FirstName = "Administrator", LastName = "Administratorov", UserName = "admin" };
        db.Users.Add(app_admin);

      }
      db.SaveChanges();
    }
  }
}
