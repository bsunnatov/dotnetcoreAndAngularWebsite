using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
  public class Select2ViewModel
  {
    public long id { get; set; }
    public string text { get; set; }
    public IList<Select2ViewModel> children { get; set; }
  }
}
