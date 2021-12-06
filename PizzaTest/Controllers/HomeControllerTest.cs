using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza4U.Controllers;
using Pizza4U.Handlers;
using Pizza4U.Models;
using System;
using System.Web.Mvc;

namespace PizzaTest.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void HomeController() {
            HomeController home = new HomeController();

            var view = home.Index() as ViewResult;

            Assert.IsNotNull(view);
            Assert.AreEqual("Index", view.ViewName);
        }

        [TestMethod]
        public void DBItems() {
            HomeController home = new HomeController();
            var view = home.Index() as ViewResult;
            Assert.IsNotNull(view.ViewBag.Items);
        }
    }
}
