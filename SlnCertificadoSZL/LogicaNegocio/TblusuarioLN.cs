using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatosSQL;


namespace LogicaNegocio
{
    public class TblusuarioLN : BaseLN
    {
        #region ITblusuario Members Generales

        public Tblusuario InsertarTblusuario(Tblusuario tblusuario)
        {
            try
            {
                return new TblusuarioDA().InsertarTblusuario(tblusuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblusuario ActualizarTblusuario(Tblusuario tblusuario)
        {
            try
            {
                return new TblusuarioDA().ActualizarTblusuario(tblusuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblusuario> ListarTblusuario()
        {
            try
            {
                return new TblusuarioDA().ListarTblusuario();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularTblusuarioPorCodigo(int IdPersona)
        {
            try
            {
                return new TblusuarioDA().AnularTblusuarioPorCodigo(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblusuario RecuperarTblusuarioPorCodigo(int IdPersona)
        {
            try
            {
                return new TblusuarioDA().RecuperarTblusuarioPorCodigo(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblusuario> ListarPaginadoTblusuario(string Filtro, int NumPag, int CantRegxPag)
        {
            try
            {
                return new TblusuarioDA().ListarPaginadoTblusuario(Filtro, NumPag, CantRegxPag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            
            
        }

        #endregion

        #region Extensiones


        #endregion
    }
}
