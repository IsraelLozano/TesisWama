using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;
//using Entidades.Helpers;

namespace Entidades
{
    public partial class Tblinstructor 
    {
        #region generales

        public Tblinstructor()
        {

        }

        public Tblinstructor(IDataReader reader)
        {
            			this.Id = Convert.ToInt32(reader["Id"]);  
			this.IdPersona = Convert.ToInt32(reader["IdPersona"]);  
			this.NombreInstructor = Convert.ToString(reader["NombreInstructor"]);  
			this.ZonalId = Convert.ToInt32(reader["ZonalId"]);  
			this.CampusId = Convert.ToInt32(reader["CampusId"]);  
			if (!Convert.IsDBNull(reader["Estado"]))  			{				this.Estado = Convert.ToBoolean(reader["Estado"]);  			}
        }

        #endregion


        #region Propiedades Adicionales
        public string NombreZona { get; set; }
        public string NombreCampus { get; set; }

        #endregion


        #region Lista de Entidades


        #endregion


    }

    

}