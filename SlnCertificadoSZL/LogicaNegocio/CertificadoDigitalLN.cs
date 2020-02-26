using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;


namespace Negocio
{
    public class CertificadoDigitalLN
    {
        //public X509Certificate2 GetClienteCertificate()
        //{
        //    X509Store userCaStore = new X509Store(StoreLocation.
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public void mostrarDatosCertificado()
        {
            X509Certificate2 certificate = new X509Certificate2(@"C:\FacturacionCPE\20103840369\Certificados\20103840369.cer");

            string expirationDate = certificate.GetExpirationDateString();
            string issuer = certificate.Issuer;
            string effectiveDateString = certificate.GetEffectiveDateString();
            string nameInfo = certificate.GetNameInfo(X509NameType.SimpleName, true);
            bool hasPrivateKey = certificate.HasPrivateKey;
        }
       
    }
}
