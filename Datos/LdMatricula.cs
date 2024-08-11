using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class LdMatricula
    {
        private SqlConnection _connection;

        public LdMatricula()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        public DataTable ObtenerEstudiantes()
        {
            using (SqlCommand cmd = new SqlCommand("spListarEstudiantes", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable resultado = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                try
                {
                    _connection.Open();
                    adapter.Fill(resultado);
                    return resultado;
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
            }
        }

        public DataTable ObtenerGrupos()
        {
            using (SqlCommand cmd = new SqlCommand("spObtenerGrupos", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable resultado = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                try
                {
                    _connection.Open();
                    adapter.Fill(resultado);
                    return resultado;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving groups: " + ex.Message);
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

        public void Matricular(int idEstudiante, int idGrupo)
        {
            using (SqlCommand cmd = new SqlCommand("spMatricular", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@idGrupo", idGrupo);

                SqlParameter codError = new SqlParameter("@cod_error", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(codError);

                SqlParameter msgError = new SqlParameter("@msg_error", SqlDbType.VarChar, 255)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(msgError);

                try
                {
                    _connection.Open();
                    cmd.ExecuteNonQuery();

                    if ((int)cmd.Parameters["@cod_error"].Value != 0)
                    {
                        throw new Exception(cmd.Parameters["@msg_error"].Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inserting matricula: " + ex.Message);
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
}
