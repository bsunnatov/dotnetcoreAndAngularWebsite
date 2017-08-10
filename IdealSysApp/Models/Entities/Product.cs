using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{

  public class Product : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public long ProductCategoryId { get; set; }
    public string goodID { get; set; }
    public string GroupID { get; set; }
    public decimal Price { get; set; }
    public virtual ProductCategory ProductCategory { get; set; }

  }
}
