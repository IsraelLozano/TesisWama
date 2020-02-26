using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [DataContract]
    [Serializable]
    public partial class TipoDocIdentidad
    {

        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        
    }
}
