using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SHA_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            try
            {
                FileStream file = new FileStream("Program.cs",FileMode.Open);
                byte[] ByteFile=new byte[file.Length];
                int BytesRead = file.Read(ByteFile);
                byte[] result = sha.ComputeHash(ByteFile);
                FileStream fout= new FileStream("ProgHash.txt",FileMode.Create);

                Console.WriteLine("Text");
                foreach (char ch in ByteFile)
                    Console.Write(ch);

                Console.WriteLine("\n\n\nHash Value");

                foreach (char ch in result)
                    Console.Write(ch);
                fout.Write(result);
                file.Close();
                fout.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
