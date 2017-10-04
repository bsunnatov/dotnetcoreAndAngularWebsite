using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;
using IdealSysApp.ViewModels;
using AutoMapper;
using IdealSysApp.Models;
using IdealSysApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/ProductCategory")]
  [Authorize(Policy = "ApiUser")]
  public class ProductCategoryController : Controller
  {
    private readonly IRepository<ProductCategory> _service;
    public ProductCategoryController(IRepository<ProductCategory> service)
    {
      _service = service;
    }
    // GET: api/ProductCategory
    [HttpGet]
    public object Get([FromQuery]string filter,long? ParentId)
    {
      if (ParentId.HasValue)
      {
        var query = _service.GetWithInclude(p => p.Parent);
        if (ParentId.Value == 0)
          query = query.Where(p => !p.ParentId.HasValue);
        else
          query = query.Where(p => p.ParentId == ParentId);
       return _service._mapper.Map<IEnumerable<ProductCategoryViewModel>>(query);
      }
 
      if (!string.IsNullOrEmpty(filter))
      {
        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var q = _service.AsQueryable().Include("Childs.Childs.Childs.Childs").Include(p=>p.PropertyInProductCategories).AsQueryable();
        if (!string.IsNullOrEmpty(_filter.Term))
        {
          q = q.Where(p => p.Name.Contains(_filter.Term)||p.Childs.Any(s=>s.Name.Contains(_filter.Term)));
        }
        if ((_filter.ParentId ==0))
          q = q.Where(p =>p.ParentId==null);
        var result = q.OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        if (_filter.AsSelect2)
        {
          var select2Result = _service._mapper.Map<IEnumerable<Select2ViewModel>>(result.Data);
          return new { Data = select2Result, Total = result.Total };
        }
        var vmResult =_service._mapper.Map<IEnumerable<ProductCategoryViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      else
      {
        var vmResult = _service._mapper.Map<IEnumerable<ProductCategoryViewModel>>(_service.GetWithInclude(p=>p.Parent));
        return vmResult;
      }
    }

    // GET: api/ProductCategory/5
    [HttpGet("{id}")]
    public object Get(long id)
    {
      var ent = _service.Get(id);
      return _service._mapper.Map<ProductCategoryViewModel>(ent);
    }
    // POST: api/ProductCategory
    [HttpPost]
    public IActionResult Post([FromBody]ProductCategoryViewModel model)
    {
      try
      {
        var ent = _service.InsertViewModel(model);
        return new OkObjectResult(_service._mapper.Map<ProductCategoryViewModel>(ent));
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }

    // PUT: api/ProductCategory/5
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody]ProductCategoryViewModel value)
    {
      try
      {
        var ent = _service.Get(id);
        _service.ViewModel = value;
        ent = _service.Update(ent);
        return new OkObjectResult(_service._mapper.Map<ProductCategoryViewModel>(ent));
      }
      catch (Exception ex)
      {

        return new BadRequestObjectResult(ex.Message);
      }

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var ent=_service.Get(id);
      if (ent != null)
      {
        _service.Delete(ent);
        return Ok();
      }
      else
        return BadRequest("Entity not found");

    }
  }
}
