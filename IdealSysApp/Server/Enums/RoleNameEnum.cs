using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Enums
{
  public enum RoleNameEnum
  {
    [Description("Administrator")]
    Admin,
    [Description("User")]
    User,
    [Description("Tester")]
    Tester
  }
}
