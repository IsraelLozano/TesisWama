using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace AccesoDatosSQL
{
    public partial class TblusuarioDA
    {
        #region TblusuarioAD Generales
        /// <summary>
        /// Metodo que Inserta la Entidad Tblusuario hacia la base da datos
        /// </summary>
        /// <param name="Tblusuario">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Tblusuario con datos llenos</returns>
        public Tblusuario InsertarTblusuario(Tblusuario tblusuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarTblusuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", tblusuario.IdPersona);
                    comando.Parameters.AddWithValue("@UsuarioCodigo", tblusuario.UsuarioCodigo);
                    comando.Parameters.AddWithValue("@Clave", tblusuario.Clave);
                    comando.Parameters.AddWithValue("@Reset", tblusuario.Reset);
                    comando.Parameters.AddWithValue("@Estado", tblusuario.Estado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tblusuario;
        }

        public Tblusuario ActualizarTblusuario(Tblusuario tblusuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarTblusuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", tblusuario.IdPersona);
                    comando.Parameters.AddWithValue("@UsuarioCodigo", tblusuario.UsuarioCodigo);
                    comando.Parameters.AddWithValue("@Clave", tblusuario.Clave);
                    comando.Parameters.AddWithValue("@Reset", tblusuario.Reset);
                    comando.Parameters.AddWithValue("@Estado", tblusuario.Estado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tblusuario;
        }

        public int AnularTblusuarioPorCodigo(int IdPersona)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarTblusuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }

        public Tblusuario RecuperarTblusuarioPorCodigo(int IdPersona)
        {
            Tblusuario tblusuario = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerTblusuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tblusuario = new Tblusuario(reader);
                    }
                }
                conexion.Close();
            }
            return tblusuario;
        }

        public IEnumerable<Tblusuario> ListarTblusuario()
        {
            List<Tblusuario> listaEntidad = new List<Tblusuario>();
            Tblusuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTblusuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblusuario(reader);
                        entidad.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
                        entidad.TieneCertificado = Convert.ToBoolean(reader["TieneCertificado"]);
                        if (!Convert.IsDBNull(reader["FinValidez"]))
                        {
                            entidad.VigenciaCertificado = Convert.ToDateTime(reader["FinValidez"]);
                        }

                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return (IEnumerable<Tblusuario>)listaEntidad;
        }

        public IEnumerable<Tblusuario> ListarPaginadoTblusuario(string Filtro, int NumPag, int CantRegxPag)
        {
            List<Tblusuario> listaEntidad = new List<Tblusuario>();
            Tblusuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarPaginaTblusuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Filtro", Filtro);
                    comando.Parameters.AddWithValue("@NumPag", NumPag);
                    comando.Parameters.AddWithValue("@CantRegxPag", CantRegxPag);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblusuario(reader);
                        //entidad.TotalVirtual = System.Convert.ToInt32(reader["TotalVirtual"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return (IEnumerable<Tblusuario>)listaEntidad;
        }

        #endregion


        #region Extensiones


        #endregion
    }
}