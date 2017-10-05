using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;
using IdealSysApp.Server.ViewModels;

namespace IdealSysApp.Server.Controllers
{
  [Produces("application/json")]
  [Route("api/Order")]
  public class OrderController : Controller
  {
    private readonly IRepository<Order> repository;
    public OrderController(IRepository<Order> repository)
    {
      this.repository = repository;
    }
    public async Task<IActionResult> Get()
    {
      var result = await repository.GetAllAsync();
      return Ok(result);
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
