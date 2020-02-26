using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace WebCertificadoSZL.Controllers
{
    public class CertificadoController : Controller
    {
        // GET: Certificado
        public ActionResult Index()
        {
            X509Certificate2 certificate = new X509Certificate2(@"C:\FacturacionCPE\20103840369\Certificados\20103840369.cer");

            ViewBag.expirationDate = certificate.GetExpirationDateString();
            ViewBag.issuer = certificate.Issuer;
            ViewBag.effectiveDateString = certificate.GetEffectiveDateString();
            ViewBag.nameInfo = certificate.GetNameInfo(X509NameType.SimpleName, true);
            ViewBag.hasPrivateKey = certificate.HasPrivateKey;

            return View();
        }

        public ActionResult ComponenteFirma()
        {

            return View();
        }

        [HttpPost]
        public ActionResult FirmaDocumento(HttpPostedFileBase file)
        {
            return View();
        }

    }
}