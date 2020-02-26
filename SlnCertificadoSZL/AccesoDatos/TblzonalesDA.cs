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
    public partial class TblzonalesDA
    {
        #region TblzonalesAD Generales
        /// <summary>
        /// Metodo que Inserta la Entidad Tblzonales hacia la base da datos
        /// </summary>
        /// <param name="Tblzonales">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Tblzonales con datos llenos</returns>
        public Tblzonales InsertarTblzonales(Tblzonales tblzonales)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarTblzonales", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ZonalDes", tblzonales.ZonalDes);					comando.Parameters.AddWithValue("@ZonalCod", tblzonales.ZonalCod);
                    conexion.Open();
                    tblzonales.ZonalID = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return tblzonales;
        }
        
        public Tblzonales ActualizarTblzonales(Tblzonales tblzonales)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarTblzonales", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ZonalID", tblzonales.ZonalID); 				comando.Parameters.AddWithValue("@ZonalDes", tblzonales.ZonalDes); 				comando.Parameters.AddWithValue("@ZonalCod", tblzonales.ZonalCod);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tblzonales;
        }        

        public int AnularTblzonalesPorCodigo(int ZonalID)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarTblzonales", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ZonalID", ZonalID);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }
        
        public Tblzonales RecuperarTblzonalesPorCodigo(int ZonalID)
        {
            Tblzonales tblzonales = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerTblzonales", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ZonalID", ZonalID);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tblzonales = new Tblzonales(reader);
                    }
                }
                conexion.Close();
            }
            return tblzonales;
        }

        public IEnumerable<Tblzonales> ListarTblzonales()
        {
           List<Tblzonales> listaEntidad = new List<Tblzonales>();
           Tblzonales entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTblzonales", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblzonales(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return (IEnumerable<Tblzonales>)listaEntidad;
        }

        public IEnumerable<Tblzonales> ListarPaginadoTblzonales(string Filtro, int NumPag, int CantRegxPag)
        {
            List<Tblzonales> listaEntidad = new List<Tblzonales>();
            Tblzonales entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarPaginaTblzonales", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Filtro", Filtro);
                    comando.Parameters.AddWithValue("@NumPag", NumPag);
                    comando.Parameters.AddWithValue("@CantRegxPag", CantRegxPag);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblzonales(reader);
                        //entidad.TotalVirtual = System.Convert.ToInt32(reader["TotalVirtual"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return (IEnumerable<Tblzonales>)listaEntidad;
        }

        #endregion


        #region Extensiones

        
        #endregion
    }
}