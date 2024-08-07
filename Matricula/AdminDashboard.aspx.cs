using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matricula
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        private Logica.LnEstudiante logica = new Logica.LnEstudiante();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStudentManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManejoEstudiantes.aspx");
        }

        protected void btnCarreras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carreras.aspx");
        }

        protected void btnSubjectManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManejoMaterias.aspx");
        }

        protected void btnGroupManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManejoGrupos.aspx");
        }
    }
}