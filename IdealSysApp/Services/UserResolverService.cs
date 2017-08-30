using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        var userName = _userManager.GetUserId(_context.HttpContext.User);
        _userManager.FindByNameAsync(userName).ContinueWith(s=> {
          userId = s.Result.Id;
        }).Wait();
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
