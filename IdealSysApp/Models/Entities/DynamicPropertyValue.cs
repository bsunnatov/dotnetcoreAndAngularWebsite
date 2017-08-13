using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  public class DynamicPropertyValue
  {
    public long Id { get; set; }
    /// <summary>
    /// Examle:White,Black
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// Example:Белый,Черный
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// If IsSelected Get value
    /// </summary>
    public bool IsSelected { get; set; }
    public long DynamicPropertyId { get; set; }
    public virtual DynamicProperty DynamicProperty { get; set; }
  }
}
