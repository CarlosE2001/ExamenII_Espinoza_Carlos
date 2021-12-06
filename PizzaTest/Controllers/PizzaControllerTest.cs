using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza4U.Controllers;
using System;
using System.Web.Mvc;

namespace PizzaTest.Controllers {
    [TestClass]
    public class PizzaControllerTest {
        [TestMethod]
        public void PizzaController() {
            PizzaController pizza = new PizzaController();
            var view = pizza.CustomPizza() as ViewResult;
            Assert.IsNotNull(view);
            Assert.AreEqual("CustomPizza", view.ViewName);
        }

        [TestMethod]
        public void PizzaControllerIngredients() {
            PizzaController pizza = new PizzaController();
            var view = pizza.CustomPizza() as ViewResult;
            Assert.IsNotNull(view.ViewBag.Ingredients);
        }

        [TestMethod]
        public void PizzaControllerIExtras() {
            PizzaController pizza = new PizzaController();
            var view = pizza.CustomPizza() as ViewResult;
            Assert.IsNotNull(view.ViewBag.Extras);
        }
    }
}
