using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IdealSysApp.Models.Entities;
using IdealSysApp.Auth;
using Newtonsoft.Json;
using IdealSysApp.Models;
using Microsoft.Extensions.Options;
using IdealSysApp.ViewModels;
using IdealSysApp.Helpers;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdealSysApp.Data;

namespace IdealSysApp.Controllers
{
  [Route("api/[controller]")]
  public class AuthController : Controller
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtFactory _jwtFactory;
    private readonly JsonSerializerSettings _serializerSettings;
    private readonly JwtIssuerOptions _jwtOptions;
    private readonly ILogger<AuthController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public AuthController(UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, ILogger<AuthController> logger, ApplicationDbContext appDbContext)
    {
      _userManager = userManager;
      _userManager.Users.Include(p => p.Roles);
      _jwtFactory = jwtFactory;
      _jwtOptions = jwtOptions.Value;
      _logger = logger;
      _serializerSettings = new JsonSerializerSettings
      {
        Formatting = Formatting.Indented
      };
      _appDbContext = appDbContext;
    }

    // POST api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
    {
     
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
      if (identity == null)
      {
        return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
      }

      // Serialize and return the response
      var response = new
      {
        id = identity.Claims.Single(c => c.Type == "id").Value,
        auth_token = await _jwtFactory.GenerateEncodedToken(credentials.UserName, identity),
        expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
        userName=identity.Name
      };

      var json = JsonConvert.SerializeObject(response, _serializerSettings);
      return new OkObjectResult(json);
    }

    private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
    {
      if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
      {
        // get the user to verifty
        var userToVerify = await _userManager.FindByNameAsync(userName);
       
        if (userToVerify != null)
        {
          // check the credentials  
          if (await _userManager.CheckPasswordAsync(userToVerify, password))
          {
            var r = _jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id);
        
            foreach (var item in await _userManager.GetRolesAsync(userToVerify))
            {
              r.AddClaim(new Claim("roles", item));
            }
         
            return await Task.FromResult(r);
          }
        }
      }

      // Credentials are invalid, or account doesn't exist
      return await Task.FromResult<ClaimsIdentity>(null);
    }
  }
}
