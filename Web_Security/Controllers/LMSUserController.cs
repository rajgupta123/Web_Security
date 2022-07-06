using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Security.Controllers
{

    [Authorize(Roles ="LMS")]
    public class LMSUserController : Controller
    {
        [AllowAnonymous]
   
        public IActionResult showallUsers()
        {
            return View();
        }
        public IActionResult myuser()
        {
            return View();
        }
    }
}
