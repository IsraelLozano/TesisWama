using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Entidades.Base;

namespace Entidades
{
    [DataContract]
    public partial class Usuariocertificado : BEPaginacion
    {
        #region Propiedades
        [DataMember]  		public int IdPersona { get; set; }  		[DataMember]  		public string Nombre { get; set; }  		[DataMember]  		public DateTime InicioValidez { get; set; }  		[DataMember]  		public DateTime FinValidez { get; set; }  		[DataMember]  		public decimal TamanioKB { get; set; }  		[DataMember]  		public string Asunto { get; set; }  		[DataMember]  		public string Emision { get; set; }  		[DataMember]  		public string Correo { get; set; }  		[DataMember]  		public byte[] Certificado { get; set; }  		[DataMember]  		public string Extension { get; set; }  		[DataMember]  		public bool Estado { get; set; }  		
        #endregion
    }

    

}