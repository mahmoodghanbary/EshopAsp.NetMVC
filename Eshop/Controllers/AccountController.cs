using DataLayer;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                if (!db.Users.Any(u => u.Email == register.Email.Trim().ToLower()))
                {
                    Users user = new Users()
                    {
                        Email = register.Email.Trim().ToLower(),
                        password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                        ActiveCode = Guid.NewGuid().ToString(),
                        IsActive = false,
                        RegisterDate = DateTime.Now,
                        RoleID = 1,
                        UserName = register.UserName
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("Email", "کاربر با این ایمیل قبلا ثبت نام کرده است");
            }
            return View(register);
        }
        
        public ActionResult Login()
        {
            return View();
        }
    }
}