using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Models.Entities;
using IdealSysApp.Services;
using IdealSysApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Xml.Serialization;
using IdealSysApp.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using IdealSysApp.Models;
using IdealSysApp.Extensions;
using Microsoft.EntityFrameworkCore;
namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/Product")]
  public class ProductController : Controller
  {
    private IHostingEnvironment _hostingEnvironment;
    private readonly IEntityService<Product> _service;
    public ProductController(IHostingEnvironment environment, IEntityService<Product> service)
    {
      _hostingEnvironment = environment;
      _service = service;
    }
    [HttpGet("GetByProperty")]
    public IActionResult GetByProperty([FromQuery]long[] ids)
    {
      var query = _service.AsQueryable().Include(p=>p.ProductProperties);
      var result = query.Where(p => p.ProductProperties.Any(s => ids.Contains(s.DynamicPropertyValueId ?? 0)));
      return Ok(result.ToList());
    }
    [HttpGet]
    public object Get([FromQuery]string filter)
    {
      if (!string.IsNullOrEmpty(filter))
      {
        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var query = _service.AsQueryable();
        if (_filter.DynamicPropertyValueIds!=null&&_filter.DynamicPropertyValueIds.Count() > 0)
        {
          query = query.Where(p => p.ProductProperties.Any(s =>_filter.DynamicPropertyValueIds.Contains(s.DynamicPropertyValueId??0)));
        }
        var result = query.Include(p=>p.ProductImages).OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult = _service.mapper.Map<IEnumerable<ProductViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      else
      {
        var vmResult = _service.mapper.Map<IEnumerable<ProductViewModel>>(_service.AsQueryable());
        return vmResult;
      }
    }

    [HttpGet("{id}")]
    public ProductViewModel Get(long id)
    {
      var product = _service.GetById(id);
      return _service.mapper.Map<ProductViewModel>(product);
    }
    // POST: api/Storage
    [HttpPost]
    public IActionResult Post([FromBody]ProductViewModel model)
    {
      try
      {
        var ent = _service.CreateFromViewModel(model);
        return new OkObjectResult(_service.mapper.Map<ProductViewModel>(ent));
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }
    // PUT: api/ProductCategory/5
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody]ProductViewModel value)
    {
      try
      {
        var ent = _service.GetById(id);
        _service.ViewModel = value;
        ent = _service.Update(ent);
        return new OkObjectResult(_service.mapper.Map<ProductViewModel>(ent));
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
      var ent = _service.GetById(id);
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
