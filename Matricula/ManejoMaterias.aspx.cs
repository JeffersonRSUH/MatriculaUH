using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Objetos;

namespace Matricula
{
    public partial class ManejoMaterias : Page
    {
        private LnMaterias _lnMaterias;
        private LnCarreras _lnCarreras; // Instancia para manejar las carreras

        protected void Page_Load(object sender, EventArgs e)
        {
            _lnMaterias = new LnMaterias();
            _lnCarreras = new LnCarreras(); // Inicializar la instancia

            if (!IsPostBack)
            {
                LoadCarreras(); // Cargar las carreras
                LoadMaterias(); // Cargar las materias
            }
        }

        protected void LoadCarreras()
        {
            var carreras = _lnCarreras.ConsultaCarreras(0); // Obtén todas las carreras
            DropDownListCarrera.DataSource = carreras;
            DropDownListCarrera.DataTextField = "Carrera"; // Nombre visible en el DropDownList
            DropDownListCarrera.DataValueField = "IdCarrera"; // Valor almacenado en el DropDownList
            DropDownListCarrera.DataBind();
        }

        protected void LoadMaterias()
        {
            var materias = _lnMaterias.ConsultaMaterias(0, 0);
            GridViewMaterias.DataSource = materias;
            GridViewMaterias.DataBind();
        }

        protected void BtnCrearMateria_Click(object sender, EventArgs e)
        {
            var nuevaMateria = new oMateria
            {
                Carrera = new oCarrera
                {
                    IdCarrera = Convert.ToInt32(DropDownListCarrera.SelectedValue)
                },
                Materia = TxtMateria.Text,
                Creditos = Convert.ToInt32(TxtCreditos.Text)
            };

            _lnMaterias.CrearMateria(nuevaMateria);
            LoadMaterias();
        }

        protected void BtnActualizarMateria_Click(object sender, EventArgs e)
        {
            var materiaActualizada = new oMateria
            {
                IdMateria = Convert.ToInt32(HiddenFieldIdMateria.Value),
                Carrera = new oCarrera
                {
                    IdCarrera = Convert.ToInt32(DropDownListCarrera.SelectedValue)
                },
                Materia = TxtMateria.Text,
                Creditos = Convert.ToInt32(TxtCreditos.Text)
            };

            _lnMaterias.ActualizarMateria(materiaActualizada);
            LoadMaterias();
        }

        protected void GridViewMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMateria")
            {
                int idMateria = Convert.ToInt32(e.CommandArgument);
                var materia = _lnMaterias.ConsultaMaterias(0, idMateria).FirstOrDefault();

                if (materia != null)
                {
                    HiddenFieldIdMateria.Value = materia.IdMateria.ToString();
                    DropDownListCarrera.SelectedValue = materia.Carrera.IdCarrera.ToString();
                    TxtMateria.Text = materia.Materia;
                    TxtCreditos.Text = materia.Creditos.ToString(); // Cargar créditos
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
