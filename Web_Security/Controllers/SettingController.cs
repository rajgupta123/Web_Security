using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Security.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class SettingController : Controller
    {
        public IActionResult SettingPage()
        {
            return View();
        }
    }
}
