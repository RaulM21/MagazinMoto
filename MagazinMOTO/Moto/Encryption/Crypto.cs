using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class Crypto
    {
        byte[] IV, key,benc;
        public string Crypt(string Secret)
        {
            AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();
            IV = cryptoProvider.IV;
            key = cryptoProvider.Key;
            ICryptoTransform encryptor = cryptoProvider.CreateEncryptor();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cryptStream);
            sw.WriteLine(Secret);
            sw.Close();
            cryptStream.Close();
            memoryStream.Close();
            benc = memoryStream.ToArray();
            return System.Text.Encoding.UTF8.GetString(benc);
        }
    }
}
