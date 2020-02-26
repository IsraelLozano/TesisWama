using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Entidades.Base;

namespace Entidades
{
    [DataContract]
    public partial class Tblusuario : BEPaginacion
    {
        #region Propiedades
        [DataMember]  		public int IdPersona { get; set; }  		[DataMember]  		public string UsuarioCodigo { get; set; }  		[DataMember]  		public byte[] Clave { get; set; }  		[DataMember]  		public bool Reset { get; set; }  		[DataMember]  		public bool Estado { get; set; }  		
        #endregion
    }

    

}