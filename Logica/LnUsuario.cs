using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LnUsuario
    {
        public List<oUsuario> AutenticaUsuario(string user, string password)
        {
            try
            {
                //instanciar la entidad para hacer la llamada

                Datos.LdUsuario datos = new Datos.LdUsuario();

                var tabla = datos.Autentica(user,password);

                //List<oArticulo> listado = util.ConvertDataTableToList<oArticulo>(tabla);


                List<oUsuario> listado = tabla.AsEnumerable()
             .Select(row => new oUsuario
             {
                 usuario = row.Field<string>("usuario"),
                 idRol = row.Field<int>("idrol"),
                 Rol = row.Field<string>("rol")

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
