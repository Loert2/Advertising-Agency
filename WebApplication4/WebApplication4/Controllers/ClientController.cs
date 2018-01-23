using WebApplication4.DAO;
using WebApplication4.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.DAO
{
    public class ClientController : Controller
    {
       
        private DAO_client clientDAO = new DAO_client();
        private DAO_category_advertising category_advertisingDAO = new DAO_category_advertising();
        // GET: Client
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(category_advertisingDAO.GetAll());
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Create(string id)
        {
            return View();
        }
        
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Create(Client collection)
        {
            if (clientDAO.Add(collection, User.Identity.GetUserId()))
            {
                return RedirectToAction("Message", "Message", new { st = "Информация пользователя добавлена!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
            }
        }
    }
}