using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class LdMaterias
    {
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

        public DataTable ConsultaMaterias(int idCarrera, int idMateria)
        {
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spSeleccionaMaterias]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;
            cmdEjecutar.Connection = _connection;

            DataTable resultado = new DataTable("Materias");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdEjecutar);

            try
            {
                cmdEjecutar.Parameters.AddWithValue("@idCarrera", idCarrera == 0 ? (object)DBNull.Value : idCarrera);
                cmdEjecutar.Parameters.AddWithValue("@idMateria", idMateria == 0 ? (object)DBNull.Value : idMateria);
                _connection.Open();
                adapter.Fill(resultado);
                return resultado;
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

        public int CrearMateria(int idCarrera, string materia)
        {
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spCrearMateria]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;
            cmdEjecutar.Connection = _connection;

            cmdEjecutar.Parameters.AddWithValue("@IdCarrera", idCarrera);
            cmdEjecutar.Parameters.AddWithValue("@Materia", materia);

            try
            {
                _connection.Open();
                int idMateria = Convert.ToInt32(cmdEjecutar.ExecuteScalar());
                return idMateria;
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

        public void ActualizarMateria(int idMateria, int idCarrera, string materia)
        {
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spActualizarMateria]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;
            cmdEjecutar.Connection = _connection;

            cmdEjecutar.Parameters.AddWithValue("@IdMateria", idMateria);
            cmdEjecutar.Parameters.AddWithValue("@IdCarrera", idCarrera);
            cmdEjecutar.Parameters.AddWithValue("@Materia", materia);

            try
            {
                _connection.Open();
                cmdEjecutar.ExecuteNonQuery();
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
    }
}
