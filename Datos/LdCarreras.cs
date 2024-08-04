using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LdCarreras
    {
        #region Métodos de ConnectionStrings

        private SqlConnection _connection;

        public LdCarreras()
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

        public DataTable ConsultaCarreras(int idCarrera)
        {
            //definir el comando y configurarlo
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spSeleccionaCarreras]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;

            //si es tipo texto
            //cmdEjecutar.CommandText = "select * from EstadoCivil";
            //cmdEjecutar.CommandType = CommandType.Text;

            //se asigna el string de conexion a la bd
            cmdEjecutar.Connection = _connection;

            DataTable resultado = new DataTable("Carreras");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdEjecutar);

            try
            {
                cmdEjecutar.Parameters.AddWithValue("@idCarrera", idCarrera == 0 ? (object)DBNull.Value : idCarrera);

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

        #region Método insert
        public int InsertarCarrera(string nombreCarrera)
        {
            int idFactura = 0;

            //Configura el command --->> crear una instrucción que se ejecuta en el Motor de BD
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spInsertaCarrera]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;
            cmdEjecutar.Connection = _connection;

            try
            {
                //indicar los parámetros requeridos
                //parámetros de entrada
                cmdEjecutar.Parameters.AddWithValue("@nombre", nombreCarrera);

                //parametros de salida
                cmdEjecutar.Parameters.Add("@cod_error", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                cmdEjecutar.Parameters.Add("@msg_error", SqlDbType.VarChar, 256).Direction = ParameterDirection.Output;
                cmdEjecutar.Parameters.Add("@idCarrera", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                //ejecutar
                _connection.Open();
                cmdEjecutar.ExecuteNonQuery();
                _connection.Close();
                //revisar los parametros
                int cod_error = Int32.Parse(cmdEjecutar.Parameters["@cod_error"].Value.ToString());
                string msg_error = cmdEjecutar.Parameters["@msg_error"].Value.ToString();
                idFactura = Int32.Parse(cmdEjecutar.Parameters["@idCarrera"].Value.ToString());

                if (cod_error != 0)
                {
                    throw new Exception("Ocurrió un error: " + msg_error);
                }

                return idFactura;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
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
