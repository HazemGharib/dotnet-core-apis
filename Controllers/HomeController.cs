using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_apis.Controllers
{
    [Route("[controller]/[Action]")]
    public class HomeController : Controller
    {
        // GET Home/Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
