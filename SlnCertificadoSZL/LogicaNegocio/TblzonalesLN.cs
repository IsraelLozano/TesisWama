using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatosSQL;


namespace LogicaNegocio
{
    public class TblzonalesLN : BaseLN
    {
        #region ITblzonales Members Generales

        public Tblzonales InsertarTblzonales(Tblzonales tblzonales)
        {
            try
            {
                return new TblzonalesDA().InsertarTblzonales(tblzonales);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblzonales ActualizarTblzonales(Tblzonales tblzonales)
        {
            try
            {
                return new TblzonalesDA().ActualizarTblzonales(tblzonales);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblzonales> ListarTblzonales()
        {
            try
            {
                return new TblzonalesDA().ListarTblzonales();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularTblzonalesPorCodigo(int ZonalID)
        {
            try
            {
                return new TblzonalesDA().AnularTblzonalesPorCodigo(ZonalID);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblzonales RecuperarTblzonalesPorCodigo(int ZonalID)
        {
            try
            {
                return new TblzonalesDA().RecuperarTblzonalesPorCodigo(ZonalID);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblzonales> ListarPaginadoTblzonales(string Filtro, int NumPag, int CantRegxPag)
        {
            try
            {
                return new TblzonalesDA().ListarPaginadoTblzonales(Filtro, NumPag, CantRegxPag);
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
