using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdealSysApp.Controllers
{

    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult MyTest()
        {
            var result = "Your Post Worked!!!";
            return Json(result);
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Салом", "Дунё", "Yaxshimi" };
        }
    }
}
