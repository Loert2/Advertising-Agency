using Microsoft.AspNet.Identity;
using WebApplication4.DAO;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ManagerController : Controller
    {
       
        private DAO_category_advertising category_advertisingDAO = new DAO_category_advertising();


        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(category_advertisingDAO.GetAll());
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Create(Category_advertising st, string id)
        {
            return View(category_advertisingDAO.Add(st, id));
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View("Delete", category_advertisingDAO.Get(id));
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}