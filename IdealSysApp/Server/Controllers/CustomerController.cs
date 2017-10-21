using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Server.Entities;
using IdealSysApp.Server.ViewModels;
using IdealSysApp.Models;
using IdealSysApp.Extensions;
namespace IdealSysApp.Server.Controllers
{
  [Produces("application/json")]
  [Route("api/Customer")]
  public class CustomerController : Controller
  {
    private readonly IEntityService<Customer> service;
    public CustomerController(IEntityService<Customer> repository)
    {
      this.service = repository;
    }
    public async Task<object> Get([FromQuery]string filter)
    {

      if (!string.IsNullOrEmpty(filter))
      {
        var query = service.AsQueryable();

        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var result = query.OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult = service.mapper.Map<IEnumerable<CustomerViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      var allresult = await service.GetAllAsync();
      return Ok(allresult);
    }
    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
      var ent = service.GetById(id);
      if (ent != null)
      {
        return Ok(service.mapper.Map<CustomerViewModel>(ent));
      }
      return BadRequest(new string[] { "Entity not found!!!" });
    }
    [HttpGet("Get/{personType}")]
    public IActionResult Get(int personType)
    {
      var result = service.GetAllAsync().GetAwaiter().GetResult();
      if (personType >= 2)
        return Ok(result);
      return Ok(result.Where(p => p.PersonType == (Enums.PersonTypeEnum)personType));
    }
    [HttpPost]
    public IActionResult Post([FromBody]CustomerViewModel model)
    {
      var customer = service.CreateFromViewModel(model);
      return Ok(customer);
    }
    [HttpPut]
    public IActionResult Put([FromBody]CustomerViewModel model)
    {
      var ent = service.GetById(model.Id);
      if (ent != null)
      {
        ent = service.mapper.Map<CustomerViewModel, Customer>(model, ent);
        var customer = service.Update(ent);
        return Ok(customer);
      }
      return BadRequest();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var ent = service.GetById(id);
      if (ent != null)
      {
        int result = service.Delete(ent);
        if (result > 0)
          return Ok(result);
        return BadRequest(result);
      }
      return BadRequest();

    }
  }
}
