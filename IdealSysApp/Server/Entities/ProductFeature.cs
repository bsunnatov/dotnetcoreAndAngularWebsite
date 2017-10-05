using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  public class ProductFeature : BaseEntity
  {
    public long ProductId { get; set; }
    public long DynamicPropertyId { get; set; }
    public DynamicProperty DynamicProperty { get; set; }
    public Product Product { get; set; }
  }
}
