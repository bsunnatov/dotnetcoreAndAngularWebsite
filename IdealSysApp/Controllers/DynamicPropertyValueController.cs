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

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/DynamicPropertyValue")]
 // [Authorize(Policy = "ApiUser")]
  public class DynamicPropertyValueController : Controller
  {
    private readonly IRepository<DynamicPropertyValue> _service;
    public DynamicPropertyValueController(IRepository<DynamicPropertyValue> service)
    {
      _service = service;
    }
    // GET: api/DynamicPropertyValue
    [HttpGet]
    public object Get([FromQuery]string filter)
    {
 
      if (!string.IsNullOrEmpty(filter))
      {
        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var query = _service.AsQueryable();
        var result = query.OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult =_service._mapper.Map<IEnumerable<DynamicPropertyValueViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      else
      {
        var vmResult = _service._mapper.Map<IEnumerable<DynamicPropertyValueViewModel>>(_service.AsQueryable());
        return new { Data = vmResult, Total = _service.AsQueryable().Count() };
      }
    }

    // GET: api/DynamicPropertyValue/5
    [HttpGet("{id}")]
    public object Get(long id)
    {
      var ent = _service.Get(id);
      return _service._mapper.Map<DynamicPropertyValueViewModel>(ent);
    }

    // POST: api/DynamicPropertyValue
    [HttpPost]
    public IActionResult Post([FromBody]DynamicPropertyValueViewModel model)
    {
      try
      {
        var ent = _service.InsertViewModel(model);
        return new OkObjectResult(_service._mapper.Map<DynamicPropertyValueViewModel>(ent));
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }

    // PUT: api/DynamicPropertyValue/5
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody]DynamicPropertyValueViewModel value)
    {
      try
      {
        var ent = _service.Get(id);
        _service.ViewModel = value;
        ent = _service.Update(ent);
        return new OkObjectResult(_service._mapper.Map<DynamicPropertyValueViewModel>(ent));
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
