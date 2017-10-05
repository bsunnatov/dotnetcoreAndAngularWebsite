using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
  public class DynamicPropertyViewModel : ViewModel
  {
    public DynamicPropertyViewModel()
    {
      DynamicPropertyValues = new List<DynamicPropertyValueViewModel>();
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
    public IList<DynamicPropertyValueViewModel> DynamicPropertyValues { get; set; }
  }
  public class DynamicPropertyValueViewModel : ViewModel
  {
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
  }
}
