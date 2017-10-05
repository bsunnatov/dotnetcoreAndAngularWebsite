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
    private readonly IRepository<Customer> repository;
    public CustomerController(IRepository<Customer> repository)
    {
      this.repository = repository;
    }
    public async Task<object> Get([FromQuery]string filter)
    {
      
      if (!string.IsNullOrEmpty(filter))
      {
        var query = repository.AsQueryable();

        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var result = query.OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult = repository._mapper.Map<IEnumerable<CustomerViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      var allresult = await repository.GetAllAsync();
      return Ok(allresult);
    }
    [HttpPost]
    public IActionResult Post([FromBody]CustomerViewModel model)
    {
      var customer = repository.InsertViewModel(model);
      return Ok(customer);
    }
    [HttpPut]
    public IActionResult Put([FromBody]CustomerViewModel model)
    {
      var ent = repository.Get(model.Id);
      if (ent != null)
      {
        ent = repository._mapper.Map<CustomerViewModel,Customer>(model,ent);
        var customer = repository.Update(ent);
        return Ok(customer);
      }
      return BadRequest();
    }
  }
}
