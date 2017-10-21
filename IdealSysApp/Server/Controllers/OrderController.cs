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
using IdealSysApp.Data.Enums;

namespace IdealSysApp.Server.Controllers
{
  [Produces("application/json")]
  [Route("api/Order")]
  public class OrderController : BaseController
  {
    private readonly IEntityService<Order> orderService;
    private readonly IEntityService<OrderItem> orderItemService;
    public OrderController(IEntityService<Order> repository, IEntityService<OrderItem> orderItemService)
    {
      this.orderService = repository;
      this.orderItemService = orderItemService;
    }
    public async Task<IActionResult> Get()
    {
      var result = await orderService.GetAllAsync();
      return Ok(orderService.mapper.Map<IList<OrderViewModel>>(result));
    }
    [HttpGet("Me/ByStatus/{status}")]
    public IActionResult ByStatus(int status)
    {
      var query = orderService.AsQueryableForUser().Where(w=>w.OrderStatus == (OrderStatusEnum)status).Include("OrderItems.Product").Include(c=>c.Customer);
      return Ok(orderService.mapper.Map<IList<OrderViewModel>>(query.ToList()));
    }
    [HttpGet("Me/{id?}")]
    public IActionResult Me(int? id)
    {
      var query = orderService.AsQueryableForUser().Include("OrderItems.Product").Include(c=>c.Customer);
      if (id.HasValue)
      {
        var ent = query.FirstOrDefault(p => p.Id == id);
        return Ok(orderService.mapper.Map<OrderViewModel>(ent));
      }
      return Ok(orderService.mapper.Map<IList<OrderViewModel>>(query.ToList()));

    }
    [HttpPost]
    public IActionResult Post([FromBody]OrderViewModel model)
    {
      var order = orderService.CreateFromViewModel(model);
      if (order != null)
        return Ok();
      else return BadRequest();
    }
    [HttpPut]
    public IActionResult Put([FromBody]OrderViewModel model)
    {

      var ent = orderService.AsQueryableTrack().Include(o=>o.OrderItems).FirstOrDefault(a => a.Id == model.Id);
      if (ent != null)
      {
        ent.OrderStatus = model.OrderStatus;
        ent.OverheadNumber = model.OverheadNumber;
        if (model.OrderStatus == OrderStatusEnum.Order)
        {
          ent.SendDate = DateTime.Now;
        }
        //Update Order Items or Delete
        foreach (var item in ent.OrderItems)
        {
          var updateModel = model.OrderItems.FirstOrDefault(p => p.Id == item.Id);
          if (updateModel != null)
          {
            orderService.mapper.Map<OrderItemViewModel, OrderItem>(updateModel, item);
          }
          else
          {
            orderItemService.Delete(item, false);
          }
        }
        //Add new Items
        foreach (var item in model.OrderItems.Where(p=>p.Id==0))
        {
          ent.OrderItems.Add(orderService.mapper.Map<OrderItem>(item));
        }
        var order = orderService.Update(ent);
        return Ok(orderService.mapper.Map<OrderViewModel>(order));
      }
      else return BadRequest();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var ent = orderService.GetById(id);
      if (ent != null)
      {
        int result = orderService.Delete(ent);
        if (result > 0)
          return Ok(result);
        return BadRequest(result);
      }
      return BadRequest();

    }
  }
}
