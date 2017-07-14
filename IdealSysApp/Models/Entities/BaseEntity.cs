using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
    public class BaseEntity
    {
    public Int64 Id
    {
      get;
      set;
    }
    public DateTime CreatedDate
    {
      get;
      set;
    }
    public DateTime ModifiedDate
    {
      get;
      set;
    }
    public string IdentityId { get; set; }
    public AppUser Identity { get; set; }
  }
}
