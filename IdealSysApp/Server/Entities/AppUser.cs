using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IdealSysApp.Models.Entities
{
  public class AppUser : IdentityUser
  {
    // Extended Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? StorageId { get; set; }
    public virtual Storage Storage { get; set; }
  }
}
