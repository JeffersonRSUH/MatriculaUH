using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class LdEstudiante
    {
        private SqlConnection _connection;

        public LdEstudiante()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        public DataTable BuscarEstudiantes(int? idEstudiante, string nombre, string apellidoPaterno, string apellidoMaterno, int? identificacion, int? idEstadoEstudiante, int? idTipoIdentificacion, int? idCarrera)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "spBuscarEstudiantes",
                CommandType = CommandType.StoredProcedure,
                Connection = _connection
            };

            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante.HasValue ? (object)idEstudiante.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(nombre) ? (object)DBNull.Value : nombre);
            cmd.Parameters.AddWithValue("@ApellidoPaterno", string.IsNullOrEmpty(apellidoPaterno) ? (object)DBNull.Value : apellidoPaterno);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", string.IsNullOrEmpty(apellidoMaterno) ? (object)DBNull.Value : apellidoMaterno);
            cmd.Parameters.AddWithValue("@Identificacion", identificacion.HasValue ? (object)identificacion.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IdEstadoEstudiante", idEstadoEstudiante.HasValue ? (object)idEstadoEstudiante.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IdTipoIdentificacion", idTipoIdentificacion.HasValue ? (object)idTipoIdentificacion.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IdCarrera", idCarrera.HasValue ? (object)idCarrera.Value : DBNull.Value);

            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving students: " + ex.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return dt;
        }

        public DataTable ListarEstudiantes()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "spListarEstudiantes",
                CommandType = CommandType.StoredProcedure,
                Connection = _connection
            };

            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving students: " + ex.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return dt;
        }

        public DataTable BuscarEstudiantePorId(int idEstudiante)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "spBuscarEstudiantePorId",
                CommandType = CommandType.StoredProcedure,
                Connection = _connection
            };

            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);

            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving student by ID: " + ex.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return dt;
        }

        public int CrearEstudiante(string nombre, string apellidoPaterno, string apellidoMaterno, int identificacion, DateTime fechaNacimiento, DateTime fechaIngreso, int idEstadoEstudiante, int idTipoIdentificacion, int idCarrera, out int codError, out string msgError)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "spCrearEstudiante",
                CommandType = CommandType.StoredProcedure,
                Connection = _connection
            };

            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", string.IsNullOrEmpty(apellidoMaterno) ? (object)DBNull.Value : apellidoMaterno);
            cmd.Parameters.AddWithValue("@Identificacion", identificacion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
            cmd.Parameters.AddWithValue("@IdEstadoEstudiante", idEstadoEstudiante);
            cmd.Parameters.AddWithValue("@IdTipoIdentificacion", idTipoIdentificacion);
            cmd.Parameters.AddWithValue("@IdCarrera", idCarrera);

            SqlParameter outputId = new SqlParameter("@IdEstudiante", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);

            SqlParameter outputCodError = new SqlParameter("@cod_error", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputCodError);

            SqlParameter outputMsgError = new SqlParameter("@msg_error", SqlDbType.NVarChar, 256)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputMsgError);

            try
            {
                _connection.Open();
                cmd.ExecuteNonQuery();

                codError = (int)cmd.Parameters["@cod_error"].Value;
                msgError = (string)cmd.Parameters["@msg_error"].Value;

                return (int)cmd.Parameters["@IdEstudiante"].Value;
            }
            catch (Exception ex)
            {
                codError = -1;
                msgError = ex.Message;
                return -1;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
    }
}
