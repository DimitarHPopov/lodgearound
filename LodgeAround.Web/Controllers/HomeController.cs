using LodgeAround.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LodgeAround.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginForm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);

                        return RedirectToAction("Index", "Account");

                    }
                    else
                    {
                        ModelState.AddModelError("LoginError", "Потребителско име или парола са грешни.");
                    }
                }
            }
            catch (Exception ex)
            {

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}