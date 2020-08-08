using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shooping.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shooping.Models;
using Friends.Models.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shooping.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<person> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SignInManager<person> signInManager;

        public AccountController(UserManager<person> userManager,
                IWebHostEnvironment webHostEnvironment, SignInManager<person> signInManager)
        {
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
            this.signInManager = signInManager;
        }
        // GET: /<controller>/

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new person
                {
                    FullName = model.FullName,
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City,
                    PersonType=model.PersonType
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Json(true);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Json(false);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Json(true);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password
                    , model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (returnurl != null && Url.IsLocalUrl(returnurl))
                    {
                        return Redirect(returnurl);
                    }
                    else
                    {
                        return Json(true);
                    }
                }


                ModelState.AddModelError("", "Invalid Signin ");

            }
            return Json(false);

        }
      
      


    }
}
