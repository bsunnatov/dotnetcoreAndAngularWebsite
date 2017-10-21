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
namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/Storage")]
  public class StorageController : Controller
  {
    private readonly IEntityService<Storage> _service;
    public StorageController(IEntityService<Storage> service)
    {
      _service = service;
    }
    // GET: api/Storage
    [HttpGet]
    public object Get([FromQuery]string filter)
    {
 
      if (!string.IsNullOrEmpty(filter))
      {
        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var result = _service.AsQueryable().OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult =_service.mapper.Map<IEnumerable<StorageViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      else
      {
        var vmResult = _service.mapper.Map<IEnumerable<StorageViewModel>>(_service.AsQueryable());
        return new { Data = vmResult, Total = _service.AsQueryable().Count() };
      }
    }

    // GET: api/Storage/5
    [HttpGet("{id}")]
    public object Get(long id)
    {
      var ent = _service.GetById(id);
      return _service.mapper.Map<StorageViewModel>(ent);
    }

    // POST: api/Storage
    [HttpPost]
    public IActionResult Post([FromBody]StorageViewModel model)
    {
      try
      {
        var ent = _service.CreateFromViewModel(model);
        return new OkObjectResult(_service.mapper.Map<StorageViewModel>(ent));
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }

    // PUT: api/Storage/5
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody]StorageViewModel value)
    {
      try
      {
        var ent = _service.GetById(id);
        _service.ViewModel = value;
        ent = _service.Update(ent);
        return new OkObjectResult(_service.mapper.Map<StorageViewModel>(ent));
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
