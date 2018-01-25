using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChapterB2B.Model
{
    public class CustomerOrder
    {
        public DateTime orderDate { get; set; }
        public decimal totalAmount { get; set; }
        public string companyName { get; set; }

        public List<Product> productList { get; set; }
        public int status { get; set; }
        public int orderNo { get; set; }
    }
}