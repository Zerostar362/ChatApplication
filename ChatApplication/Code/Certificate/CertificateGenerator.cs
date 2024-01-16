using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Certificate
{
    internal class CertificateGenerator
    {
        public static void CheckOrGenerate()
        {
            var checker = new CertificateCheck();

            if (checker.Check())
                return;

            var dn = new X500DistinguishedName("CN=ChatApp");

            using(RSA rsa = RSA.Create(2048))
            {
                var request = new CertificateRequest(dn, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));

                var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));

                var certBytes = certificate.Export(X509ContentType.Pkcs12, "123456789");
                File.WriteAllBytes("ChatApp.pfx", certBytes);
            }
        }
    }
}
