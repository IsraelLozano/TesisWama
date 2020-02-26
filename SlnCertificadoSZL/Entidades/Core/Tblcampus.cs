using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Entidades.Base;

namespace Entidades
{
    [DataContract]
    public partial class Tblcampus : BEPaginacion
    {
        #region Propiedades
        [DataMember]  		public int CampusID { get; set; }  		[DataMember]  		public int ZonalID { get; set; }  		[DataMember]  		public string CampusDes { get; set; }  		[DataMember]  		public string Direccion { get; set; }  		[DataMember]  		public string Responsable { get; set; }  		[DataMember]  		public string Cargo { get; set; }  		[DataMember]  		public string Telefono { get; set; }  		[DataMember]  		public string Email { get; set; }  		[DataMember]  		public int Trabajadores { get; set; }  		[DataMember]  		public int Afiliados { get; set; }  		[DataMember]  		public int InicioAct { get; set; }  		
        #endregion
    }

    

}