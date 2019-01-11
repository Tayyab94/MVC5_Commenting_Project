using Mvc_CommentingChat.Models;
using Mvc_CommentingChat.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_CommentingChat.Controllers
{
    public class UserController : Controller
    {
        DemoContext _context = new DemoContext();
        // GET: User
        public ActionResult UserProfile()
        {
            int UserID = Convert.ToInt32(Session["UserID"]);

            if (UserID <= 0)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(_context.Users.Find(UserID));
        }

        public ActionResult UploadImage(PitcherVM obj)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);

            if (UserID <= 0)
            {
                return RedirectToAction("Login", "Account");
            }

            var file = obj.Pitcher;

            User objU = _context.Users.Find(UserID);

            if(file!=null)
            {
                var extension = Path.GetExtension(file.FileName);

                string id_Extension = UserID + extension;

                string imgurl = "~/image/UserImages/" + id_Extension;

                objU.ImgUrl = imgurl;

                _context.Entry(objU).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();


                var path = Server.MapPath("~/image/UserImages/");

                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if((System.IO.File.Exists(path+id_Extension)))
                {
                    System.IO.File.Delete(path + id_Extension);
                }

                file.SaveAs(path + id_Extension);
            }

            return RedirectToAction("UserProfile"); 
        }
    }
}