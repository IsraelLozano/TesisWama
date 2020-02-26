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
    public partial class TblinstructorDA
    {
        #region TblinstructorAD Generales
        /// <summary>
        /// Metodo que Inserta la Entidad Tblinstructor hacia la base da datos
        /// </summary>
        /// <param name="Tblinstructor">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Tblinstructor con datos llenos</returns>
        public Tblinstructor InsertarTblinstructor(Tblinstructor tblinstructor)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarTblinstructor", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", tblinstructor.IdPersona);					comando.Parameters.AddWithValue("@NombreInstructor", tblinstructor.NombreInstructor);					comando.Parameters.AddWithValue("@ZonalId", tblinstructor.ZonalId);					comando.Parameters.AddWithValue("@CampusId", tblinstructor.CampusId);					comando.Parameters.AddWithValue("@Estado", tblinstructor.Estado);
                    conexion.Open();
                    tblinstructor.Id = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return tblinstructor;
        }
        
        public Tblinstructor ActualizarTblinstructor(Tblinstructor tblinstructor)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarTblinstructor", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", tblinstructor.Id); 				comando.Parameters.AddWithValue("@IdPersona", tblinstructor.IdPersona); 				comando.Parameters.AddWithValue("@NombreInstructor", tblinstructor.NombreInstructor); 				comando.Parameters.AddWithValue("@ZonalId", tblinstructor.ZonalId); 				comando.Parameters.AddWithValue("@CampusId", tblinstructor.CampusId); 				comando.Parameters.AddWithValue("@Estado", tblinstructor.Estado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tblinstructor;
        }

        public List<Tblinstructor> ListarTblinstructorPendientes()
        {
            List<Tblinstructor> listaEntidad = new List<Tblinstructor>();
            Tblinstructor entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTblinstructorPendiente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblinstructor();
                        entidad.IdPersona = Convert.ToInt32(reader["IdPersona"]);
                        entidad.NombreInstructor = Convert.ToString(reader["NombreInstructor"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }

            return listaEntidad;
        }

        public int AnularTblinstructorPorCodigo(int Id)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarTblinstructor", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }
        
        public Tblinstructor RecuperarTblinstructorPorCodigo(int Id)
        {
            Tblinstructor tblinstructor = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerTblinstructor", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tblinstructor = new Tblinstructor(reader);
                    }
                }
                conexion.Close();
            }
            return tblinstructor;
        }

        public IEnumerable<Tblinstructor> ListarTblinstructor()
        {
           List<Tblinstructor> listaEntidad = new List<Tblinstructor>();
           Tblinstructor entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTblinstructor", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblinstructor(reader);
                        entidad.NombreCampus = Convert.ToString(reader["ZonalDes"]);
                        entidad.NombreZona = Convert.ToString(reader["CampusDes"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }

            return (IEnumerable<Tblinstructor>)listaEntidad;
        }

        public IEnumerable<Tblinstructor> ListarPaginadoTblinstructor(string Filtro, int NumPag, int CantRegxPag)
        {
            List<Tblinstructor> listaEntidad = new List<Tblinstructor>();
            Tblinstructor entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarPaginaTblinstructor", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Filtro", Filtro);
                    comando.Parameters.AddWithValue("@NumPag", NumPag);
                    comando.Parameters.AddWithValue("@CantRegxPag", CantRegxPag);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblinstructor(reader);
                        //entidad.TotalVirtual = System.Convert.ToInt32(reader["TotalVirtual"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return (IEnumerable<Tblinstructor>)listaEntidad;
        }

        #endregion


        #region Extensiones

        
        #endregion
    }
}