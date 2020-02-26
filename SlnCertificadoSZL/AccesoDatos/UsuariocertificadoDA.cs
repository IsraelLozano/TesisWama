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
    public partial class UsuariocertificadoDA
    {
        #region UsuariocertificadoAD Generales
        /// <summary>
        /// Metodo que Inserta la Entidad Usuariocertificado hacia la base da datos
        /// </summary>
        /// <param name="Usuariocertificado">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Usuariocertificado con datos llenos</returns>
        public Usuariocertificado InsertarUsuariocertificado(Usuariocertificado usuariocertificado)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarUsuariocertificado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", usuariocertificado.IdPersona);					comando.Parameters.AddWithValue("@Nombre", usuariocertificado.Nombre);					comando.Parameters.AddWithValue("@InicioValidez", usuariocertificado.InicioValidez);					comando.Parameters.AddWithValue("@FinValidez", usuariocertificado.FinValidez);					comando.Parameters.AddWithValue("@TamanioKB", usuariocertificado.TamanioKB);					comando.Parameters.AddWithValue("@Asunto", usuariocertificado.Asunto);					comando.Parameters.AddWithValue("@Emision", usuariocertificado.Emision);					comando.Parameters.AddWithValue("@Correo", usuariocertificado.Correo);					comando.Parameters.AddWithValue("@Certificado", usuariocertificado.Certificado);					comando.Parameters.AddWithValue("@Extension", usuariocertificado.Extension);					comando.Parameters.AddWithValue("@Estado", usuariocertificado.Estado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return usuariocertificado;
        }
        
        public Usuariocertificado ActualizarUsuariocertificado(Usuariocertificado usuariocertificado)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarUsuariocertificado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", usuariocertificado.IdPersona); 				comando.Parameters.AddWithValue("@Nombre", usuariocertificado.Nombre); 				comando.Parameters.AddWithValue("@InicioValidez", usuariocertificado.InicioValidez); 				comando.Parameters.AddWithValue("@FinValidez", usuariocertificado.FinValidez); 				comando.Parameters.AddWithValue("@TamanioKB", usuariocertificado.TamanioKB); 				comando.Parameters.AddWithValue("@Asunto", usuariocertificado.Asunto); 				comando.Parameters.AddWithValue("@Emision", usuariocertificado.Emision); 				comando.Parameters.AddWithValue("@Correo", usuariocertificado.Correo); 				comando.Parameters.AddWithValue("@Certificado", usuariocertificado.Certificado); 				comando.Parameters.AddWithValue("@Extension", usuariocertificado.Extension); 				comando.Parameters.AddWithValue("@Estado", usuariocertificado.Estado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return usuariocertificado;
        }        

        public int AnularUsuariocertificadoPorCodigo(int IdPersona)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarUsuariocertificado", conexion))
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
        
        public Usuariocertificado RecuperarUsuariocertificadoPorCodigo(int IdPersona)
        {
            Usuariocertificado usuariocertificado = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerUsuariocertificado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        usuariocertificado = new Usuariocertificado(reader);
                    }
                }
                conexion.Close();
            }
            return usuariocertificado;
        }

        public IEnumerable<Usuariocertificado> ListarUsuariocertificado()
        {
           List<Usuariocertificado> listaEntidad = new List<Usuariocertificado>();
           Usuariocertificado entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarUsuariocertificado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Usuariocertificado(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return (IEnumerable<Usuariocertificado>)listaEntidad;
        }

        public IEnumerable<Usuariocertificado> ListarPaginadoUsuariocertificado(string Filtro, int NumPag, int CantRegxPag)
        {
            List<Usuariocertificado> listaEntidad = new List<Usuariocertificado>();
            Usuariocertificado entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarPaginaUsuariocertificado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Filtro", Filtro);
                    comando.Parameters.AddWithValue("@NumPag", NumPag);
                    comando.Parameters.AddWithValue("@CantRegxPag", CantRegxPag);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Usuariocertificado(reader);
                        ///entidad.TotalVirtual = System.Convert.ToInt32(reader["TotalVirtual"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return (IEnumerable<Usuariocertificado>)listaEntidad;
        }

        #endregion


        #region Extensiones

        
        #endregion
    }
}