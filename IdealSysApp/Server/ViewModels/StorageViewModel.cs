using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
    public class StorageViewModel:ViewModel
    {
    public string Name { get; set; }
    /// <summary>
    /// Описание, адрес, местоположение…
    /// </summary>
    public string Description { get; set; }
  }
}
