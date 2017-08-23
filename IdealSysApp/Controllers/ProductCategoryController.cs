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
  [Route("api/ProductCategory")]
  public class ProductCategoryController : Controller
  {
    private readonly IRepository<ProductCategory> _service;
    private readonly IMapper _mapper;
    public ProductCategoryController(IRepository<ProductCategory> service,IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }
    // GET: api/ProductCategory
    [HttpGet]
    public object Get(DataSourceRequest filter)
    {
      var result = _service.AsQueryable().OrderBy(p=>p.Id).ToDataSourceResult(filter.Take, filter.Skip, filter.Sort, filter.Filter);
      var vmResult= _mapper.Map<IEnumerable<ProductCategoryViewModel>>(result.Data);
      return new { Data= vmResult, Total=result.Total };
    }

    // GET: api/ProductCategory/5
    [HttpGet("{id}")]
    public string Get(long id)
    {
      return "value";
    }

    // POST: api/ProductCategory
    [HttpPost]
    public IActionResult Post([FromBody]ProductCategoryViewModel model)
    {
      try
      {
        _service.InsertViewModel(model);
        return new OkObjectResult("Success");
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }
     
    }

    // PUT: api/ProductCategory/5
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody]ProductCategoryViewModel value)
    {
      try
      {
        var ent = _service.Get(id);
        _service.Update(ent);
        return new OkObjectResult("OK");
      }
      catch (Exception ex)
      {

        return new BadRequestObjectResult(ex.Message);
      }
     
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(long id)
    {
    }
  }
}
