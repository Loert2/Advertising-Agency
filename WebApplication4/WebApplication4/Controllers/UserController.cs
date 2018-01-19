using Microsoft.AspNet.Identity;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "Administrator,Manager,Mediabuiner,Client")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
            return View(currentUser);
        }

        // POST: User/Edit/5
        [Authorize(Roles = "Administrator,Manager,Mediabuiner,Client")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}