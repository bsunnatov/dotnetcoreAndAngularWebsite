using IdealSysApp.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Filters
{
  public class CustomAuthAttribute : AuthorizeAttribute
  {
    public CustomAuthAttribute(RoleNameEnum[] roleNames)
    {
      this.Roles = string.Join(",", roleNames.Select(s => s.GetEnumDescription()));
    }
  }
}
