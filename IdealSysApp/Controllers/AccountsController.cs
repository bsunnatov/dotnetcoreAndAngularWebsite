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
using static IdealSysApp.Helpers.Constants.Strings;

namespace IdealSysApp.Controllers
{
  [Authorize(Policy = "ApiUser", Roles = "Administrator")]//Permisson for Only Has Claim Role Administrator 
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

    [HttpGet("GetUserList")]
    public object GetUserList()
    {

      var result = _mapper.Map<IList<UserViewModel>>(_userManager.Users.Include(r => r.Roles));
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

      //await _appDbContext.JobSeekers.AddAsync(new JobSeeker { IdentityId = userIdentity.Id, Location = model.Location });
      await _appDbContext.SaveChangesAsync();

      return new OkObjectResult("Account created");
    }
    [HttpPost("AddNewUser")]
    public async Task<IActionResult> AddNewUser([FromBody]UserViewModel model)
    {
      try
      {
        var newUser = _mapper.Map<UserViewModel, AppUser>(model, new AppUser());
        newUser.UserName = model.Email;
        newUser.NormalizedUserName = model.Email;
        newUser.NormalizedEmail = model.Email;
        newUser.EmailConfirmed = true;
        newUser.PhoneNumberConfirmed = true;
        var result = await _userManager.CreateAsync(newUser, AppSettings.DefaultPassword);
        if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
        var result2 = await _userManager.AddToRolesAsync(newUser, model.SelectedRoles.Select(s => s.text));
        if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
        return new OkObjectResult("Account created");
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody]UserViewModel model)
    {
      try
      {
        var user = await _userManager.FindByIdAsync(model.Id);
        var result = _mapper.Map<UserViewModel, AppUser>(model, user);
        await _userManager.UpdateAsync(result);
        var roles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, roles);
        await _userManager.AddToRolesAsync(user, model.SelectedRoles.Select(s => s.text));

        return Ok("UpdateUser success");
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }

    }
  }
}