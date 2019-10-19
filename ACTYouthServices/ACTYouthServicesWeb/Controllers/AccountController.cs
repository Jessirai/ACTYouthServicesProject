using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ACTYouthServicesWeb.Models;


namespace ACTYouthServicesWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                
                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(System.Web.Configuration.WebConfigurationManager.AppSettings["AdminPassword"]);
                if (passwordHasher.VerifyHashedPassword(hashedPassword, model.Password) == PasswordVerificationResult.Success) {

                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                    var claims = new System.Collections.Generic.List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "Admin")
                    };
                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, identity);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }


        #region Helpers

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}
