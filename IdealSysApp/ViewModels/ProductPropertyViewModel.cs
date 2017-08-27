using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
  public class ProductPropertyViewModel : ViewModel
  {
    public long DynamicPropertyId { get; set; }
    public long ProductId { get; set; }
    public long? DynamicPropertyValueId { get; set; }
  }
}
