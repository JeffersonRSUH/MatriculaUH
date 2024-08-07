using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class LdGrupos
    {
        private SqlConnection _connection;

        public LdGrupos()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        public DataTable ObtenerMaterias()
        {
            using (SqlCommand cmd = new SqlCommand("[dbo].[spObtenerMaterias]", _connection))
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
                    throw new Exception(ex.Message);
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

        public DataTable ObtenerHorarios()
        {
            using (SqlCommand cmd = new SqlCommand("[dbo].[spObtenerHorarios]", _connection))
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
                    throw new Exception(ex.Message);
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

        public DataTable ObtenerEstados()
        {
            using (SqlCommand cmd = new SqlCommand("[dbo].[spObtenerEstados]", _connection))
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
                    throw new Exception(ex.Message);
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
            using (SqlCommand cmd = new SqlCommand("[dbo].[spObtenerGrupos]", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable resultado = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                try
                {
                    _connection.Open();
                    adapter.Fill(resultado);

                    // Debugging: Output column names
                    foreach (DataColumn column in resultado.Columns)
                    {
                        System.Diagnostics.Debug.WriteLine($"Column name: {column.ColumnName}");
                    }

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
                }
            }
        }

        public int CrearGrupo(int numeroGrupo, int cupo, int idMateria, int idHorario, int idEstadoGrupo)
        {
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spCrearGrupos]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;
            cmdEjecutar.Connection = _connection;

            cmdEjecutar.Parameters.AddWithValue("@NumeroGrupo", numeroGrupo);
            cmdEjecutar.Parameters.AddWithValue("@Cupo", cupo);
            cmdEjecutar.Parameters.AddWithValue("@IdMateria", idMateria);
            cmdEjecutar.Parameters.AddWithValue("@IdHorario", idHorario);
            cmdEjecutar.Parameters.AddWithValue("@IdEstadoGrupo", idEstadoGrupo);

            try
            {
                _connection.Open();
                int idGrupo = Convert.ToInt32(cmdEjecutar.ExecuteScalar());
                return idGrupo;
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
