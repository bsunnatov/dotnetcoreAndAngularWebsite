using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdealSysApp.Controllers
{

  [Produces("application/json")]
  [Route("api/Dashboard")]
  //[Authorize(Policy = "ApiUser")]
  public class DashboardController : Controller
  {
    // GET: api/Dashboard
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    [Authorize(Policy = "ApiUser")]
    // GET api/dashboard/home
    [HttpGet("home")]
    public IActionResult GetHome()
    {
      return new OkObjectResult(new { Message = "This is secure data!" });
    }
    // GET: api/Dashboard/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Dashboard
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Dashboard/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

  }
}
