using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Entidades.Base;

namespace Entidades
{
    [DataContract]
    public partial class Tblzonales : BEPaginacion
    {
        #region Propiedades
        [DataMember]  		public int ZonalID { get; set; }  		[DataMember]  		public string ZonalDes { get; set; }  		[DataMember]  		public string ZonalCod { get; set; }  		
        #endregion
    }

    

}