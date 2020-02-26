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
    public class SexoLN:BaseLN 
    {
        public List<Sexo> ListarSexo()
        {
            try
            {
                return new SexoAD().ListarSexo();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


    }
}
