using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using IdealSysApp.Models.Entities;
using Microsoft.Extensions.Logging;

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/SiteLink")]
  public class SiteLinkController : Controller
  {
    private readonly ILogger<SiteLinkController> _log;
    private readonly IRepository<SiteLink> _service;
    public SiteLinkController(IRepository<SiteLink> service,ILogger<SiteLinkController> log)
    {
      _service = service;
      _log = log;
    }
    // GET: api/SiteLink
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return _service.GetAll().Select(s => s.Name);
    }

    // POST: api/SiteLink
    [HttpPost]
    public void Post([FromBody]string value)
    {
      try
      {
        _service.Insert(new SiteLink() { Name = "Home" });
      }
      catch (Exception)
      {

        throw;
      }
     
    }

    // PUT: api/SiteLink/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/SiteLink/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
