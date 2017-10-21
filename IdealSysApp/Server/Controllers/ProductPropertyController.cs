using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;
using IdealSysApp.ViewModels;

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/ProductProperty")]
  public class ProductPropertyController : Controller
  {
    private readonly IEntityService<ProductProperty> _service;
    private readonly IEntityService<PropertyInProductCategory> _dpservice;
    public ProductPropertyController(IEntityService<ProductProperty> service, IEntityService<PropertyInProductCategory> dpservice)
    {
      this._service = service;
      this._dpservice = dpservice;
    }
    [HttpGet("GetProperty/{productId}/{productCategoryId?}")]
    public IActionResult GetProperty(long productId, long? productCategoryId)
    {
      var pp = _service.GetWithInclude(p => p.DynamicProperty.DynamicPropertyValues);
      var q = pp.Where(p => p.ProductId == productId);
      var entities = q.ToList();
      var vms = _service.mapper.Map<IList<ProductPropertyViewModel>>(entities);
      var addedIds = entities.Select(s => s.DynamicPropertyId);
      var prodinprops = _dpservice.GetWithInclude(p => p.DynamicProperty.DynamicPropertyValues);
      var q2 = prodinprops.Where(p => !addedIds.Any(s => s == p.DynamicPropertyId));
      if (productCategoryId.HasValue)
        q2 = q2.Where(p => p.ProductCategoryId == productCategoryId);
      var newProps = q2;
      foreach (var item in newProps)
      {
        vms.Add(new ProductPropertyViewModel()
        {
          Key = item.DynamicProperty.Key,
          ProductId = productId,
          DynamicPropertyId = item.DynamicPropertyId,
          DynamicPropertyValues = _service.mapper.Map<IList<DynamicPropertyValueViewModel>>(item.DynamicProperty.DynamicPropertyValues)
        });
      }
      return Ok(vms);
    }
    [HttpPost("SaveChanges")]
    public IActionResult SaveChanges([FromBody]IList<ProductPropertyViewModel> props)
    {

      if (props != null)
      {
        foreach (var item in props)
        {
          var prodProp = _service.mapper.Map<ProductProperty>(item);
          var selectedValue = item.DynamicPropertyValues.FirstOrDefault(p => p.IsSelected);
          if (selectedValue != null)
          {
            prodProp.DynamicPropertyValueId = selectedValue.Id;
            if (prodProp.Id == 0)
            {



              _service.Create(prodProp);

            }
            else
            {
              _service.Update(prodProp);
            }
          }
        }
        return Ok();
      }
      return BadRequest();
    }
  }
}
