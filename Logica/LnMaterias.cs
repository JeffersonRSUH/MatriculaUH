using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Datos;
using Objetos;

namespace Logica
{
    public class LnMaterias
    {
        public List<oMateria> ConsultaMaterias(int idCarrera, int idMateria)
        {
            try
            {
                LdMaterias datos = new LdMaterias();
                var tabla = datos.ConsultaMaterias(idCarrera, idMateria);

                List<oMateria> listado = tabla.AsEnumerable()
                    .Select(row => new oMateria
                    {
                        Carrera = new oCarrera
                        {
                            IdCarrera = row.Field<int>("IdCarrera"),
                            Carrera = row.Field<string>("Carrera")
                        },
                        IdMateria = row.Field<int>("IdMateria"),
                        Materia = row.Field<string>("Materia")
                    }).ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CrearMateria(oMateria materia)
        {
            try
            {
                LdMaterias datos = new LdMaterias();
                int idMateria = datos.CrearMateria(materia.Carrera.IdCarrera, materia.Materia);
                return idMateria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarMateria(oMateria materia)
        {
            try
            {
                LdMaterias datos = new LdMaterias();
                datos.ActualizarMateria(materia.IdMateria, materia.Carrera.IdCarrera, materia.Materia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
