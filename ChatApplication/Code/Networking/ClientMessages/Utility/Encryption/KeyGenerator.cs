using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.ClientMessages.Utility.Encryption
{
    public static class KeyGenerator
    {
        const string chars = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm123456789";
        private static Random random = new Random();
        public static string GenerateKey() => new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
