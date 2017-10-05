using IdealSysApp.Models.Entities;
using IdealSysApp.Server.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Server.Entities
{
  public class Customer : BaseEntity
  {
    /// <summary>
    /// Name Organization or FirstName and LastName
    /// </summary>
    public string Name { get; set; }
    public string INN { get; set; }
    public string PassportSeria { get; set; }
    public string PassportNumber { get; set; }
    public string PhoneWork { get; set; }
    public string PhoneNumber { get; set; }
    public string AddressDetails { get; set; }
    public PersonTypeEnum PersonType { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
  }
}
