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
using IdealSysApp.Server.Services;

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/DynamicProperty")]
 // [Authorize(Policy = "ApiUser")]
  public class DynamicPropertyController : Controller
  {
    private readonly Data.IEntityService<DynamicProperty> _service;
    public DynamicPropertyController(Data.IEntityService<DynamicProperty> service)
    {
      _service = service;
    }
    // GET: api/DynamicProperty
    [HttpGet]
    public object Get([FromQuery]string filter)
    {
      var query = _service.AsQueryable();
      query = query.Include(p => p.DynamicPropertyValues);
      if (!string.IsNullOrEmpty(filter))
      {
       
        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var result = query.OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult =_service.mapper.Map<IEnumerable<DynamicPropertyViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      else
      {
        var vmResult = _service.mapper.Map<IEnumerable<DynamicPropertyViewModel>>(query);
        return new { Data = vmResult, Total = query.Count() };
      }
    }

    // GET: api/DynamicProperty/5
    [HttpGet("{id}")]
    public object Get(long id)
    {
      var ent = _service.GetById(id);
      return _service.mapper.Map<DynamicPropertyViewModel>(ent);
    }

    // POST: api/DynamicProperty
    [HttpPost]
    public IActionResult Post([FromBody]DynamicPropertyViewModel model)
    {
      try
      {
        var ent = _service.CreateFromViewModel(model);
        return new OkObjectResult(_service.mapper.Map<DynamicPropertyViewModel>(ent));
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }

    // PUT: api/DynamicProperty/5
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody]DynamicPropertyViewModel value)
    {
      try
      {
        var ent = _service.GetById(id);
        _service.ViewModel = value;
        ent = _service.Update(ent);
        return new OkObjectResult(_service.mapper.Map<DynamicPropertyViewModel>(ent));
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
      var ent=_service.GetById(id);
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
