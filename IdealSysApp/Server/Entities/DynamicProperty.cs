using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  /// <summary>
  /// DynamicProperty
  /// </summary>
  public class DynamicProperty:BaseEntity
  {
    public DynamicProperty()
    {
      DynamicPropertyValues = new HashSet<DynamicPropertyValue>();
    }
    /// <summary>
    /// Example:Color,Brend
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// Example:Цвет,Коллекция
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// IsMultiSelect
    /// </summary>
    public bool IsMultiSelect { get; set; }
    /// <summary>
    /// DynamicPropertyValues
    /// </summary>
    public virtual ICollection<DynamicPropertyValue> DynamicPropertyValues { get; set; }
  }
}
