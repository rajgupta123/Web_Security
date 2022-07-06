using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Security.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public IActionResult DisplayProduct()
        {
            return View();
        }
    }
}
