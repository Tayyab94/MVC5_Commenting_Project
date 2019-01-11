using Mvc_CommentingChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Mvc_CommentingChat.Models.ViewModels;

namespace Mvc_CommentingChat.Controllers
{
    public class ChatRoomController : Controller
    {
        private DemoContext _context = new DemoContext();
        // GET: ChatRoom
        public ActionResult Index()
        {
            int UserID = Convert.ToInt32(Session["UserID"]);

            if (UserID <= 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var CommentList = _context.Comments.Include(x => x.Replies).OrderByDescending(x=>x.createdTime).ToList();
            return View(CommentList);
        }

        public ActionResult ReplayComment(ReplayVM obj)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);

            if(UserID<=0)
            {
                return RedirectToAction("Login", "Account");
            }

            Replay replay = new Replay();

            replay.UserId = UserID;
            replay.CommentId = obj.CommentID;
            replay.Text = obj.Replay;
            replay.createdTime = DateTime.Now;

            _context.Replays.Add(replay);
            _context.SaveChanges();

            return RedirectToAction("Index", "ChatRoom");
        }

        [HttpPost]
        public ActionResult PostComment(string CommentText)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);

            if (UserID <= 0)
            {
                return RedirectToAction("Login", "Account");
            }

            Comment c = new Comment();

            c.UserId = UserID;
            c.Text = CommentText;
            c.createdTime = DateTime.Now;

            _context.Comments.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index", "ChatRoom");
        }


    }
}