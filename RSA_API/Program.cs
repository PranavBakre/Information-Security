using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace RSA_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text to be Encrpted");
            RSA Rsa = RSACryptoServiceProvider.Create(512);
            //Console.WriteLine(Rsa.ToXmlString(true));
            
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            var cypher = Rsa.Encrypt(ByteConverter.GetBytes("Hello"), RSAEncryptionPadding.OaepSHA1);
            Console.WriteLine(ByteConverter.GetString(cypher));
            var text = Rsa.Decrypt(cypher, RSAEncryptionPadding.OaepSHA1);
            Console.WriteLine(ByteConverter.GetString(text));
            //RSAParameters RsaParameters = new RSAParameters();
            RSAParameters rs = new RSAParameters();                   

        }
    }
}
