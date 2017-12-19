using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCTest.WebApp.Models;
using System.Collections.Generic;
using MVCTest.IRepository;

namespace MVCTest.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // Info.    
            return this.View();
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
                if (userRepository.VerifyUser(model.UserName, model.Password))
                {
                    this.SignInUser(model.UserName, false);
                    this.RedirectToLocal(returnUrl);
                }
            }
            return View(model);
        }
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var owinContext = Request.GetOwinContext();
            var authenticationManager = owinContext.Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private void SignInUser(string userName, bool isPersistent)
        {
            try
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userName));
                var claimIndentites = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var owinContext = Request.GetOwinContext();
                var authenticationManager = owinContext.Authentication;

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIndentites);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>  
        /// Redirect to local method.    
        /// </summary>  
        /// <param name="returnUrl">Return URL parameter.</param>  
        /// <returns>Return redirection action</returns>  
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }
    }
}