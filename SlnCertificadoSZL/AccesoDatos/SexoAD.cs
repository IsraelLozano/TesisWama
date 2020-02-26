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
    public partial  class SexoAD
    {

        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        public Sexo LlenarEntidad(IDataReader reader)
        {
            Sexo sexo = new Sexo();
            sexo.Codigo = Convert.ToString(reader["Codigo"]);
            sexo.Descripcion = Convert.ToString(reader["Descripcion"]);
            //estadoCivil.Estado = Convert.ToBoolean(reader["Estado"]);

            return sexo;

        }

        public List<Sexo> ListarSexo()
        {
            List<Sexo> listaEntidad = new List<Sexo>();
            Sexo entidad = null;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("pr_ComboSexo", conexion))
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
