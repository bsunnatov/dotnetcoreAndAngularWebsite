using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.ViewModels
{
    public class UserViewModel
    {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string[] Roles { get; set; }
    public string[] CheckedRoleNames { get; set; }
  }
}
