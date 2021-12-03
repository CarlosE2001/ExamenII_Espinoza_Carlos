using Pizza4U.Handlers;
using Pizza4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza4U.Controllers {
    public class HomeController : Controller {

        private ItemHandler ItemHandler { get; set; }
        private CookieController cookieController { get; set; }

        public HomeController() {
            this.ItemHandler = new ItemHandler();
            this.cookieController = new CookieController();
        }

        public ActionResult Index() {
            ItemModel item = this.ItemHandler.GetItemById(1);
            ViewBag.Items = this.ItemHandler.GetAllItems();
            string cookieValue = this.cookieController.FetchCookieValue("cartItems");
            if(cookieValue == "-1") {
                this.cookieController.CreateCookie("cartItems", "", DateTime.Now.AddMinutes(30));
            }
            return View();
        }


        public JsonResult FetchItem(int id) {
            ItemModel item = this.ItemHandler.GetItemById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddItemToCart(int id) {
            string itemsIds = this.cookieController.FetchCookieValue("cartItems");
            if (itemsIds == "-1") {
                itemsIds = Convert.ToString(id) + ",";
                HttpCookie cart = this.cookieController.CreateCookie("cartItems", itemsIds, DateTime.Now.AddMinutes(30));
                Response.Cookies.Add(cart);
            } else {
                itemsIds += Convert.ToString(id) + ",";
                this.cookieController.UpdateCookie("cartItems", itemsIds);
            }
            return Json(itemsIds, JsonRequestBehavior.AllowGet);

        }

        public JsonResult FetchDataToCart(string itemsIds) {
            List<string> items = itemsIds.Split(',').ToList();
            List<ItemModel> itemsModels = this.ItemHandler.GetItemsFromIdList(items);
            return Json(itemsModels, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}