using WebApplication4.DAO;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ListMediabuinerController : Controller
    {
        private DAO_mediabuiner mediabuinerDAO = new DAO_mediabuiner();
        
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            return View(mediabuinerDAO.GetAll());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult CreateInfo(string id)
        {
            return View();
        }
       
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult CreateInfo(Mediabuiner collection, string id)
        {
            if (mediabuinerDAO.Add(collection, id))
            {
                return RedirectToAction("Message", "Message", new { str = "Личная информация добавлена!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }

    }
}