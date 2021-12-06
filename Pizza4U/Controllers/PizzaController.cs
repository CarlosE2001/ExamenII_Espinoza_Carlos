using Pizza4U.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza4U.Controllers
{
    public class PizzaController : Controller
    {
        JsonParser parser { get; set; }

        public PizzaController() {
            this.parser = new JsonParser();
        }
        public ActionResult CustomPizza()
        {
            List<string> ingredients = new List<string>();
            List<string> extras = new List<string>();
            dynamic jsonCollection = this.parser.ParseFromJSON("Ingredients.json");
            foreach(var element in jsonCollection) {
                string name = element.Name;
                ingredients.Add(name);
            }

            jsonCollection = this.parser.ParseFromJSON("Extras.json");
            foreach (var element in jsonCollection) {
                string name = element.Name;
                extras.Add(name);
            }
            ViewBag.Ingredients = ingredients;
            ViewBag.Extras = extras;
            return View("CustomPizza");
        }
    }
}