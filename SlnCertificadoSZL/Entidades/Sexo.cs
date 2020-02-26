using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Entidades
{
    public partial class Sexo
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

    }
}
