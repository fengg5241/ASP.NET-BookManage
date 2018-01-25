using ChapterB2B.Model;
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
    /// Summary description for SupplierWebService
    /// </summary>
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SupplierWebService : System.Web.Services.WebService
    {
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod(EnableSession = true)]
        public List<CustomerOrder> showOrderList()
        {
            string sqlStr = "select * from CustomerOrder";

            SqlConnection sqlconnection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = sqlStr;
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            reader = cmd.ExecuteReader();

            List<CustomerOrder> customerOrders = new List<CustomerOrder>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustomerOrder customerOrder = new CustomerOrder();
                    //customerOrder.LightID = reader.GetInt32(0);
                    customerOrder.orderDate = reader.GetDateTime(1);
                    customerOrder.totalAmount = reader.GetDecimal(2);
                    customerOrder.companyName = "company";
                    List<Product> productList = new List<Product>();
                    Product p = new Product();
                    p.productName = "productName";
                    p.qty = reader.GetInt32(5);
                    productList.Add(p);
                    customerOrder.productList = productList;


                    customerOrder.status = reader.GetInt32(6);
                    customerOrder.orderNo = reader.GetInt32(7);
                    customerOrders.Add(customerOrder);
                }
            }

            reader.Close();
            sqlconnection.Close();

            return customerOrders;
        }

        
    }
}
