using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Security.Controllers
{
    [Authorize(Policy ="OnlyCategory")]
    public class CategoryController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
