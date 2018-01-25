using ChapterB2B.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SupplierWCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SupplierService : ISupplierService
    {
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Product> getAllBooks()
        {
            List<Product> books = new List<Product>();
            string sqlStr = "select * from Product";

            SqlConnection sqlconnection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = sqlStr;
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product book = new Product();
                    book.id = reader.GetInt32(0);
                    book.productName = reader.GetString(1);
                    book.price = reader.GetDecimal(3);
                    
                    books.Add(book);
                }
            }

            reader.Close();
            sqlconnection.Close();


            return books;
        }

        public void purchaseOrderFromCompany(PurchaseOrder order)
        {
            List<Product> books = order.bookArray;

            foreach (Product book in books)
            {
                DateTime time = DateTime.Now;
                String sqlStr = "INSERT INTO CustomerOrder( CompanyID, productId, productQty, status,orderNo)" +
                "VALUES(" + 1 + "," + book.id + "," +
                book.qty + "," + 3 + "," + order.orderNo + ") ";
                SqlConnection sqlconnection = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlStr;
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                cmd.ExecuteNonQuery();
                sqlconnection.Close();
            }
  
        }

    }
}
