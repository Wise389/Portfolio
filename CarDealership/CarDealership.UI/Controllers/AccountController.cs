using CarDealership.BLL;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }


        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private OperationManager operationManager = new OperationManager();

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [HttpGet]
        [Authorize(Roles = "admin, sales")]
        public ActionResult ChangePassword()
        {
           // var UserId = User.Identity.GetUserId();
            var user = User.Identity.GetUserId();
            ChangePasswordViewModel vm = new ChangePasswordViewModel();
            vm.UserId = user;
            return View(vm);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            UserManager.ChangePassword(vm.UserId, vm.Password, vm.ConfirmPassword);
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            // attempt to load the user with this password
            AppUser user = UserManager.Find(model.UserName, model.Password);
            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}