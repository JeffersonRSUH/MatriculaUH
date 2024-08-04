using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LdMaterias
    {
        #region Métodos de ConnectionStrings

        private SqlConnection _connection;

        public LdMaterias()
        {
            InitConnection();
        }


        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        #endregion

        #region métodos de consulta

        public DataTable ConsultaMaterias(int idCarrera, int idMateria)
        {
            //definir el comando y configurarlo
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spSeleccionaMaterias]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;

            //si es tipo texto
            //cmdEjecutar.CommandText = "select * from EstadoCivil";
            //cmdEjecutar.CommandType = CommandType.Text;

            //se asigna el string de conexion a la bd
            cmdEjecutar.Connection = _connection;

            DataTable resultado = new DataTable("Materias");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdEjecutar);

            try
            {
                cmdEjecutar.Parameters.AddWithValue("@idCarrera", idCarrera == 0 ? (object)DBNull.Value : idCarrera);
                cmdEjecutar.Parameters.AddWithValue("@idMateria", idMateria == 0 ? (object)DBNull.Value : idMateria);
                //abrir la conexion con la db
                _connection.Open();
                //ejecutar el commando
                adapter.Fill(resultado);

                //se debe cerrar la bd pero se va a cerrar en el Finally para el ejemplo
                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //preguntar si la conexion esta abierta
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                cmdEjecutar.Dispose();
            }
        }
        #endregion
    }
}
