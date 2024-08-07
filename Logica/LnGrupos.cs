using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Objetos;
using Datos;

namespace Logica
{
    public class LnGrupos
    {
        public DataTable ObtenerMaterias()
        {
            try
            {
                LdGrupos datos = new LdGrupos();
                return datos.ObtenerMaterias();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerHorarios()
        {
            try
            {
                LdGrupos datos = new LdGrupos();
                return datos.ObtenerHorarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerEstados()
        {
            try
            {
                LdGrupos datos = new LdGrupos();
                return datos.ObtenerEstados();
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
                LdGrupos datos = new LdGrupos();
                DataTable tabla = datos.ObtenerGrupos();

                List<oGrupo> listado = tabla.AsEnumerable()
                    .Select(row => new oGrupo
                    {
                        IdGrupo = row.Field<int>("IdGrupo"),
                        NumeroGrupo = row.Field<int>("NumeroGrupo"),
                        Cupo = row.Field<int>("Cupo"),
                        Materia = new oMateria
                        {
                            IdMateria = row.Field<int>("IdMateria"), // Ensure this matches the actual column name
                            Materia = row.Field<string>("Materia") // Ensure this matches the actual column name
                        },
                        Horario = (Horario)Enum.Parse(typeof(Horario), row.Field<string>("Horario")),
                        Estado = (EstadoGrupo)Enum.Parse(typeof(EstadoGrupo), row.Field<string>("EstadoGrupo")) // Ensure this matches the actual column name
                    }).ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CrearGrupo(oGrupo grupo)
        {
            try
            {
                LdGrupos datos = new LdGrupos();
                int idGrupo = datos.CrearGrupo(grupo.NumeroGrupo, grupo.Cupo, grupo.Materia.IdMateria, (int)grupo.Horario, (int)grupo.Estado);
                return idGrupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
