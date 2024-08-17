using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;
using Datos;
using System.Data;

namespace Logica
{
    public class LnCarreras
    {
        public List<oCarrera> ConsultaCarreras(int idCarrera)
        {
            try
            {
                //instanciar la entidad para hacer la llamada
             
                Datos.LdCarreras datos = new Datos.LdCarreras();

                var tabla = datos.ConsultaCarreras(idCarrera);

                //List<oArticulo> listado = util.ConvertDataTableToList<oArticulo>(tabla);

                List<oCarrera> listado = tabla.AsEnumerable()
             .Select(row => new oCarrera
             {
                 IdCarrera = row.Field<int>("IdCarrera"),
                 Carrera = row.Field<string>("Carrera"),
                 Estado = row.Field<bool>("Estado")
                
             })
             .ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool InsertarCarrera(string nombreCarrera)
        {
            try
            {
                if (nombreCarrera == null)
                {
                    throw new Exception("La carrera no debe ser vacío.");
                }
                Datos.LdCarreras datos = new Datos.LdCarreras();


                int idCarrera = datos.InsertarCarrera(nombreCarrera);

                if(idCarrera > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int ObtenerCantidadEstudiantes(int idCarrera)
        {
            LdCarreras datos = new LdCarreras();
            return datos.ObtenerCantidadEstudiantes(idCarrera);
        }

        public int ObtenerCantidadMaterias(int idCarrera)
        {
            LdCarreras datos = new LdCarreras();
            return datos.ObtenerCantidadMaterias(idCarrera);
        }

    }
}
