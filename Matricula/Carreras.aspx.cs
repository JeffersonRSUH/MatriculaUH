using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Logica;
using Objetos;

namespace Matricula
{
    public partial class Carreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaCarreras();
        }

        protected void btnInsertaCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;


                LnCarreras negocios = new LnCarreras();

                var resultado = negocios.InsertarCarrera(nombre);

                if (resultado)
                {
                    CargaCarreras();
                }
                else {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No fue posible insertar el registro.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error: "+ex.Message+"');", true);
            }
        }

        private void CargaCarreras()
        {
            LnCarreras negocios = new LnCarreras();

            var listaCarreras = negocios.ConsultaCarreras(0);

            foreach (var item in listaCarreras)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");

                div.InnerHtml = "<p>IdCarrera: " + item.IdCarrera + ", nombre: " + item.Carrera + "</p>";


                divCarreras.Controls.Add(div);
            }


        }

        protected void btnUpdateCarrera_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}