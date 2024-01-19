using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.ClientMessages.Utility.Encryption
{
    public class EncryptToBytes_Aes
    {
        public static byte[] Encrypt(TcpClientMessage message, byte[] key, byte[] IV)
        {
            if(message is null)
                throw new ArgumentNullException("message");
            if(key is null) 
                throw new ArgumentNullException("key");
            if (IV is null) 
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            using(Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using(MemoryStream msEncrypt = new MemoryStream())
                {
                    using(CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(message);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }
}
