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
      var ent = _service.GetTrack(Id);
      if (Id > 0&&ent!=null) {
        try
        {
          if (file != null && file.Length > 0)
          {
            var g_filename = generateFilename(Path.GetExtension(file.FileName));
            var savePath = Path.Combine(_appEnvironment.ContentRootPath, "uploads", g_filename);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
              file.CopyTo(fileStream);
            }

            var created= Created(savePath, file);
            if (isGeneral)
            {
              if (ent.ImageUrl != null)
              {
                var currentFilePath = Path.Combine(_appEnvironment.ContentRootPath, "uploads", ent.ImageUrl);
                if (System.IO.File.Exists(currentFilePath))
                {
                  System.IO.File.Delete(currentFilePath);
                }
              }
              ent.ImageUrl = g_filename;
            }
            else
            {
              var newImgEnt = new ProductImage() { Name = g_filename, Extensions = Path.GetExtension(file.FileName), DisplayName = file.FileName, Size = file.Length };
              ent.ProductImages.Add(newImgEnt);
            }
            _service.Update(ent);
            return Ok(g_filename);

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
      return string.Format("{0}{1}", Guid.NewGuid().ToString("N"), ext);
    }
    #endregion
  }
}