using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  /// <summary>
  /// Tovarlar
  /// </summary>
  public class Product : BaseEntity
  {
    public Product()
    {
      ProductProperties = new HashSet<ProductProperty>();
      ProductImages = new HashSet<ProductImage>();
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
    public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }

  }
  /// <summary>
  /// Tovar svoystvolasri
  /// </summary>
  public class ProductProperty:BaseEntity
  {
    public long DynamicPropertyId { get; set; }
    public long ProductId { get; set; }
    public long? DynamicPropertyValueId { get; set; }
    public virtual Product Product { get; set; }
    public virtual DynamicProperty DynamicProperty { get; set; }
    public virtual DynamicPropertyValue DynamicPropertyValue { get; set; }
  }
}
