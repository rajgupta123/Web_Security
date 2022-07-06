using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Security.Controllers
{
    [Authorize(Roles = "Raj")]
    public class RoleBaseController : Controller
    {
        public IActionResult RajIndex()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Display()
        {
            return View();
        }
    }
}
