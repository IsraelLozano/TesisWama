using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatosSQL;


namespace LogicaNegocio
{
    public class UsuariocertificadoLN : BaseLN
    {
        #region IUsuariocertificado Members Generales

        public Usuariocertificado InsertarUsuariocertificado(Usuariocertificado usuariocertificado)
        {
            try
            {
                return new UsuariocertificadoDA().InsertarUsuariocertificado(usuariocertificado);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Usuariocertificado ActualizarUsuariocertificado(Usuariocertificado usuariocertificado)
        {
            try
            {
                return new UsuariocertificadoDA().ActualizarUsuariocertificado(usuariocertificado);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Usuariocertificado> ListarUsuariocertificado()
        {
            try
            {
                return new UsuariocertificadoDA().ListarUsuariocertificado();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularUsuariocertificadoPorCodigo(int IdPersona)
        {
            try
            {
                return new UsuariocertificadoDA().AnularUsuariocertificadoPorCodigo(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Usuariocertificado RecuperarUsuariocertificadoPorCodigo(int IdPersona)
        {
            try
            {
                return new UsuariocertificadoDA().RecuperarUsuariocertificadoPorCodigo(IdPersona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Usuariocertificado> ListarPaginadoUsuariocertificado(string Filtro, int NumPag, int CantRegxPag)
        {
            try
            {
                return new UsuariocertificadoDA().ListarPaginadoUsuariocertificado(Filtro, NumPag, CantRegxPag);
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
