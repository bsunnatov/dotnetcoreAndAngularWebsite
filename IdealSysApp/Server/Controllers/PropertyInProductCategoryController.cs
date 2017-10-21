using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;
using IdealSysApp.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/PropertyInProductCategory")]
  public class PropertyInProductCategoryController : Controller
  {
    private readonly IEntityService<PropertyInProductCategory> _repository;
    public PropertyInProductCategoryController(IEntityService<PropertyInProductCategory> repository)
    {
      _repository = repository;
    }
    [HttpGet("GetProps/{productCategoryId}")]
    public IActionResult GetProps(long productCategoryId)
    {
      var entities=_repository.AsQueryable().Include(a=>a.DynamicProperty).Where(p=>p.ProductCategoryId==productCategoryId);
      return Ok(_repository.mapper.Map<IList<DynamicPropertyViewModel>>(entities.Select(p=>p.DynamicProperty)));
    }
    [HttpPost("SetProps/{productCategoryId}")]
    public IActionResult SetProps(long productCategoryId, [FromBody]long []dynamicPropertyIds)
    {
     var currentPropIds= _repository.AsQueryable().Where(p => p.ProductCategoryId == productCategoryId).Select(s=>s.ProductCategoryId);
      //DeleteProps
      foreach (var item in currentPropIds.Where(p=>!dynamicPropertyIds.Contains(p)))
      {
        var ent = _repository.AsQueryable().FirstOrDefault(p => p.ProductCategoryId == productCategoryId && p.DynamicPropertyId == item);
        if(ent!=null)
        _repository.Delete(ent);
      }
      //Insert new props
      foreach (var dynamicPropertyId in dynamicPropertyIds)
      {
        var ent = _repository.AsQueryable().FirstOrDefault(p => p.ProductCategoryId == productCategoryId && p.DynamicPropertyId == dynamicPropertyId);
        if (ent == null)
        {
          ent = new PropertyInProductCategory() { ProductCategoryId = productCategoryId, DynamicPropertyId = dynamicPropertyId };
          _repository.Create(ent);
        }
      }
      
      return Ok();
    }
    private  ProductCategory RecursiveAdd(ProductCategory ent)
    {
      foreach (var item in ent.Childs)
      {
        RecursiveAdd(item);
      }
      return null;
    }
  }
}
