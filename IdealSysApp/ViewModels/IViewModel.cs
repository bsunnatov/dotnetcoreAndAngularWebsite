using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
    public interface IViewModel
    {
    long Id { get; set; }
    }
  public class ViewModel : IViewModel
  {
    public long Id { get; set; }
  }
}
