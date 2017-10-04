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
    private readonly IRepository<ProductProperty> _service;
    private readonly IRepository<DynamicProperty> _dpservice;
    public ProductPropertyController(IRepository<ProductProperty> service, IRepository<DynamicProperty> dpservice)
    {
      this._service = service;
      this._dpservice = dpservice;
    }
    [HttpGet("GetProperty/{productId}")]
    public IActionResult GetProperty(long productId)
    {
      var entities = _service.GetWithInclude(p => p.DynamicProperty.DynamicPropertyValues).Where(p => p.ProductId == productId).ToList();
      var vms = _service._mapper.Map<IList<ProductPropertyViewModel>>(entities);
      var addedIds = entities.Select(s => s.DynamicPropertyId);
      var newProps = _dpservice.GetWithInclude(p => p.DynamicPropertyValues).Where(p => !addedIds.Any(s => s == p.Id));
      foreach (var item in newProps)
      {
        vms.Add(new ProductPropertyViewModel()
        {
          Value = item.Value,
          ProductId = productId,
          DynamicPropertyId = item.Id,
          DynamicPropertyValues = _service._mapper.Map<IList<DynamicPropertyValueViewModel>>(item.DynamicPropertyValues)
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
          var prodProp = _service._mapper.Map<ProductProperty>(item);
          var selectedValue = item.DynamicPropertyValues.FirstOrDefault(p => p.IsSelected);
          if (selectedValue != null)
          {
            prodProp.DynamicPropertyValueId = selectedValue.Id;
            if (prodProp.Id == 0)
            {


            
              _service.Insert(prodProp);

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
