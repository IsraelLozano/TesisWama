using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Infraestructura.Tools;
using LogicaNegocio;
using Negocio;

namespace WebCertificadoSZL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index(string btnBuscar = "", string txtFiltro = "")
        {
            var lista = new TblusuarioLN().ListarTblusuario();
            if (!string.IsNullOrEmpty(btnBuscar))
            {
                lista = lista.Where(x => x.NombreCompleto.Contains(txtFiltro));
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_GrillaUsuario", lista);
            }

            return View(lista);
        }


        public ActionResult NuevoUsuario(int idPersona = 0)
        {
            LlenarCombos();
            var persona = new Tblusuario
            {
                IdPersona = idPersona,
                Estado = true
            };

            if (idPersona > 0)
            {
                persona = new TblusuarioLN().RecuperarTblusuarioPorCodigo(idPersona);
            }

            return PartialView("_ModalUsuario", persona);

        }

        [HttpPost]
        public ActionResult NuevoUsuario(Tblusuario model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.Clave= EncryptHelper.EncryptToByte(model.textoClave);
                    
                    new TblusuarioLN().InsertarTblusuario(model);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", ex.Message);
                }
            }
            LlenarCombos();
            return PartialView("_ModalUsuario", model);



        }

        [NonAction]
        public void LlenarCombos()
        {
            var listaInstructorPendiente = new TblinstructorLN().ListarTblinstructorPendientes();

            ViewBag.lista = listaInstructorPendiente;

        }

    }
}