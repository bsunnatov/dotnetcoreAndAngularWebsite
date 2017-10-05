using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Server.Entities;
using IdealSysApp.Server.ViewModels;

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
    public async Task<IActionResult> Get()
    {
      var result = await repository.GetAllAsync();
      return Ok(result);
    }
    [HttpPost]
    public IActionResult Post([FromBody]CustomerViewModel model)
    {

      var customer = repository.InsertViewModel(model);
      return BadRequest(customer);
    }
  }
}
