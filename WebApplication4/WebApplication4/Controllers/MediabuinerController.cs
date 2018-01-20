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
    public class MediabuinerController : Controller
    {
        private DAO_category_advertising category_advertisingDAO = new DAO_category_advertising();
        private DAO_mass_media mass_mediaDAO = new DAO_mass_media();

        [Authorize(Roles = "Mediabuiner")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(mass_mediaDAO.GetAll());
        }
        [Authorize(Roles = "Mediabuiner")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Mediabuiner")]
        [HttpPost]
        public ActionResult Create(Mass_media st, string id)
        {
            return View(mass_mediaDAO.Add(st, id));
        }
        [Authorize(Roles = "Mediabuiner")]
        [HttpGet]
        public ActionResult Index_category_advertising()
        {
            return View(category_advertisingDAO.GetAll());
        }

        [Authorize(Roles = "Mediabuiner")]
        [HttpGet]
        public ActionResult Create_id_mass_media()
        {
            return View();
        }
        [Authorize(Roles = "Mediabuiner")]
        [HttpPost]
        public ActionResult Create_id_mass_media(Mass_media st, int id)
        {
            return View(category_advertisingDAO.AddMass_media(st, id));
        }

        [Authorize(Roles = "Mediabuiner")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View("Delete", mass_mediaDAO.Get(id));
        }
        [Authorize(Roles = "Mediabuiner")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}