using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Entidades.Base;

namespace Entidades
{
    [DataContract]
    public partial class Tblinstructor : BEPaginacion
    {
        #region Propiedades
        [DataMember]  		public int Id { get; set; }  		[DataMember]  		public int IdPersona { get; set; }  		[DataMember]  		public string NombreInstructor { get; set; }  		[DataMember]  		public int ZonalId { get; set; }  		[DataMember]  		public int CampusId { get; set; }  		[DataMember]  		public bool Estado { get; set; }  		
        #endregion
    }

    

}