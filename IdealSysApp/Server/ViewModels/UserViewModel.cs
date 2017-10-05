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
    public string[] RoleIds { get; set; }
    public SelectViewModel[] SelectedRoles { get; set; }
  }
  public class SelectViewModel
  {
    public string id { get; set; }
    public string text { get; set; }
  }

}
