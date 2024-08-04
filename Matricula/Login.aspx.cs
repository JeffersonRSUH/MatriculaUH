using Logica;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matricula
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            try
            {
                LnUsuario logic = new LnUsuario();
                List<oUsuario> users = logic.AutenticaUsuario(username, password);

                if (users.Count > 0)
                {
                    // User authenticated successfully
                    oUsuario authenticatedUser = users[0];

                    // Redirect based on role
                    if (authenticatedUser.idRol == 1)
                    {
                        // Redirect to Dashboard.aspx for Administrador role
                        Response.Redirect("AdminDashboard.aspx");
                    }
                    else if (authenticatedUser.idRol == 2)
                    {
                        // Redirect to Matriculas.aspx for Usuario role
                        Response.Redirect("StudentDashboard.aspx");
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Role not recognized.";
                    }
                }
                else
                {
                    // Authentication failed
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}