using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;
//using Entidades.Helpers;

namespace Entidades
{
    public partial class Tblusuario
    {
        #region generales

        public Tblusuario()
        {

        }

        public Tblusuario(IDataReader reader)
        {
            this.IdPersona = Convert.ToInt32(reader["IdPersona"]);
            this.UsuarioCodigo = Convert.ToString(reader["UsuarioCodigo"]);

            if (!Convert.IsDBNull(reader["Clave"]))
            {
                this.Clave = (byte[])(reader["Clave"]);
            }
            this.Reset = Convert.ToBoolean(reader["Reset"]);
            this.Estado = Convert.ToBoolean(reader["Estado"]);

        }

        #endregion


        #region Propiedades Adicionales
        public string NombreCompleto { get; set; }
        public bool TieneCertificado { get; set; }
        public DateTime? VigenciaCertificado { get; set; }

        public string textoClave { get; set; }
        #endregion


        #region Lista de Entidades


        #endregion


    }



}