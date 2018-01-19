using WebApplication4.DAO;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ListManagerController : Controller
    {
        private DAO_manager managerDAO = new DAO_manager();
       
        // GET: ListManager
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            return View(managerDAO.GetAll());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult CreateInfo(string id)
        {
            return View();
        }

        // GET: Manager
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult CreateInfo(Manager collection, string id)
        {
            if (managerDAO.Add(collection, id))
            {
                return RedirectToAction("Message", "Message", new { st = "Личная информация добавлена!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
            }
        }

    }
}