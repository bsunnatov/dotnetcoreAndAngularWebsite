using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdealSysApp.Helpers.Constants.Strings;

namespace IdealSysApp.Services
{
    public class UserResolverService: IUserResolverService
  {
    private readonly IHttpContextAccessor _context;
    private readonly UserManager<AppUser> _userManager;
    public UserResolverService(IHttpContextAccessor context, UserManager<AppUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }
    public async Task<AppUser> GetUser()
    {
      return await _userManager.FindByNameAsync(_context.HttpContext.User?.Identity?.Name);
    }
    public string GetUserId()
    {
      string userId = null;
      if (_context != null && _context.HttpContext != null && _context.HttpContext.User != null)
      {
        userId = _context.HttpContext.User.FindFirst(JwtClaimIdentifiers.Id)?.Value;
      }
      return userId;
    }
  }
  public interface IUserResolverService
  {
    string GetUserId();
    Task<AppUser> GetUser();
  }
}
