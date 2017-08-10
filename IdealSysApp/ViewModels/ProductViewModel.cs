using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
    public class ProductViewModel
    {
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public long ProductCategoryId { get; set; }
    public string goodID { get; set; }
    public string Group { get; set; }
    public decimal Price { get; set; }
  }
}
