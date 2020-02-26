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
    public class TipoDocIdentidadLN : BaseLN
    {

        public List<TipoDocIdentidad> ListarTipoDocIdentidad()
        {
            try
            {
                return new TipoDocIdentidadAD().ListarTipoDocIdentidad();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
