using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;
//using Entidades.Helpers;

namespace Entidades
{
    public partial class Tblcampus
    {
        #region generales

        public Tblcampus()
        {

        }

        public Tblcampus(IDataReader reader)
        {
            this.CampusID = Convert.ToInt32(reader["CampusID"]);
            this.ZonalID = Convert.ToInt32(reader["ZonalID"]);
            this.CampusDes = Convert.ToString(reader["CampusDes"]);
            this.Direccion = Convert.ToString(reader["Direccion"]);
            this.Responsable = Convert.ToString(reader["Responsable"]);
            this.Cargo = Convert.ToString(reader["Cargo"]);
            this.Telefono = Convert.ToString(reader["Telefono"]);
            this.Email = Convert.ToString(reader["Email"]);
            this.Trabajadores = Convert.ToInt32(reader["Trabajadores"]);
            this.Afiliados = Convert.ToInt32(reader["Afiliados"]);
            this.InicioAct = Convert.ToInt32(reader["InicioAct"]);

        }

        #endregion


        #region Propiedades Adicionales


        #endregion


        #region Lista de Entidades


        #endregion


    }



}