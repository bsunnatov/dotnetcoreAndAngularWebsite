using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/UploadFiles")]
  public class UploadFilesController : Controller
  {
    private IHostingEnvironment _appEnvironment;
    private readonly IRepository<Product> _service;
    public UploadFilesController(IHostingEnvironment appEnvironment, IRepository<Product> service)
    {
      _appEnvironment = appEnvironment;
      _service = service;
    }
    #region snippet1
    
    [HttpPost("UploadFiles/{Id}/{isGeneral?}")]
    public IActionResult Post(long Id,IFormFile file,bool isGeneral = true)
    {
      var ent = _service.Get(Id);
      if (Id > 0&&ent!=null) {
        try
        {
          if (file != null && file.Length > 0)
          {
            var savePath = Path.Combine(_appEnvironment.ContentRootPath, "uploads", generateFilename(Path.GetExtension(file.FileName)));

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
              file.CopyTo(fileStream);
            }

            var created= Created(savePath, file);
            if(isGeneral)
            ent.ImageUrl = file.FileName;
            else
            {
              ent.ProductImages.Add(new ProductImage() { });
            }
            _service.Update(ent);
            return Ok(ent);

          }
        }
        catch (Exception ex)
        {
          return StatusCode(500, ex.Message);
        }
      }
      else
      {
        return BadRequest("Выберите товар");
      }


      return BadRequest("Not");
      // process uploaded files
      // Don't rely on or trust the FileName property without validation.
     
     
    }
    private string generateFilename(string ext)
    {
      return string.Format("{0}.{1}", Guid.NewGuid().ToString("D"), ext);
    }
    #endregion
  }
}