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
    public partial class PersonaAD
    {
        #region PersonaAD

        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        /// <summary>
        /// Metodo que llena la Entidad con un DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Entidad Persona con datos llenos</returns>
        public Persona LlenarEntidad(IDataReader reader)
        {
            Persona persona = new Persona();
            persona.IdPersona = Convert.ToInt32(reader["IdPersona"]);
            persona.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
            persona.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
            persona.Nombres = Convert.ToString(reader["Nombres"]);
            persona.TipoDocIdentidad = Convert.ToInt32(reader["TipoDocIdentidad"]);
            persona.NroDocidentidad = Convert.ToString(reader["NroDocidentidad"]);
           if (!Convert.IsDBNull(reader["FechaNacimiento"]))
            {
                persona.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
            }
            persona.TipoEstadoCivil = Convert.ToInt32(reader["TipoEstadoCivil"]);
            persona.Sexo = Convert.ToString(reader["Sexo"]);
            persona.Telefono1 = Convert.ToString(reader["Telefono1"]);
            persona.Telefono2 = Convert.ToString(reader["Telefono2"]);
            persona.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
           
            return persona;

        }


        public Persona InsertarPersona(Persona persona)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_InsertarPersona", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@ApellidoPaterno", persona.ApellidoPaterno.Trim());
                    comando.Parameters.AddWithValue("@ApellidoMaterno", persona.ApellidoMaterno.Trim());
                    comando.Parameters.AddWithValue("@Nombres", persona.Nombres.Trim());
                    comando.Parameters.AddWithValue("@TipoDocIdentidad", persona.TipoDocIdentidad);
                    comando.Parameters.AddWithValue("@NroDocidentidad", persona.NroDocidentidad.Trim());
                    comando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                    comando.Parameters.AddWithValue("@TipoEstadoCivil", persona.TipoEstadoCivil);
                    comando.Parameters.AddWithValue("@Sexo", persona.Sexo);
                    comando.Parameters.AddWithValue("@Telefono1", persona.Telefono1.Trim());
                    comando.Parameters.AddWithValue("@Telefono2", persona.Telefono2.Trim());
                                      
                    conexion.Open();
                    persona.IdPersona = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return persona;


        }

        public Persona ActualizarPersona(Persona persona)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ActualizarPersona", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                    comando.Parameters.AddWithValue("@ApellidoPaterno", persona.ApellidoPaterno.Trim());
                    comando.Parameters.AddWithValue("@ApellidoMaterno", persona.ApellidoMaterno.Trim());
                    comando.Parameters.AddWithValue("@Nombres", persona.Nombres.Trim());
                    comando.Parameters.AddWithValue("@TipoDocIdentidad", persona.TipoDocIdentidad);
                    comando.Parameters.AddWithValue("@NroDocidentidad", persona.NroDocidentidad.Trim());
                    comando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                    comando.Parameters.AddWithValue("@TipoEstadoCivil", persona.TipoEstadoCivil);
                    comando.Parameters.AddWithValue("@Sexo", persona.Sexo);
                    comando.Parameters.AddWithValue("@Telefono1", persona.Telefono1.Trim());
                    comando.Parameters.AddWithValue("@Telefono2", persona.Telefono2.Trim());
                  
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            return persona;
        }


        public int BorrarPersona(int IdPersona)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_BorrarPersona", conexion))
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


        public List<Persona> ListarPersona()
        {
            List<Persona> listaEntidad = new List<Persona>();
            Persona entidad = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ListarPersona", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        entidad.NombreSexo = Convert.ToString(reader["NombreSexo"]);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;

        }


        public Persona RecuperarPersonaPorCodigo(int IdPersona)
        {

            Persona persona = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ObtenerPersona", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        persona = LlenarEntidad(reader);
                    }

                }
                conexion.Close();
            }

            return persona;

        }

        #endregion

    }



}