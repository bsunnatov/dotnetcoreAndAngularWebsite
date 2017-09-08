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
      var entities = _service.GetWithInclude(p=>p.DynamicPropertyValue).Where(p => p.ProductId == productId).ToList();
      var vms = _service._mapper.Map<IList<ProductPropertyViewModel>>(entities);
      var addedIds = entities.Select(s => s.DynamicPropertyId);
      var newProps = _dpservice.GetWithInclude(p=>p.DynamicPropertyValues).Where(p => !addedIds.Any(s => s == p.Id));
      foreach (var item in newProps)
      {
        vms.Add(new ProductPropertyViewModel() {Value=item.Value, ProductId=productId,DynamicPropertyId=item.Id,DynamicPropertyValues=_service._mapper.Map<IList<DynamicPropertyValueViewModel>>(item.DynamicPropertyValues)
         // item.DynamicPropertyValues.Select(s=>new DynamicPropertyValueViewModel() {Id=s.Id,DynamicPropertyId=s.DynamicPropertyId, Key=s.Key,Value=s.Value }).ToList()
        });
      }
      return Ok(vms);
    }
    [HttpPost("SaveChanges")]
    public IActionResult SaveChanges([FromBody]IList<DynamicPropertyViewModel> props)
    {
      if (props != null)
        return Ok(props);
      return BadRequest();
    }
  }
}