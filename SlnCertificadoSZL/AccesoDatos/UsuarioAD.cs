using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public partial class UsuarioAD
    {
        #region UsuarioAD

        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;
        /// <summary>
        /// Metodo que llena la Entidad con un DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Entidad Usuario con datos llenos</returns>
        public Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.IdPersona = Convert.ToInt32(reader["IdPersona"]);
            usuario.UsuarioCodigo = Convert.ToString(reader["UsuarioCodigo"]);
            if (!Convert.IsDBNull(reader["Clave"]))
            {
                usuario.Clave = (byte[])reader["Clave"];

            }
            usuario.Reset = Convert.ToBoolean(reader["Reset"]);
            usuario.Estado = Convert.ToBoolean(reader["Estado"]);
         
            return usuario;

        }

        public Usuario InsertarUsuario(Usuario usuario)
        {
           
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_InsertarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdPersona", usuario.IdPersona);
                    comando.Parameters.AddWithValue("@UsuarioCodigo", usuario.UsuarioCodigo);
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@Reset", usuario.Reset);
                    comando.Parameters.AddWithValue("@Estado", usuario.Estado);
                   
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return usuario;
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
           
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ActualizarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdPersona", usuario.IdPersona);
                    comando.Parameters.AddWithValue("@UsuarioCodigo", usuario.UsuarioCodigo);
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@Reset", usuario.Reset);
                    comando.Parameters.AddWithValue("@Estado", usuario.Estado);

                    conexion.Open();
                    comando.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            return usuario;
        }

        public int BorrarUsuario(int IdPersona)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_BorrarUsuario", conexion))
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

        public List<Usuario> ListarUsuario()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ListarUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        entidad.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;

        }

        public Usuario RecuperarUsuarioPorCodigo(int IdPersona)
        {

            Usuario usuario = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ObtenerUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        usuario = LlenarEntidad(reader);
                        usuario.apellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
                        usuario.apellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
                        usuario.nombre = Convert.ToString(reader["Nombres"]);
                        usuario.nroDocumento = Convert.ToString(reader["NroDocidentidad"]);
                    }

                }
                conexion.Close();
            }

            return usuario;

        }

        public Usuario AutenticarUsuario(string UsuarioCodigo, byte[] Clave)
        {
            Usuario usuario = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ObtenerUsuarioAutenticado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@UsuarioCodigo", UsuarioCodigo);
                    comando.Parameters.AddWithValue("@Clave", Clave);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        usuario = LlenarEntidad(reader);
                        usuario.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
                    }
                }
                conexion.Close();
            }
            return usuario;
        }

        #endregion
    }
}