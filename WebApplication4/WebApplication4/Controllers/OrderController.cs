﻿using Microsoft.AspNet.Identity;
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
        
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult IndexClient(string id)
        {
            return View(orderDAO.GetAllClient(id));
        }
        
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult IndexManager(string id)
        {
            return View(orderDAO.GetAllManager(id));
        }
        
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
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
                        return RedirectToAction("Message", "Message", new { str = "Заявка отправлена!" });
                    }
                    else
                    {
                        return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
                    }
                case "Сохранить как черновик":
                    if (orderDAO.Add(obj, id, "Черновик"))
                    {
                        return RedirectToAction("Message", "Message", new { str = "Заказ сохранен как черновик!" });
                    }
                    else
                    {
                        return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
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
                return RedirectToAction("Message", "Message", new { str = "Заказ отклонен!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Edit(int id, Order collection)
        {
            collection.Id_order = id;
            if (orderDAO.Update(id, collection))
            {
                return RedirectToAction("Message", "Message", new { str = "Обновление прошло успешно!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }
        
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View("Delete", orderDAO.Get(id));
        }
        
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (orderDAO.Delete(id))
            {
                return RedirectToAction("Message", "Message", new { str = "Удаление прошло успешно!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }
        
        [Authorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Send(int id)
        {
            return View("Send", orderDAO.Get(id));
        }
        
        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Send(int id, FormCollection collection)
        {
            if (orderDAO.Send(id))
            {
                return RedirectToAction("Message", "Message", new { str = "Вы отправили заказ!" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult CreateAnswer()
        {
            return View();
        }
        
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult CreateAnswer(Order obj, int idAp)
        {
            string id = User.Identity.GetUserId();
            obj.Status = "Обработан";
            if (orderDAO.AddAnswer(obj, id, idAp))
            {
                return RedirectToAction("Message", "Message", new { str = "Заказ обработан" });
            }
            else
            {
                return RedirectToAction("Error", "Message", new { str = "Произошла ошибка!" });
            }
        }
    }
}