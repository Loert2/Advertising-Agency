using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Message(string st)
        {
            ViewBag.Message = st;
            return View();
        }
        // GET: Error
        public ActionResult Error(string st)
        {
            ViewBag.Message = st;
            return View();
        }
    }
}