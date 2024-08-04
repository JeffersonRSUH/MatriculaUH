using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Objetos;

namespace Logica
{
    public class LnEstudiante
    {
        private Datos.LdEstudiante datos = new Datos.LdEstudiante();

        public List<oEstudiante> BuscarEstudiantes(int? idEstudiante, string nombre, string apellidoPaterno, string apellidoMaterno, int? identificacion, int? idEstadoEstudiante, int? idTipoIdentificacion, int? idCarrera)
        {
            try
            {
                var tabla = datos.BuscarEstudiantes(idEstudiante, nombre, apellidoPaterno, apellidoMaterno, identificacion, idEstadoEstudiante, idTipoIdentificacion, idCarrera);

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

        public List<oEstudiante> ListarEstudiantes()
        {
            try
            {
                var tabla = datos.ListarEstudiantes();
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

        public oEstudiante BuscarEstudiantePorId(int idEstudiante)
        {
            try
            {
                var tabla = datos.BuscarEstudiantePorId(idEstudiante);

                var estudiante = tabla.AsEnumerable()
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
                    .FirstOrDefault();

                return estudiante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CrearEstudiante(string nombre, string apellidoPaterno, string apellidoMaterno, int identificacion, DateTime fechaNacimiento, DateTime fechaIngreso, int idEstadoEstudiante, int idTipoIdentificacion, int idCarrera, out int idEstudiante)
        {
            try
            {
                int cod_error;
                string msg_error;
                idEstudiante = datos.CrearEstudiante(nombre, apellidoPaterno, apellidoMaterno, identificacion, fechaNacimiento, fechaIngreso, idEstadoEstudiante, idTipoIdentificacion, idCarrera, out cod_error, out msg_error);

                if (cod_error != 0)
                {
                    throw new Exception("Error creating student: " + msg_error);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
