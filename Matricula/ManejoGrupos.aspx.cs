using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Logica;
using Objetos;

namespace Matricula
{
    public partial class ManejoGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMaterias();
                LoadHorarios();
                LoadEstados();
                LoadGrupos();
            }
        }

        private void LoadMaterias()
        {
            try
            {
                LnGrupos logica = new LnGrupos();
                DataTable materias = logica.ObtenerMaterias();
                ddlMateria.DataSource = materias;
                ddlMateria.DataTextField = "Materia";
                ddlMateria.DataValueField = "IdMateria";
                ddlMateria.DataBind();
                ddlMateria.Items.Insert(0, new ListItem("--Seleccionar Materia--", "0")); // Optional
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al cargar materias: {ex.Message}";
            }
        }

        private void LoadHorarios()
        {
            try
            {
                LnGrupos logica = new LnGrupos();
                DataTable horarios = logica.ObtenerHorarios();
                ddlHorario.DataSource = horarios;
                ddlHorario.DataTextField = "Horario";
                ddlHorario.DataValueField = "IdHorario";
                ddlHorario.DataBind();
                ddlHorario.Items.Insert(0, new ListItem("--Seleccionar Horario--", "0")); // Optional
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al cargar horarios: {ex.Message}";
            }
        }

        private void LoadEstados()
        {
            try
            {
                LnGrupos logica = new LnGrupos();
                DataTable estados = logica.ObtenerEstados();
                ddlEstado.DataSource = estados;
                ddlEstado.DataTextField = "EstadoGrupo";
                ddlEstado.DataValueField = "IdEstadoGrupo";
                ddlEstado.DataBind();
                ddlEstado.Items.Insert(0, new ListItem("--Seleccionar Estado--", "0")); // Optional
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al cargar estados: {ex.Message}";
            }
        }

        protected void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                oGrupo nuevoGrupo = new oGrupo
                {
                    NumeroGrupo = int.Parse(txtNumeroGrupo.Text),
                    Cupo = int.Parse(txtCupo.Text),
                    Materia = new oMateria { IdMateria = int.Parse(ddlMateria.SelectedValue) },
                    Horario = (Horario)Enum.Parse(typeof(Horario), ddlHorario.SelectedValue),
                    Estado = (EstadoGrupo)Enum.Parse(typeof(EstadoGrupo), ddlEstado.SelectedValue)
                };

                LnGrupos logica = new LnGrupos();
                int idGrupo = logica.CrearGrupo(nuevoGrupo);

                lblMessage.Text = $"Grupo creado con éxito. IdGrupo: {idGrupo}";
                LoadGrupos(); // Refresh the list of groups
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al crear el grupo: {ex.Message}";
            }
        }

        private void LoadGrupos()
        {
            try
            {
                LnGrupos logica = new LnGrupos();
                var grupos = logica.ObtenerGrupos();

                // Create a new list to store the data with a simple Materia property
                var gruposDisplay = grupos.Select(g => new
                {
                    g.IdGrupo,
                    g.NumeroGrupo,
                    g.Cupo,
                    g.Materia.Materia,
                    g.Horario,
                    g.Estado
                }).ToList();

                gvGrupos.DataSource = gruposDisplay;
                gvGrupos.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al cargar grupos: {ex.Message}";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
