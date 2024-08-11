using System;
using System.Collections.Generic;
using Logica;
using Objetos;

namespace Matricula
{
    public partial class ManejoMatricula : System.Web.UI.Page
    {
        private LnMatricula _lnMatricula = new LnMatricula();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch and display students
                List<oEstudiante> estudiantes = _lnMatricula.ObtenerEstudiantes();
                ltEstudiantes.Text = GenerateEstudiantesHtml(estudiantes);

                // Fetch and display groups
                List<oGrupo> grupos = _lnMatricula.ObtenerGrupos();
                ltGrupos.Text = GenerateGruposHtml(grupos);
            }
        }

        private string GenerateEstudiantesHtml(List<oEstudiante> estudiantes)
        {
            string html = "<table border='1'><tr><th>ID</th><th>Nombre</th><th>Apellido Paterno</th><th>Apellido Materno</th><th>Identificación</th></tr>";
            foreach (var estudiante in estudiantes)
            {
                html += $"<tr><td>{estudiante.IdEstudiante}</td><td>{estudiante.Nombre}</td><td>{estudiante.ApellidoPaterno}</td><td>{estudiante.ApellidoMaterno}</td><td>{estudiante.Identificacion}</td></tr>";
            }
            html += "</table>";
            return html;
        }

        private string GenerateGruposHtml(List<oGrupo> grupos)
        {
            string html = "<table border='1'><tr><th>ID Grupo</th><th>Número Grupo</th><th>Materia</th><th>Horario</th><th>Estado</th></tr>";
            foreach (var grupo in grupos)
            {
                html += $"<tr><td>{grupo.IdGrupo}</td><td>{grupo.NumeroGrupo}</td><td>{grupo.Materia.Materia}</td><td>{grupo.Horario}</td><td>{grupo.Estado}</td></tr>";
            }
            html += "</table>";
            return html;
        }

        protected void btnMatricular_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtEstudianteId.Text, out int idEstudiante) && int.TryParse(txtGrupoId.Text, out int idGrupo))
                {
                    _lnMatricula.Matricular(idEstudiante, idGrupo);
                    Response.Write("<script>alert('Matrícula realizada con éxito');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Por favor, ingrese IDs válidos para Estudiante y Grupo');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al realizar la matrícula: " + ex.Message + "');</script>");
            }
        }
    }
}
