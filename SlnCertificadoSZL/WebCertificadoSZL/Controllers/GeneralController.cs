using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;
using log4net;
using WebCertificadoSZL.Log;
using WebCertificadoSZL.Controllers.Base;
using LogicaNegocio;

namespace WebCertificadoSZL.Controllers
{
    public class GeneralController : Controller
    {
        public PersonaLN oPersonaLN = new PersonaLN();
        public TipoDocIdentidadLN oTipoDocIdentidadLN = new TipoDocIdentidadLN();
        public EstadoCivilLN oEstadoCivilLN  = new EstadoCivilLN();
        public SexoLN oSexoLN = new SexoLN();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        #region "Tablas Generales"

        public ActionResult ListarPersona(string btnBuscar = "", string txtFiltro = "")
        {
            //var lista = new PersonaLN().ListarZona();
            var lista = oPersonaLN.ListarPersona();

            if (!string.IsNullOrEmpty(btnBuscar))
            {
                lista = lista.Where(x => x.NombreCompleto.Contains(txtFiltro) 
                || x.NroDocidentidad.Contains(txtFiltro)            
                ).ToList();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_GrillaPersona", lista);
            }

            return View(lista);
        }

        public ActionResult AgregarPersona(int idpersona = 0)
        {

            var persona = new Persona { IdPersona = idpersona };

            if (idpersona > 0)
            {
                persona = oPersonaLN.RecuperarPersonaPorCodigo(idpersona);
            }

            return PartialView("_ModalPersona", idpersona);
        }

        public ActionResult NuevaPersona(int idPersona = 0)
        {
            var listaTipoIdentidad = oTipoDocIdentidadLN.ListarTipoDocIdentidad();
            var listaEstadoCivil = oEstadoCivilLN.ListarEstadoCivil();
            var listaSexo = oSexoLN.ListarSexo();

            var persona = new Persona { IdPersona = idPersona };

            if (idPersona > 0)
            {
                persona = oPersonaLN.RecuperarPersonaPorCodigo(idPersona);
            }

            ViewBag.TipoDocumentoIdentidad = listaTipoIdentidad;
            ViewBag.EstadoCivil = listaEstadoCivil;
            ViewBag.ListaSexo = listaSexo;

            return PartialView("_ModalPersona", persona);

        }

        [HttpPost]
        public ActionResult NuevaPersona(Persona persona)
        {
            ModelState.Clear();
            if (persona.TipoDocIdentidad==0)
            {
                ModelState.AddModelError("TipoDocIdentidad", "Debe seleccionar el tipo de documento");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (persona.IdPersona == 0)
                    {
                        //new UsuarioLN().inse(persona);
                        oPersonaLN.InsertarPersona(persona);
                    }
                    else
                    {
                        //new UsuarioLN().ActualizarUsuario(persona);
                        oPersonaLN.ActualizarPersona(persona);
                    }
                    return Json("", JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", ex.Message);
                }
            }
            //var Marcas = simaService.Proxy.ListarMarca().Where(x => x.Situacion == (int)EnumTipoSituacion.Registrada); 
            LlenarCombos();

            return PartialView("_DetalleModalPersona", persona);
        }
        [NonAction]
        public void LlenarCombos()
        {
            var listaTipoIdentidad = oTipoDocIdentidadLN.ListarTipoDocIdentidad();
            var listaEstadoCivil = oEstadoCivilLN.ListarEstadoCivil();
            var listaSexo = oSexoLN.ListarSexo();

            ViewBag.TipoDocumentoIdentidad = listaTipoIdentidad;
            ViewBag.EstadoCivil = listaEstadoCivil;
            ViewBag.ListaSexo = listaSexo;

        }

        public ActionResult AnularPersona(int idPersona = 0)
        {
            try
            {
                var resp = oPersonaLN.AnularPersonaPorCodigo(idPersona);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


        #region solo Maestros tipos
        public ActionResult ListarCampus(int idzona = 0)
        {
            var campus = new TblcampusLN().ListarTblcampusPorZonas(idzona);
            return Json(campus,JsonRequestBehavior.AllowGet);

        }

        #endregion


    }
}