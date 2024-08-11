using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Objetos;

namespace Logica
{
    public class LnMatricula
    {
        private Datos.LdMatricula datos = new Datos.LdMatricula();

        public List<oEstudiante> ObtenerEstudiantes()
        {
            try
            {
                DataTable tabla = datos.ObtenerEstudiantes();
                List<oEstudiante> listado = tabla.AsEnumerable()
                    .Select(row => new oEstudiante
                    {
                        IdEstudiante = row.Field<int>("IdEstudiante").ToString(),
                        Nombre = row.Field<string>("Nombre"),
                        ApellidoPaterno = row.Field<string>("ApellidoPaterno"),
                        ApellidoMaterno = row.Field<string>("ApellidoMaterno"),
                        Identificacion = row.Field<int>("Identificacion"),
                        FechaNacimiento = row.Field<DateTime>("FechaNacimiento"),
                        FechaIngreso = row.Field<DateTime>("FechaIngreso"),
                        Estado = (EstadoEstudiante)row.Field<int>("IdEstadoEstudiante"),
                        TipoIdentificacion = (TipoIdentificacion)row.Field<int>("IdTipoIdentificacion"),
                        Carrera = new oCarrera { IdCarrera = row.Field<int>("IdCarrera") }
                    })
                    .ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<oGrupo> ObtenerGrupos()
        {
            try
            {
                DataTable tabla = datos.ObtenerGrupos();
                List<oGrupo> listado = tabla.AsEnumerable()
                    .Select(row => new oGrupo
                    {
                        IdGrupo = row.Field<int>("IdGrupo"),
                        NumeroGrupo = row.Field<int>("NumeroGrupo"),
                        Cupo = row.Field<int>("Cupo"),
                        Materia = new oMateria
                        {
                            IdMateria = row.Field<int>("IdMateria"),
                            Materia = row.Field<string>("Materia")
                        },
                        Horario = (Horario)Enum.Parse(typeof(Horario), row.Field<string>("Horario")),
                        Estado = (EstadoGrupo)Enum.Parse(typeof(EstadoGrupo), row.Field<string>("EstadoGrupo"))
                    })
                    .ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Matricular(int idEstudiante, int idGrupo)
        {
            try
            {
                datos.Matricular(idEstudiante, idGrupo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in business logic for matricula: " + ex.Message);
            }
        }

        public List<oMatricula> ListarMatriculas()
        {
            try
            {
                DataTable tabla = datos.ListarMatriculas();
                List<oMatricula> listado = tabla.AsEnumerable()
                    .Select(row => new oMatricula
                    {
                        IdMatricula = row.Field<int>("IdMatricula"),
                        IdEstudiante = new oEstudiante { IdEstudiante = Convert.ToString(row.Field<int>("IdEstudiante")) },
                        IdGrupo = new oGrupo { IdGrupo = row.Field<int>("IdGrupo") }
                    })
                    .ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error listing matriculas: " + ex.Message);
            }
        }

        public void Desmatricular(int idMatricula)
        {
            try
            {
                datos.Desmatricular(idMatricula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in business logic for desmatricula: " + ex.Message);
            }
        }
    }
}
