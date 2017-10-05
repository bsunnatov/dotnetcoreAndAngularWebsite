using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  public class PropertyInProductCategory : BaseEntity
  {
    public long ProductCategoryId { get; set; }
    public long DynamicPropertyId { get; set; }
    public virtual ProductCategory ProductCategory { get; set; }
    public virtual DynamicProperty DynamicProperty { get; set; }
  }
}
