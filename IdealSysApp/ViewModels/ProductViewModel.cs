﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
    public class ProductViewModel:IViewModel
    {
    public ProductViewModel()
    {
      DynamicProperties = new List<DynamicPropertyViewModel>();
    }
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    /// <summary>
    /// Single Image for Product
    /// </summary>
    public string ImageUrl { get; set; }
    public long ProductCategoryId { get; set; }
    public decimal Price { get; set; }
    public IList<DynamicPropertyViewModel> DynamicProperties { get; set; }
  }
}
