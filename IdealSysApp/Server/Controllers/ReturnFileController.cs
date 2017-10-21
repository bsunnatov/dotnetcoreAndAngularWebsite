using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/ReturnFile")]
  public class ReturnFileController : Controller
  {
    private IHostingEnvironment _appEnvironment;
    private readonly IEntityService<Product> _service;
    IEntityService<ProductImage> _pi_service;
    public ReturnFileController(IHostingEnvironment appEnvironment, IEntityService<Product> service, IEntityService<ProductImage> pi_service)
    {
      _appEnvironment = appEnvironment;
      _service = service;
      _pi_service = pi_service;
    }
    [HttpGet("GetById/{Id}")]
    public IActionResult GetById(long Id)
    {
      var ent = _service.GetById(Id);
      if (ent == null)
      {
        return new EmptyResult();
      }
      var filePath = Path.Combine(_appEnvironment.ContentRootPath, "uploads", ent.ImageUrl?? "no-image-box.png");
      if (System.IO.File.Exists(filePath))
      {
        var image = System.IO.File.OpenRead(filePath);
        return File(image, "image/jpeg");
      }
      return new EmptyResult();
    }
    [HttpGet("GetByFileName/{fileName}")]
    public IActionResult GetByFileName(string fileName)
    {
      var filePath = Path.Combine(_appEnvironment.ContentRootPath, "uploads", fileName ?? "no-image-box.png");
      if (System.IO.File.Exists(filePath))
      {
        var image = System.IO.File.OpenRead(filePath);
        return File(image, "image/*");
      }
      return new EmptyResult();
    }
  }
}
