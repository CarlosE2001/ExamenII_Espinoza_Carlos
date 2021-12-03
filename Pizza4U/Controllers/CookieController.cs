﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza4U.Controllers {
    public class CookieController : Controller {
        public CookieController() {

        }

        public HttpCookie CreateCookie(string cookieName, string cookieValue, DateTime expirationTime) {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = cookieValue;
            cookie.Expires = expirationTime;
            return cookie;
        }

        public HttpCookie UpdateCookie(string cookieName, string value) {
            HttpCookie cookie = null;
            string currentValue = FetchCookieValue(cookieName);

            if (currentValue == "0") {
                cookie = CreateCookie(cookieName, value, DateTime.Now.AddHours(1));
            } else {
                cookie = Request.Cookies[cookieName];
                cookie.Value = value;
            }
            return cookie;
        }

        public void DeleteCookie(string cookieName) {
            Request.Cookies[cookieName].Expires = DateTime.Now.AddSeconds(1);
        }


        public string FetchCookieValue(string cookieName) {
            string value = null;
            try {
                HttpCookie cookie = Request.Cookies[cookieName];
                value = cookie.Value;
            } catch {
                value = "-1";
            }
            
            return value;
        }
    }
}