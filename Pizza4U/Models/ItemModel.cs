using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizza4U.Models {
    public class ItemModel {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
    }
}