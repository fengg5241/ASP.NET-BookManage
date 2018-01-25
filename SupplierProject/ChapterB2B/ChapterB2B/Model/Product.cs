using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChapterB2B.Model
{
    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int qty { get; set; }

        public decimal price { get; set; }
    }
}