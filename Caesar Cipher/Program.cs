using System;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            var Message = Console.ReadLine();
            var EncryptionString = Encrypt(Message);
            Console.WriteLine($"Encrypted Message={EncryptionString}");
            Console.WriteLine("Decrypted Message={0}", Decrypt(EncryptionString));
        }

        public static string Encrypt(string Message)
        {


            char[] MessageArray, EncryptedMessage;
            MessageArray = Message.ToCharArray();
            EncryptedMessage = new char[MessageArray.Length];

            for (int i = 0; i < MessageArray.Length; i++)
            {
                if (MessageArray[i] >= 'x' && MessageArray[i] <= 'z')
                {
                    EncryptedMessage[i] = (char)(MessageArray[i] % 120 + 97);
                }
                else if (MessageArray[i] >= 'X' && MessageArray[i] <= 'Z')
                {
                    EncryptedMessage[i] = (char)(MessageArray[i] % 90 + 65);
                }
                else
                {
                    EncryptedMessage[i] = (char)(MessageArray[i] + 3);
                }
            }


            return (new string(EncryptedMessage));

        }

        public static string Decrypt(string EncryptedMessage)
        {
            var EncryptedArray = EncryptedMessage.ToCharArray();
            char[] DecryptionArray = new char[EncryptedArray.Length];
            for (int i = 0; i < EncryptedArray.Length; i++)
            {
                if ((EncryptedArray[i] <= 67 && EncryptedArray[i] >= 65) || (EncryptedArray[i] <= 99 && EncryptedArray[i] >= 97))
                {
                    DecryptionArray[i] = (char)(EncryptedArray[i] + 26 - 3);
                }

                else
                {
                    DecryptionArray[i] = (char)(EncryptedArray[i] - 3);
                }
            }
            return (new string(DecryptionArray));
        }

    }
}
