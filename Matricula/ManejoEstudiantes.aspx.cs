using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matricula
{
    public partial class ManejoEstudiantes : System.Web.UI.Page
    {

        private LnEstudiante logica = new LnEstudiante();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllStudents();
                CargarCarreras();
            }
        }

        private void LoadAllStudents()
        {
            try
            {
                GridViewStudents.DataSource = logica.ListarEstudiantes();
                GridViewStudents.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception
                lblStudentInfo.Text = "Error loading students: " + ex.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int idEstudiante;
                if (int.TryParse(txtStudentId.Text, out idEstudiante))
                {
                    var student = logica.BuscarEstudiantePorId(idEstudiante);
                    if (student != null)
                    {
                        lblStudentInfo.Text = $"ID: {student.IdEstudiante}, Name: {student.Nombre}, " +
                            $"Last Name: {student.ApellidoPaterno} {student.ApellidoMaterno}, " +
                            $"Identification: {student.Identificacion}, " +
                            $"Birth Date: {student.FechaNacimiento}, Entry Date: {student.FechaIngreso}, " +
                            $"State: {student.Estado}, ID Type: {student.TipoIdentificacion}, Career: {student.Carrera.IdCarrera}";
                    }
                    else
                    {
                        lblStudentInfo.Text = "Student not found.";
                    }
                }
                else
                {
                    lblStudentInfo.Text = "Please enter a valid Student ID.";
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                lblStudentInfo.Text = "Error searching student: " + ex.Message;
            }
        }

        private void CargarCarreras()
        {
            try
            {
                LnCarreras negocios = new LnCarreras();
                var carreras = negocios.ConsultaCarreras(0); // 0 or any default ID for getting all records

                ddlCarrera.DataSource = carreras;
                ddlCarrera.DataTextField = "Carrera"; // Display name in dropdown
                ddlCarrera.DataValueField = "IdCarrera"; // Value of selected item
                ddlCarrera.DataBind();

                // Add a default item
                ddlCarrera.Items.Insert(0, new ListItem("Seleccione una carrera", "0"));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error al cargar las carreras: " + ex.Message + "');", true);
            }
        }

        protected void btnCrearEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellidoPaterno = txtApellidoPaterno.Text;
                string apellidoMaterno = txtApellidoMaterno.Text;
                int identificacion = int.Parse(txtIdentificacion.Text);
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                DateTime fechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                int idEstadoEstudiante = int.Parse(ddlEstado.SelectedValue);
                int idTipoIdentificacion = int.Parse(ddlTipoIdentificacion.SelectedValue);
                int idCarrera = int.Parse(ddlCarrera.SelectedValue);

                LnEstudiante negocios = new LnEstudiante();
                int idEstudiante;
                bool resultado = negocios.CrearEstudiante(nombre, apellidoPaterno, apellidoMaterno, identificacion, fechaNacimiento, fechaIngreso, idEstadoEstudiante, idTipoIdentificacion, idCarrera, out idEstudiante);

                if (resultado)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Estudiante creado exitosamente con ID: " + idEstudiante + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No fue posible crear el estudiante.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error: " + ex.Message + "');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}