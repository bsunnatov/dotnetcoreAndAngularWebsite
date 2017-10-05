using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  public class ProductCategory : BaseEntity
  {
    public ProductCategory()
    {
      Childs = new HashSet<ProductCategory>();
      PropertyInProductCategories = new HashSet<PropertyInProductCategory>();
    }
    public string Name { get; set; }
    public long? ParentId { get; set; }
    public virtual ProductCategory Parent { get; set; }
    public ICollection<ProductCategory> Childs { get; set; }
    public ICollection<PropertyInProductCategory> PropertyInProductCategories { get; set; }
  }
}
