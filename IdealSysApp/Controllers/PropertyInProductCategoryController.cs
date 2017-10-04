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
    private readonly IRepository<PropertyInProductCategory> _repository;
    public PropertyInProductCategoryController(IRepository<PropertyInProductCategory> repository)
    {
      _repository = repository;
    }
    [HttpGet("GetProps/{productCategoryId}")]
    public IActionResult GetProps(long productCategoryId)
    {
      var entities=_repository.AsQueryable().Include(a=>a.DynamicProperty).Where(p=>p.ProductCategoryId==productCategoryId);
      return Ok(_repository._mapper.Map<IList<DynamicPropertyViewModel>>(entities.Select(p=>p.DynamicProperty)));
    }
    public IActionResult Add(long productCategoryId, long dynamicPropertyId)
    {
      var ent = _repository.AsQueryable().FirstOrDefault(p=>p.ProductCategoryId==productCategoryId&&p.DynamicPropertyId==dynamicPropertyId);
      if (ent == null)
      {
        ent = new PropertyInProductCategory() {ProductCategoryId=productCategoryId,DynamicPropertyId=dynamicPropertyId };
        _repository.Insert(ent);
      }
      return Ok();
    }
  }
}
