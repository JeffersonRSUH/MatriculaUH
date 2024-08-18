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
        private LnCarreras _lnCarreras;
        protected void Page_Load(object sender, EventArgs e)
        {
            _lnCarreras = new LnCarreras();
            if (!IsPostBack)
            {
                CargaCarreras();
            }
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
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No fue posible insertar el registro.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error: " + ex.Message + "');", true);
            }
            txtNombre.Text = "";
        }

        private void CargaCarreras()
        {
            LnCarreras negocios = new LnCarreras();
            var listaCarreras = negocios.ConsultaCarreras(0);

            var dataSource = listaCarreras.Select(item => new
            {
                item.IdCarrera,
                item.Carrera,
                CantidadEstudiantes = negocios.ObtenerCantidadEstudiantes(item.IdCarrera),
                CantidadMaterias = negocios.ObtenerCantidadMaterias(item.IdCarrera)
            }).ToList();

            gvCarreras.DataSource = dataSource;
            gvCarreras.DataBind();
        }
        protected void BtnActualizarCarrera_Click(object sender, EventArgs e)
        {
            var carreraActualizada = new oCarrera
            {
                IdCarrera = Convert.ToInt32(HiddenFieldIdCarrera.Value),
                Carrera = TxtNombreCarrera.Text // Update the career name with the value from the TextBox
            };

            _lnCarreras.ActualizarCarrera(carreraActualizada);
            CargaCarreras(); // Refresh the list of careers
        }
        protected void gvCarreras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCarrera")
            {
                int idCarrera = Convert.ToInt32(e.CommandArgument);
                var carrera = _lnCarreras.ConsultaCarreras(idCarrera).FirstOrDefault();

                if (carrera != null)
                {
                    HiddenFieldIdCarrera.Value = carrera.IdCarrera.ToString();
                    TxtNombreCarrera.Text = carrera.Carrera; // Populate the TextBox with the career name
                }
            }
        }

        protected void gvCarreras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idCarrera = Convert.ToInt32(gvCarreras.DataKeys[e.NewEditIndex].Value);
            var carrera = _lnCarreras.ConsultaCarreras(idCarrera).FirstOrDefault();

            if (carrera != null)
            {
                HiddenFieldIdCarrera.Value = carrera.IdCarrera.ToString();
                TxtNombreCarrera.Text = carrera.Carrera; // Populate the TextBox with the career name
            }

            gvCarreras.EditIndex = e.NewEditIndex; // Set the edit index if you want to put the row into edit mode
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
