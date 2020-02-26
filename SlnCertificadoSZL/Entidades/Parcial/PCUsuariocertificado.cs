using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;
//using Entidades.Helpers;

namespace Entidades
{
    public partial class Usuariocertificado 
    {
        #region generales

        public Usuariocertificado()
        {

        }

        public Usuariocertificado(IDataReader reader)
        {
            			this.IdPersona = Convert.ToInt32(reader["IdPersona"]);  
			this.Nombre = Convert.ToString(reader["Nombre"]);  
			this.InicioValidez = Convert.ToDateTime(reader["InicioValidez"]);  
			this.FinValidez = Convert.ToDateTime(reader["FinValidez"]);  
			this.TamanioKB = Convert.ToDecimal(reader["TamanioKB"]);  
			this.Asunto = Convert.ToString(reader["Asunto"]);  
			this.Emision = Convert.ToString(reader["Emision"]);  
			this.Correo = Convert.ToString(reader["Correo"]);  
			if (!Convert.IsDBNull(reader["Certificado"]))  			{				this.Certificado = (byte[])(reader["Certificado"]);  			}			this.Extension = Convert.ToString(reader["Extension"]);  
			this.Estado = Convert.ToBoolean(reader["Estado"]);  

        }

        #endregion

        
        #region Propiedades Adicionales

        
        #endregion
        
        
        #region Lista de Entidades

        
        #endregion


    }

    

}