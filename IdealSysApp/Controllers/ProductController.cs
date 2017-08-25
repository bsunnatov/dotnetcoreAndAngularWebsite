using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Models.Entities;
using IdealSysApp.Services;
using IdealSysApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Xml.Serialization;
using IdealSysApp.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using IdealSysApp.Models;
using IdealSysApp.Extensions;
namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/Product")]
  public class ProductController : Controller
  {
    private IHostingEnvironment _hostingEnvironment;
    private readonly IRepository<Product> _service;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    public ProductController(IHostingEnvironment environment, IRepository<Product> service)
    {
      _hostingEnvironment = environment;
      _service = service;
    }
    [HttpGet]
    public object Get([FromQuery]string filter)
    {
      if (!string.IsNullOrEmpty(filter))
      {
        DataSourceRequest _filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSourceRequest>(filter);
        var result = _service.AsQueryable().OrderBy(p => p.Id).ToDataSourceResult(_filter.Take, _filter.Skip, _filter.Sort, _filter.Filter);
        var vmResult = _service._mapper.Map<IEnumerable<ProductViewModel>>(result.Data);
        return new { Data = vmResult, Total = result.Total };
      }
      else
      {
        var vmResult = _service._mapper.Map<IEnumerable<ProductViewModel>>(_service.AsQueryable());
        return new { Data = vmResult, Total = _service.AsQueryable().Count() };
      }
    }

    [HttpGet("{id}")]
    public ProductViewModel Get(long id)
    {
      var product = _service.Get(id);
      return _mapper.Map<ProductViewModel>(product);
    }
    // POST: api/Storage
    [HttpPost]
    public IActionResult Post([FromBody]ProductViewModel model)
    {
      try
      {
        var ent = _service.InsertViewModel(model);
        return new OkObjectResult(_service._mapper.Map<ProductViewModel>(ent));
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }
  }
}
