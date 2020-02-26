using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatosSQL;


namespace LogicaNegocio
{
    public class TblinstructorLN : BaseLN
    {
        #region ITblinstructor Members Generales

        public Tblinstructor InsertarTblinstructor(Tblinstructor tblinstructor)
        {
            try
            {
                return new TblinstructorDA().InsertarTblinstructor(tblinstructor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblinstructor ActualizarTblinstructor(Tblinstructor tblinstructor)
        {
            try
            {
                return new TblinstructorDA().ActualizarTblinstructor(tblinstructor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblinstructor> ListarTblinstructor()
        {
            try
            {
                return new TblinstructorDA().ListarTblinstructor();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularTblinstructorPorCodigo(int Id)
        {
            try
            {
                return new TblinstructorDA().AnularTblinstructorPorCodigo(Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblinstructor RecuperarTblinstructorPorCodigo(int Id)
        {
            try
            {
                return new TblinstructorDA().RecuperarTblinstructorPorCodigo(Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tblinstructor> ListarTblinstructorPendientes()
        {
            try
            {
                return new TblinstructorDA().ListarTblinstructorPendientes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblinstructor> ListarPaginadoTblinstructor(string Filtro, int NumPag, int CantRegxPag)
        {
            try
            {
                return new TblinstructorDA().ListarPaginadoTblinstructor(Filtro, NumPag, CantRegxPag);
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
