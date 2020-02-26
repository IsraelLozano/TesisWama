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
    public partial class Persona
    {

        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public int TipoDocIdentidad { get; set; }
        [DataMember]
        public string NroDocidentidad { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public int TipoEstadoCivil { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Telefono1 { get; set; }
        [DataMember]
        public string Telefono2 { get; set; }
        [DataMember]
        public string NombreCompleto { get; set; }



        //[DataMember]
        //public Boolean  flg_estado { get; set; }

        #region "Adicionales#

        [DataMember]
        public string NombreSexo { get; set; }

        public string getRetornarNombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", ApellidoPaterno, ApellidoMaterno, Nombres);
            }
        }

        #endregion

        #region Entidades por niveles
        [DataMember]
        public Tblinstructor Instructor { get; set; }

        #endregion

    }



}