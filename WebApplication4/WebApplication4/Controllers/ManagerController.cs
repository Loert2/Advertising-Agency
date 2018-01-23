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
            if (category_advertisingDAO.Add(st, id))
            {
                return RedirectToAction("Message", "Message", new { str = "Добавлена категория рекламы" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
            
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View("Delete", category_advertisingDAO.Get(id));
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (category_advertisingDAO.Delete(id))
            {
                return RedirectToAction("Message", "Message", new { str = "Категория рекламы успешно удалена" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }            
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Edit(int id, Category_advertising collection)
        {           
            if (category_advertisingDAO.Update(id, collection))
            {
                return RedirectToAction("Message", "Message", new { str = "Обновление прошло успешно" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }
    }
}