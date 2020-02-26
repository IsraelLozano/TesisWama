using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatosSQL;

namespace LogicaNegocio
{
    public class TblcampusLN : BaseLN
    {
        #region ITblcampus Members Generales

        public Tblcampus InsertarTblcampus(Tblcampus tblcampus)
        {
            try
            {
                return new TblcampusDA().InsertarTblcampus(tblcampus);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblcampus ActualizarTblcampus(Tblcampus tblcampus)
        {
            try
            {
                return new TblcampusDA().ActualizarTblcampus(tblcampus);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblcampus> ListarTblcampus()
        {
            try
            {
                return new TblcampusDA().ListarTblcampus();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int AnularTblcampusPorCodigo(int CampusID)
        {
            try
            {
                return new TblcampusDA().AnularTblcampusPorCodigo(CampusID);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tblcampus RecuperarTblcampusPorCodigo(int CampusID)
        {
            try
            {
                return new TblcampusDA().RecuperarTblcampusPorCodigo(CampusID);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public IEnumerable<Tblcampus> ListarPaginadoTblcampus(string Filtro, int NumPag, int CantRegxPag)
        {
            try
            {
                return new TblcampusDA().ListarPaginadoTblcampus(Filtro, NumPag, CantRegxPag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }


        }

        public List<Tblcampus> ListarTblcampusPorZonas(int idzona)
        {
            try
            {
                return new TblcampusDA().ListarTblcampusPorZonas(idzona);
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
