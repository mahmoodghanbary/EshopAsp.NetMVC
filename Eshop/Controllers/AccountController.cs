using DataLayer;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshop.Controllers
{
    public class AccountController : Controller
    {
        MyComputer_DBEntities db = new MyComputer_DBEntities();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {

            }
            return View(register);
        }
        
        public ActionResult Login()
        {
            return View();
        }
    }
}