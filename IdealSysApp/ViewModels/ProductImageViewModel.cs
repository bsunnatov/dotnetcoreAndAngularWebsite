using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
  public class ProductImageViewModel : ViewModel
  {
    public string Name { get; set; }
    /// <summary>
    /// File Original Name Default
    /// </summary>
    public string DisplayName { get; set; }
    /// <summary>
    /// Full path for Image
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Extension Image (bmp,jpg,png)
    /// </summary>
    public string Extensions { get; set; }
    /// <summary>
    /// Size in KB
    /// </summary>
    public decimal Size { get; set; }
    public long ProductId { get; set; }
  }
}
