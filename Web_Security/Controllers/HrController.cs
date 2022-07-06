using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Security.Controllers
{
    [Authorize(Policy = "MustBelondToHrDepartment")]
    public class HrController : Controller
    {
        public IActionResult HumanResourcePage()
        {
            return View();
        }
    }
}
