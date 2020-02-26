using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using LogicaNegocio;
using Infraestructura.Log;

namespace Negocio
{
    public class EstadoCivilLN : BaseLN
    {
        public List<EstadoCivil> ListarEstadoCivil()
        {
            try
            {
                return new EstadoCivilAD().ListarEstadoCivil();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

    }
}
