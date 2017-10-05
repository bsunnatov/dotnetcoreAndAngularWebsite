using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;
using IdealSysApp.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace IdealSysApp.Server.Controllers
{
  [Produces("application/json")]
  [Route("api/Order")]
  public class OrderController : BaseController
  {
    private readonly IRepository<Order> repository;
    public OrderController(IRepository<Order> repository)
    {
      this.repository = repository;
    }
    public async Task<IActionResult> Get()
    {
      var result = await repository.GetAllAsync();
      return Ok(repository._mapper.Map<IList<OrderViewModel>>(result));
    }
    [HttpGet("Me")]
    public IActionResult Me()
    {
      var query = repository.AsQueryableForUser().Include(p=>p.OrderItems);
      return Ok(repository._mapper.Map<IList<OrderViewModel>>(query.ToList()));

    }
    [HttpPost]
    public IActionResult Post([FromBody]OrderViewModel model)
    {
      //var order = new Order();
      //order.CustomerId = model.CustomerId;
      //order.OrderItems = repository._mapper.Map<IList<OrderItem>>(model.OrderItems);
      var order = repository.InsertViewModel(model);
      if (order != null)
        return Ok();
      else return BadRequest();
    }
  }
}
