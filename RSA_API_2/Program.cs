using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace RSA_API_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text to be Encrpted");
            RSA Rsa = new RSACryptoServiceProvider();
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            var cypher = Rsa.Encrypt(ByteConverter.GetBytes("Hello"),false);
            var text = Rsa.Decrypt(cypher, false);
            Console.WriteLine(ByteConverter.GetString(text));
            //RSAParameters RsaParameters = new RSAParameters();



        }
    }
}
