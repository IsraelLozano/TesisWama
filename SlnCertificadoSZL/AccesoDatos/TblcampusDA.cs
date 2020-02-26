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
    public partial class TblcampusDA
    {
        #region TblcampusAD Generales
        /// <summary>
        /// Metodo que Inserta la Entidad Tblcampus hacia la base da datos
        /// </summary>
        /// <param name="Tblcampus">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Tblcampus con datos llenos</returns>
        public Tblcampus InsertarTblcampus(Tblcampus tblcampus)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarTblcampus", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ZonalID", tblcampus.ZonalID);
                    comando.Parameters.AddWithValue("@CampusDes", tblcampus.CampusDes);
                    comando.Parameters.AddWithValue("@Direccion", tblcampus.Direccion);
                    comando.Parameters.AddWithValue("@Responsable", tblcampus.Responsable);
                    comando.Parameters.AddWithValue("@Cargo", tblcampus.Cargo);
                    comando.Parameters.AddWithValue("@Telefono", tblcampus.Telefono);
                    comando.Parameters.AddWithValue("@Email", tblcampus.Email);
                    comando.Parameters.AddWithValue("@Trabajadores", tblcampus.Trabajadores);
                    comando.Parameters.AddWithValue("@Afiliados", tblcampus.Afiliados);
                    comando.Parameters.AddWithValue("@InicioAct", tblcampus.InicioAct);
                    conexion.Open();
                    tblcampus.CampusID = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return tblcampus;
        }

        public Tblcampus ActualizarTblcampus(Tblcampus tblcampus)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarTblcampus", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CampusID", tblcampus.CampusID);
                    comando.Parameters.AddWithValue("@ZonalID", tblcampus.ZonalID);
                    comando.Parameters.AddWithValue("@CampusDes", tblcampus.CampusDes);
                    comando.Parameters.AddWithValue("@Direccion", tblcampus.Direccion);
                    comando.Parameters.AddWithValue("@Responsable", tblcampus.Responsable);
                    comando.Parameters.AddWithValue("@Cargo", tblcampus.Cargo);
                    comando.Parameters.AddWithValue("@Telefono", tblcampus.Telefono);
                    comando.Parameters.AddWithValue("@Email", tblcampus.Email);
                    comando.Parameters.AddWithValue("@Trabajadores", tblcampus.Trabajadores);
                    comando.Parameters.AddWithValue("@Afiliados", tblcampus.Afiliados);
                    comando.Parameters.AddWithValue("@InicioAct", tblcampus.InicioAct);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tblcampus;
        }

        

        public int AnularTblcampusPorCodigo(int CampusID)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarTblcampus", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CampusID", CampusID);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }

        public Tblcampus RecuperarTblcampusPorCodigo(int CampusID)
        {
            Tblcampus tblcampus = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerTblcampus", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CampusID", CampusID);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tblcampus = new Tblcampus(reader);
                    }
                }
                conexion.Close();
            }
            return tblcampus;
        }

        public IEnumerable<Tblcampus> ListarTblcampus()
        {
            List<Tblcampus> listaEntidad = new List<Tblcampus>();
            Tblcampus entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTblcampus", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblcampus(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return (IEnumerable<Tblcampus>)listaEntidad;
        }

        public IEnumerable<Tblcampus> ListarPaginadoTblcampus(string Filtro, int NumPag, int CantRegxPag)
        {
            List<Tblcampus> listaEntidad = new List<Tblcampus>();
            Tblcampus entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarPaginaTblcampus", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Filtro", Filtro);
                    comando.Parameters.AddWithValue("@NumPag", NumPag);
                    comando.Parameters.AddWithValue("@CantRegxPag", CantRegxPag);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblcampus(reader);
                        //entidad.TotalVirtual = System.Convert.ToInt32(reader["TotalVirtual"]);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return (IEnumerable<Tblcampus>)listaEntidad;
        }

        #endregion


        #region Extensiones
        public List<Tblcampus> ListarTblcampusPorZonas(int idzona)
        {
            List<Tblcampus> listaEntidad = new List<Tblcampus>();
            Tblcampus entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTblcampusPorZonas", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idzona", idzona);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tblcampus(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }

        #endregion
    }
}