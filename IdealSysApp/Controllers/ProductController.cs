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

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/Product")]
  public class ProductController : Controller
  {
    private IHostingEnvironment _hostingEnvironment;
    private readonly IRepository<Product> _service;
    private readonly IRepository<ProductCategory> _prc_service;
    private readonly IMapper _mapper;
    public ProductController(IHostingEnvironment environment, IRepository<Product> service, IRepository<ProductCategory> prc_service, IMapper mapper)
    {
      _hostingEnvironment = environment;
      _service = service;
      _prc_service = prc_service;
      _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<ProductViewModel> Get()
    {
      var products = _mapper.Map<IEnumerable<ProductViewModel>>(_service.GetAll());
      return products;
    }
    // GET: api/Product
    [HttpGet("ProductCategoryImport")]
    public string ProductCategoryImport()
    {
      var path = Path.Combine(_hostingEnvironment.ContentRootPath, "AppData", "Groups.xml");
      try
      {

        var _groupList = ForRemoteService.DeserializeXMLFileToObject<GroupList>(path);
        int i = 0;
        if (!_prc_service.GetAll().Any())
          foreach (var item in _groupList.Groups)
          {
            _prc_service.Insert(new ProductCategory() { Name = item.Name, GroupId = item.Id });
            i++;
          }
        return string.Format("добавлен {0} кол-во записей", i);
      }
      catch (Exception ex)
      {

        return string.Format("{0} path={1}", ex.Message, path);
      }

    }
    [HttpGet("ProductImport")]
    public string DoXmlImport()
    {
      var path = Path.Combine(_hostingEnvironment.ContentRootPath, "AppData", "goods.xml");
      var _goodList = ForRemoteService.DeserializeXMLFileToObject<GoodList>(path);
      int i = 0;
      var allProducts = _service.GetAll();
      var allPrC = _prc_service.GetAll();
      if(!allProducts.Any())
      foreach (var item in _goodList.Goods)
      {
        var productCategory = allPrC.FirstOrDefault(p => p.GroupId == item.GroupID);
        if (productCategory != null)
        {
          _service.Insert(new Product() { GroupID = item.GroupID, goodID = item.Id, Name = item.Name, Price = item.Price, ProductCategoryId = productCategory.Id });
          i++;
        }
      }
      return string.Format("добавлен {0} кол-во записей", i);
    }
    // GET: api/Product/5
    [HttpGet("{id}")]
    public ProductViewModel Get(long id)
    {
      var product = _service.Get(id);
      return _mapper.Map<ProductViewModel>(product);
    }
  }
}
