using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_CommentingChat.Models.ViewModels;
using Mvc_CommentingChat.Models;


namespace Mvc_CommentingChat.Controllers
{
    public class AccountController : Controller
    {

        private DemoContext _context = new DemoContext();
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterVM obj)
        {
            if (ModelState.IsValid)
            {


                bool Exist = _context.Users.Any(x => x.Name.ToLower() == obj.Name.ToLower());

                if (Exist)
                {
                    ModelState.AddModelError("", "This user is already Exist please Try another one Thanks!");
                    return View(obj);
                }

                bool ExistEmail = _context.Users.Any(x => x.Email.ToLower() == obj.Email.ToLower());

                if (ExistEmail)
                {
                    ViewBag.EmailError = "This Email is Already Exist please Change it";

                    return View(obj);
                }

                User objUser = new User();
                objUser.Name = obj.Name;
                objUser.Email = obj.Email;
                objUser.Password = obj.Password;
                objUser.ImgUrl = "";
                objUser.createdTime = DateTime.Now;

                _context.Users.Add(objUser);

                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            else
            {
                return View(obj);
            }


        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account/Login
        [HttpPost]
        public ActionResult Login(LoginVM obj)
        {
            if(ModelState.IsValid)
            {
                bool Exist = _context.Users.Any(x => x.Email.ToLower().Equals(obj.Email.ToLower()) && x.Password.ToLower().Equals(obj.Password.ToLower()));

                if(Exist)
                {
                    Session["UserID"] = _context.Users.Single(x => x.Email.Equals(obj.Email)).Id;

                    Session["UserImg"] = _context.Users.Single(x => x.Email.Equals(obj.Email)).ImgUrl;
                    return RedirectToAction("Index", "ChatRoom");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry User is not Exist.");
                    return View(obj);
                }

            }
            else
            {
                return View(obj);
            }
       
            
        }

        public ActionResult Logout()
        {
            Session["UserID"] = 0;

            return RedirectToAction("Login", "Account");
        }
    }
}