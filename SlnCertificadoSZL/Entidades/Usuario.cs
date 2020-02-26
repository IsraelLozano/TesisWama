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
    public partial class Usuario
    {
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public string UsuarioCodigo { get; set; }
        [DataMember]
        public byte[] Clave { get; set; }
        [DataMember]
        public bool Reset { get; set; }
        [DataMember]
        public bool Estado { get; set; }
       

        #region Extensiones
        [Required(ErrorMessage = "Debe ingresar una clave")]
        public string textoClave { get; set; }
        [Required(ErrorMessage ="Apellido Paterno es obligatorio")]
        public string apellidoPaterno { get; set; }
        [Required(ErrorMessage ="Apellido Materno es obligatorio")]
        public string apellidoMaterno { get; set; }
        [Required(ErrorMessage ="Nombre es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage ="Nro Documento es obligatorio")]
        public string nroDocumento { get; set; }
        public string NombreCompleto { get; set; }

        #endregion

    }
}