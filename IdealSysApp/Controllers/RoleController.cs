using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IdealSysApp.Models.Entities;
using IdealSysApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdealSysApp.Models.Enums;

namespace IdealSysApp.Controllers
{
  [Produces("application/json")]
  [Route("api/Role")]
  public class RoleController : Controller
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDbContext _appDbContext;
    private readonly RoleManager<AppRole> _roleManager;
    public RoleController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext,RoleManager<AppRole> roleManager)
    {
      _userManager = userManager;
      _appDbContext= appDbContext;
      _roleManager = roleManager;
     
    }
    // GET: api/Role
    [HttpGet]
    public object Get()
    {
      var roles = EnumExtensions.GetListOfDescription<RoleNameEnum>();
      return _roleManager.Roles.Select(s => new { text = s.Name, id = s.Id,s.Description}).ToList();
     // return _appDbContext.Roles.Select(s => new {text=s.Name,id=s.Id  }).ToList();
    }

    // GET: api/Role/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Role
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Role/5
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
