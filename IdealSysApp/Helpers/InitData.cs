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
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;

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
    public static async Task SeedData(this IApplicationBuilder app)
    {
      var context = app.ApplicationServices.GetService<ApplicationDbContext>();
      // Migrate and seed the database during startup. Must be synchronous.
      //context.Database.EnsureCreated();
      context.Database.Migrate();
      // TODO: Add seed logic here
      var owner = context.Users.FirstOrDefault(p => p.UserName == "Owner");
      string[] roles = new string[] { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };
      //if (owner != null&&!owner.Roles.Any())
      //{
      //  await AssignRoles(app, owner.Email, roles);
      //}
      if (!context.Users.Any())
      {

        var roleStore = new RoleStore<IdentityRole>(context);
      
        foreach (string role in roles)
        {
        

          if (!context.Roles.Any(r => r.Name == role))
          {
           await roleStore.CreateAsync(new IdentityRole(role) {NormalizedName=role.ToUpper() });
          }
        }
        var user = new AppUser
        {
          FirstName = "Bobur",
          LastName = "Sunnatov",
          Email = "bsunnatov@gmail.com",
          NormalizedEmail = "BSUNNATOV@GMAIL.COM",
          UserName = "Owner",
          NormalizedUserName = "OWNER",
          PhoneNumber = "+998946410388",
          EmailConfirmed = true,
          PhoneNumberConfirmed = true,
          SecurityStamp = Guid.NewGuid().ToString("D")
        };
      
          var password = new PasswordHasher<AppUser>();
          var hashed = password.HashPassword(user, "secret");
          user.PasswordHash = hashed;

          var userStore = new UserStore<AppUser>(context);
          var result = userStore.CreateAsync(user);

       
       await AssignRoles(app, user.Email, roles);

       await context.SaveChangesAsync();

      }
     
    
    }
    public static async Task<IdentityResult> AssignRoles(IApplicationBuilder services, string email, string[] roles)
    {
      try
      {
        UserManager<AppUser> _userManager = services.ApplicationServices.GetService<UserManager<AppUser>>();
        AppUser user = await _userManager.FindByEmailAsync(email);
        var result = await _userManager.AddToRolesAsync(user, roles);
        return result;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
       
      }
    
     
      return null;
    }
  }
}
