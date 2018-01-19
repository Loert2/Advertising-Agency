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
    public class OrderController : Controller
    {
        private DAO_order orderDAO = new DAO_order();

        // GET: Order
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult IndexClient(string id)
        {
            return View(orderDAO.GetAllClient(id));
        }

        // GET: Order
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult IndexManager(string id)
        {
            return View(orderDAO.GetAllManager(id));
        }

        // GET: Order/Create
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Create(Order obj, int id_ca, string submitButton)
        {
            string id = User.Identity.GetUserId();
            obj.Id_category_advertising = id_ca;
            switch (submitButton)
            {
                case "Отправить":
                    if (orderDAO.Add(obj, id, "Отправлен"))
                    {
                        return RedirectToAction("Message", "Message", new { st = "Заявка отправлена!" });
                    }
                    else
                    {
                        return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
                    }
                case "Сохранить как черновик":
                    if (orderDAO.Add(obj, id, "Черновик"))
                    {
                        return RedirectToAction("Message", "Message", new { st = "Заказ сохранен как черновик!" });
                    }
                    else
                    {
                        return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
                    }
                default:
                    return (View());
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Decline(int idAp)
        {
            if (orderDAO.Decline(idAp))
            {
                return RedirectToAction("Message", "Message", new { st = "Заказ отклонен!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
            }
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListManager/Edit/
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Edit(int id, Order collection)
        {
            collection.Id_order = id;
            if (orderDAO.Update(id, collection))
            {
                return RedirectToAction("Message", "Message", new { st = "Обновление прошло успешно!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
            }
        }

        // GET: Order/Delete/
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View("Delete", orderDAO.Get(id));
        }

        // POST: Order/Delete/
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (orderDAO.Delete(id))
            {
                return RedirectToAction("Message", "Message", new { st = "Удаление прошло успешно!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
            }
        }

        // GET: Order/Send/
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Send(int id)
        {
            return View("Send", orderDAO.Get(id));
        }

        // POST: Order/Send/
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Send(int id, FormCollection collection)
        {
            if (orderDAO.Send(id))
            {
                return RedirectToAction("Message", "Message", new { st = "Вы отправили заказ!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { st = "Произошла ошибка!" });
            }
        }
    }
}