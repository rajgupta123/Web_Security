using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_Security.Models;

namespace Web_Security.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                //verify the credential
                if (loginModel.Username == "admin" && loginModel.Password == "ss")
                {
                    //Create the Security Context
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim(ClaimTypes.Role,"myadmin"),
                      new Claim(ClaimTypes.Role,"Raj"),

                    new Claim("Department","HR"),
                  new Claim(ClaimTypes.Role,"LMS"),
                     //add another claim
                     // new Claim("Admin","true"),
                     new Claim("Manager","true"),
                       new Claim("Cat","true"),
                       new Claim("Admin1","true"),
                        new Claim("Admin","true"),
                      
                     //add new claim for custom check
                     new Claim("EmployeeDate","2022-05-01")
                   
                     };
              
                var identity = new ClaimsIdentity(claims, "MyCookiesAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //create a Cookies
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = loginModel.RememberMe
                    };


                  await  HttpContext.SignInAsync("MyCookiesAuth", claimsPrincipal, authProperties);
                    if (!String.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home");

                    //return        RedirectToAction("Index","Home");
               

                }
            }
            return View();
        }

        public IActionResult Login1()
        {
            return View();
        }
        //Create access Denied Page
        public IActionResult AccessDenied()
        {
            return View();
        }

      
        public async Task< IActionResult> SignOutPage()
        {
            await HttpContext.SignOutAsync("MyCookiesAuth");
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> SignOutPage1()
        {
            await HttpContext.SignOutAsync("MyCookiesAuth");
            return RedirectToAction("Login");
        }
    }
}
