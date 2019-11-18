using System;
using System.Collections.Generic;
namespace MonoAlphabetic_Cypher
{
    class Program
    {
        static Dictionary<char, char> D;
        static void Main(string[] args)
        {
            D = new Dictionary<char, char>();
            int n = 122;
            for (char i = (char)97, j = (char)n; i <= n; i++, j--)
            {

                //var d = Convert.ToChar(Console.ReadLine());
                D.Add(i, j/*d*/);
            }
            n = 90;
            for (char i = (char)65, j = (char)n; i <= n; i++, j--)
            {

                //var d = Convert.ToChar(Console.ReadLine());
                D.Add(i, j/*d*/);
            }
            D.Add(' ', ' ');

            Console.WriteLine("Enter the string");
            var Message = Console.ReadLine();
            var EncryptedMessage = Encrypt(Message);
            Console.WriteLine($"\n\n\nEncrypted Message: {EncryptedMessage}");
            var DecryptedMessage = Decrypt(EncryptedMessage);

            Console.WriteLine($"Decrypted Message: { DecryptedMessage}");


        }

        public static string Encrypt(string Message)
        {
            var MessageArray = Message.ToCharArray();
            char[] EncryptionString = new char[MessageArray.Length];
            for (int i = 0; i < MessageArray.Length; i++)
            {
                EncryptionString[i] = D[MessageArray[i]];
            }
            return new string(EncryptionString);
        }

        public static string Decrypt(string EncryptedMessage)
        {
            var EncryptedArray = EncryptedMessage.ToCharArray();
            char[] DecryptedArray = new char[EncryptedArray.Length];
            for (int i = 0; i < EncryptedArray.Length; i++)
            {

                foreach (KeyValuePair<char, char> K in D)
                {
                    if (K.Value == EncryptedArray[i])
                    {
                        DecryptedArray[i] = K.Key;
                    }
                }

            }


            return new string(DecryptedArray);
        }
    }
}
