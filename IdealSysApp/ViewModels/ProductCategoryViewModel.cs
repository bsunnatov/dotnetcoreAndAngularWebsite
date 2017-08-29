using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
  public class ProductCategoryViewModel:ViewModel
  {
    public string Name { get; set; }
    public long? ParentId { get; set; }
    public bool HasChild { get; set; }
  }
}
