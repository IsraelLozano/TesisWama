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
    public partial class TipoDocIdentidadAD
    {

        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        /// <summary>
        /// Metodo que llena la Entidad con un DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Entidad Persona con datos llenos</returns>
        public TipoDocIdentidad LlenarEntidad(IDataReader reader)
        {
            TipoDocIdentidad  tipoDocIdentidad = new TipoDocIdentidad();
            tipoDocIdentidad.Codigo = Convert.ToInt32(reader["Codigo"]);
            tipoDocIdentidad.Descripcion = Convert.ToString(reader["Descripcion"]);
            
            return tipoDocIdentidad;

        }

        public List<TipoDocIdentidad> ListarTipoDocIdentidad()
        {
            List<TipoDocIdentidad> listaEntidad = new List<TipoDocIdentidad>();
            TipoDocIdentidad entidad = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ComboTipoDocIdentidad", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;

        }
    }
}
