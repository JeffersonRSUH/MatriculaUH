using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LnMaterias
    {
        public List<oMateria> ConsultaMaterias(int idCarrera, int idMateria)
        {
            try
            {
                //instanciar la entidad para hacer la llamada

                Datos.LdMaterias datos = new Datos.LdMaterias();

                var tabla = datos.ConsultaMaterias(idCarrera,idMateria);

                //List<oArticulo> listado = util.ConvertDataTableToList<oArticulo>(tabla);

                List<oMateria> listado = tabla.AsEnumerable()
             .Select(row => new oMateria
             {
                 IdCarrera = row.Field<int>("IdCarrera"),
                 Carrera = row.Field<string>("Carrera"),
                 IdMateria   = row.Field<int>("IdMateria"),
                 Materia = row.Field<string>("Materia")

             })
             .ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
