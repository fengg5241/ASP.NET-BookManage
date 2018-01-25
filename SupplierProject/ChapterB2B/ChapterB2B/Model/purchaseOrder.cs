using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChapterB2B.Model
{
    public class PurchaseOrder
    {
        public List<Product> bookArray { get; set; }

        public DateTime orderDate { get; set; }

        public int orderNo { get; set; }

        public int companyId { get; set; }

    }
}