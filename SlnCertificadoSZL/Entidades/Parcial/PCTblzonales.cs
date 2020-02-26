using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;
//using Entidades.Helpers;

namespace Entidades
{
    public partial class Tblzonales
    {
        #region generales

        public Tblzonales()
        {

        }

        public Tblzonales(IDataReader reader)
        {
            this.ZonalID = Convert.ToInt32(reader["ZonalID"]);
            this.ZonalDes = Convert.ToString(reader["ZonalDes"]);
            this.ZonalCod = Convert.ToString(reader["ZonalCod"]);

        }

        #endregion


        #region Propiedades Adicionales


        #endregion


        #region Lista de Entidades


        #endregion


    }



}