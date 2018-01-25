using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChapterB2B
{
    public partial class nosidebar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Lb_Login.Visible = true;
                    Lb_Logout.Visible = false;
                    Lb_Login.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d52349");
                }
                else if (Session["User"] != null && Convert.ToInt32(Session["User"]) > 0)
                {
                    Lb_Logout.Visible = true;
                    Lb_Login.Visible = false;
                    Lb_Login.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d52349");
                    nav_profile.Visible = true;
                    if (Session["Role"] != null && Session["Role"].Equals("Administrator"))
                    {
                        admin_panel.Visible = true;
                    }
                    else
                    {
                        admin_panel.Visible = false;
                    }
                }
            }
        }

        //This is to change the red bar on selected nav.
        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "current" : "";
        }
        //On Click For Login
        protected void Lb_Login_Click(object sender, EventArgs e)
        {
            Lb_Login.ForeColor = System.Drawing.ColorTranslator.FromHtml("#fff");
            Response.Redirect("~/Login/Login.aspx");
        }
        //On Click For Logout
        protected void Lb_Logout_Click(object sender, EventArgs e)
        {
            Lb_Logout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#fff");
            Session.Clear();
            Response.Redirect("~/Test.aspx");
        }

    }
}