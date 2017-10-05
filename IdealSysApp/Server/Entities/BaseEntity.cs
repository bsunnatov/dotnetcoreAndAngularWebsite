using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  public interface IBaseEntity
  {
    Int64 Id { get; set; }
    string IntegrationKey { get; set; }
  }
  public class BaseEntity : IBaseEntity
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
    /// <summary>
    /// remote entity ID
    /// </summary>
    public string IntegrationKey { get; set; }
  }
}
