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
    public partial class EstadoCivilAD
    {

        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        public EstadoCivil LlenarEntidad(IDataReader reader)
        {
            EstadoCivil estadoCivil = new EstadoCivil();
            estadoCivil.Codigo = Convert.ToInt32(reader["Codigo"]);
            estadoCivil.Descripcion = Convert.ToString(reader["Descripcion"]);
            //estadoCivil.Estado = Convert.ToBoolean(reader["Estado"]);

            return estadoCivil;

        }

        public List<EstadoCivil> ListarEstadoCivil()
        {
            List<EstadoCivil> listaEntidad = new List<EstadoCivil>();
            EstadoCivil entidad = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ComboEstadoCivil", conexion))
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
