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

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/ProductCategory")]
  public class ProductCategoryController : Controller
  {
    private readonly IRepository<ProductCategory,ProductCategoryViewModel> _service;
    private readonly IMapper _mapper;
    public ProductCategoryController(IRepository<ProductCategory, ProductCategoryViewModel> service,IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }
    // GET: api/ProductCategory
    [HttpGet]
    public IEnumerable<ProductCategoryViewModel> Get()
    {
      return _mapper.Map<IEnumerable<ProductCategoryViewModel>>(_service.GetAll());
    }

    // GET: api/ProductCategory/5
    [HttpGet("{id}")]
    public string Get(long id)
    {
      return "value";
    }

    // POST: api/ProductCategory
    [HttpPost]
    public void Post([FromBody]ProductCategoryViewModel model)
    {
      _service.InsertViewModel(model);
    }

    // PUT: api/ProductCategory/5
    [HttpPut("{id}")]
    public void Put(long id, [FromBody]string value)
    {

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(long id)
    {
    }
  }
}
