using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matricula
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMatricula_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManejoMatricula.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["studentUser"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}