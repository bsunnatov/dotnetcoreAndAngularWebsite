using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdealSysApp.Data;
using Microsoft.AspNetCore.Identity;
using IdealSysApp.Models.Entities;
using AutoMapper;
using IdealSysApp.ViewModels;
using IdealSysApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace IdealSysApp.Controllers
{
  [Route("api/[controller]")]
  public class AccountsController : Controller
  {
    private readonly ApplicationDbContext _appDbContext;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
    {
      _userManager = userManager;
      _mapper = mapper;
      _appDbContext = appDbContext;
    }
    // GET api/accounts/GetUserList
    [Authorize(Policy = "ApiUser",Roles ="Administrator")]
    [HttpGet("GetUserList")]
    public object GetUserList()
    {

      var result= _mapper.Map<IList<UserViewModel>>(_userManager.Users.Include(r=>r.Roles));

      return result;


    }

    // POST api/accounts
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userIdentity = _mapper.Map<AppUser>(model);

      var result = await _userManager.CreateAsync(userIdentity, model.Password);

      if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

      await _appDbContext.JobSeekers.AddAsync(new JobSeeker { IdentityId = userIdentity.Id, Location = model.Location });
      await _appDbContext.SaveChangesAsync();

      return new OkObjectResult("Account created");
    }
    [Authorize(Policy = "ApiUser", Roles = "Administrator")]
    [HttpPost("Add")]
    public IActionResult Add([FromBody]UserViewModel model)
    {
      return Ok(model);
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody]UserViewModel model)
    {
      var user = await _userManager.FindByIdAsync(model.Id);
      var result = _mapper.Map<UserViewModel, AppUser>(model, user);
      await _userManager.UpdateAsync(result);
      return Ok(result);
    }
  }
}