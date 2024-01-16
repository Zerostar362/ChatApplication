using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Certificate
{
    internal class CertificateCheck
    {
        private string filePath = "ChatApp.pfx";
        private string password = "123456789";

        internal bool Check()
        {
            if (!File.Exists(filePath))
                return false;

            X509Certificate2 certificate = new X509Certificate2(filePath);

            if (!IsCertificateValid(certificate))
                return false;

            return true;
        }

        private bool IsCertificateValid(X509Certificate2 certificate) =>
            certificate.NotBefore <= DateTime.Now && DateTime.Now <= certificate.NotAfter;
    }
}
