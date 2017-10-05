using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdealSysApp.Server.Controllers
{
  [Authorize(Policy = "ApiUser")]
  public class BaseController : Controller
  {
  }
}
