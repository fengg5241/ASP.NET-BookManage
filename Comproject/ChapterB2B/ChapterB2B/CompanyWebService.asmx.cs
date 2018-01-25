
using ChapterB2B.SupplierServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ChapterB2B
{
    /// <summary>
    /// Summary description for CompanyWebService
    /// </summary>
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CompanyWebService : System.Web.Services.WebService
    {
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public SupplierServiceReference.Product[] getAllBooks()
        {
            SupplierServiceClient client = new SupplierServiceClient();
            return client.getAllBooks();
        }

        [WebMethod]
        public void purchaseOrder(PurchaseOrder order)
        {
           Product[] books = order.bookArray;
            foreach (Product book in books)
            {

                DateTime time = DateTime.Now;
                String sqlStr = "INSERT INTO CustomerOrder( CompanyID, productId, productQty, status,orderNo)" +
                "VALUES(" + 1 + "," + book.id + "," +
                book.qty + ","+3+"," + order.orderNo + ") ";
                SqlConnection sqlconnection = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlStr;
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                cmd.ExecuteNonQuery();
                sqlconnection.Close();
            }

            SupplierServiceClient client = new SupplierServiceClient();
           client.purchaseOrderFromCompany(order);

        }
    }
}
