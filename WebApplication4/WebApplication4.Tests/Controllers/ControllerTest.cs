using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication4;
using WebApplication4.Controllers;
using WebApplication4.DAO;

namespace WebApplication4.Tests.Controllers
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void IndexCategoryAdvertisingGetAllIndexManagerNotNull()//Возвращает ли список категорий рекламы
        {
            ManagerController controller = new ManagerController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexMassMediaGetAllIndexMediabuinerNotNull()//Возвращает ли список СМИ
        {
            MediabuinerController controller = new MediabuinerController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexUserGetAllIndexAdministratorNotNull()//Возвращает ли список пользователей
        {
            ListUserController controller = new ListUserController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
