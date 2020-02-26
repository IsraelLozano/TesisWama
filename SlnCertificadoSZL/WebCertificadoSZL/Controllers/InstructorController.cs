using Entidades;
using LogicaNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCertificadoSZL.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public TipoDocIdentidadLN oTipoDocIdentidadLN = new TipoDocIdentidadLN();
        public EstadoCivilLN oEstadoCivilLN = new EstadoCivilLN();
        public SexoLN oSexoLN = new SexoLN();

        public ActionResult Index(string btnBuscar = "", string txtFiltro = "")
        {
            var lista = new TblinstructorLN().ListarTblinstructor();
            if (!string.IsNullOrEmpty(btnBuscar))
            {
                lista = lista.Where(x => x.NombreInstructor.Contains(txtFiltro));
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_GrillaInstructor", lista);
            }

            return View(lista);
        }

        public ActionResult NuevoInstructor(int idPersona = 0)
        {
            LlenarCombos();

            var persona = new Persona
            {
                IdPersona = idPersona,
                Instructor = new Tblinstructor()
            };

            if (idPersona > 0)
            {
                persona = new PersonaLN().RecuperarPersonaPorCodigo(idPersona);
            }

            return PartialView("_ModalInstructor", persona);

        }

        [HttpPost]
        public ActionResult NuevoInstructor(Persona model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    new PersonaLN().GrabarInstructorCompleto(model);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", ex.Message);
                }
            }
            LlenarCombos();
            return PartialView("_ModalInstructor", model);

            

        }


        [NonAction]
        public void LlenarCombos()
        {
            var listaTipoIdentidad = oTipoDocIdentidadLN.ListarTipoDocIdentidad();
            var listaEstadoCivil = oEstadoCivilLN.ListarEstadoCivil();
            var listaSexo = oSexoLN.ListarSexo();
            var listaZonales = new TblzonalesLN().ListarTblzonales();

            ViewBag.TipoDocumentoIdentidad = listaTipoIdentidad;
            ViewBag.EstadoCivil = listaEstadoCivil;
            ViewBag.ListaSexo = listaSexo;
            ViewBag.ListaZonales = listaZonales;
            
        }

    }
}