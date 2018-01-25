using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChapterB2B
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Session_Click(object sender, EventArgs e)
        {
            Session["User"] = 1;
            Response.Redirect("~/Test2.aspx");
        }

        protected void btn_Admin_Click(object sender, EventArgs e)
        {
            Session["User"] = 1;
            Session["Role"] = "Administrator";
            Response.Redirect("~/Test2.aspx");
        }
    }
}