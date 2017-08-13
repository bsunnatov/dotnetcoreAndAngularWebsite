using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{

  public class Product : BaseEntity
  {
    public Product()
    {
      DynamicProperties = new HashSet<DynamicProperty>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    /// <summary>
    /// Single Image for Product
    /// </summary>
    public string ImageUrl { get; set; }
    public long ProductCategoryId { get; set; }
    public decimal Price { get; set; }
    public virtual ProductCategory ProductCategory { get; set; }
    /// <summary>
    /// Динамик характеристики товаров
    /// </summary>
    public virtual ICollection<DynamicProperty> DynamicProperties { get; set; }

  }
}
