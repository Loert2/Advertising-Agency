using WebApplication4.DAO;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ListUserController : Controller
    {
        private DAO_user userDAO = new DAO_user();
        
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(userDAO.GetAll());
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            return View(userDAO.Get(id));
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View();
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(string id, AspNetRoles collection, string submitButton)
        {
            switch (submitButton)
            {
                case "Добавить":
                    if (userDAO.UpdateRoles(id, collection))
                    {
                        return RedirectToAction("Message", "Message", new { str = "Добавление роли прошло успешно!" });
                    }
                    else
                    {
                        return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
                    }
                case "Удалить":
                    if (userDAO.DeleteRoles(id, collection))
                    {
                        return RedirectToAction("Message", "Message", new { str = "Удаление прошло успешно!" });
                    }
                    else
                    {
                        return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
                    }
                default:
                    return (View());
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View("Delete", userDAO.Get(id));
        }

        // POST: List_user/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (userDAO.Delete(id))
            {
                return RedirectToAction("Message", "Message", new { str = "Удаленее пользователя прошло успешно!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }
    }
}