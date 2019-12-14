using System;
using System.Collections.Generic;
using System.Numerics;


namespace RSA_Encryption
{
    class Program
    {


        static long p, q;
        static Tuple<long, long> EncryptionKey;
        static Tuple<long, long> DecryptionKey;



        public static List<long> GeneratePrime(long num)
        {
            List<long> primes = new List<long> { 2, 3 };
            List<long> PrimeDivider = new List<long>();
            for (long i = 4; i <= num / 2; i++)
            {
                foreach (long j in primes)
                {
                    if (j * j > i)
                    {
                        primes.Add(i);
                        break;
                    }
                    else if (i % j == 0)
                    {

                        break;

                    }
                }

            }
            foreach (long i in primes)
            {

                if (num % i == 0)
                {
                    PrimeDivider.Add(i);
                }
            }
            return PrimeDivider;
        }



        public static long CoPrime(long num1)
        {
            int i = 0;
            long CoPrimeNo = 0;
            var pd = GeneratePrime(num1);
            for (long CoPrimeCandidate = 2; CoPrimeCandidate < num1 / 2; ++CoPrimeCandidate)
            {
                long counter = 0, j;
                for (i = 0; i < pd.Count; i++)
                {
                    j = pd[i];
                    if (CoPrimeCandidate % j != 0)
                    {
                        counter++;
                    }


                }
                if (counter == i)
                {
                    CoPrimeNo = CoPrimeCandidate;
                    break;
                }
            }
            return CoPrimeNo;
        }

        public static Tuple<long, long, long, long> KeyGen(long p, long q)
        {
            var n = p * q;
            var z = (p - 1) * (q - 1);
            long d = 0;
            long e = CoPrime(z);
            long i = 0;
            while (d == 0)
            {

                if ((i * e) % z == 1)
                {
                    d = i;
                    break;
                }
                i++;
            }

            Console.WriteLine(" " + d + " " + e + " " + z + " " + n);
            return Tuple.Create(e, d, z, n);

        }


        public static long[] Encrypt(string message, bool debug = false)
        {
            var MessageArray = message.ToCharArray();
            var EncryptionArray = new long[MessageArray.Length];
            if (debug)
                Console.WriteLine("Encryption:\n");
            for (long i = 0; i < MessageArray.Length; i++)
            {
                BigInteger d = BigInteger.ModPow(MessageArray[i], EncryptionKey.Item1, EncryptionKey.Item2);
                EncryptionArray[i] = (long)d;
                if (debug)
                {
                    Console.WriteLine($"\t\t{MessageArray[i]}==> {(int)MessageArray[i]}==> {d}");
                }
            }
            return EncryptionArray;
        }


        public static string Decrypt(long[] EncryptedArray, bool debug = false)
        {


            var DecryptedArray = new char[EncryptedArray.Length];
            if (debug)
                Console.WriteLine("\nDecryption:\n");

            for (long i = 0; i < EncryptedArray.Length; i++)
            {
                //Console.WriteLine(Math.Pow(EncryptedArray[i], DecryptionKey.Item1));

                var d = Math.Pow(EncryptedArray[i], DecryptionKey.Item1) % DecryptionKey.Item2;
                BigInteger e = BigInteger.ModPow(EncryptedArray[i], DecryptionKey.Item1, DecryptionKey.Item2);
                
                DecryptedArray[i] = (char)e;
                if (debug == true)
                {

                    Console.WriteLine($"\t\t{EncryptedArray[i]}==> {(int)DecryptedArray[i]}==> {DecryptedArray[i]}");
                }
            }
            return new string(DecryptedArray);
        }
        public static void Main(string[] args)
        {


            p = 59; q = 53;
            Tuple<long, long, long, long> Keys = KeyGen(p, q);
            EncryptionKey = new Tuple<long, long>(Keys.Item1, Keys.Item4);
            DecryptionKey = new Tuple<long, long>(Keys.Item2, Keys.Item4);
            Console.WriteLine("Enter the message to be encrypted");
            var Message = Console.ReadLine();


            var EncryptedMessage = Encrypt(Message);
            var DecryptedMessage = Decrypt(EncryptedMessage);
            Console.Write("Encrypted Message:");
            foreach (int i in EncryptedMessage)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("Decrypted Message: " + DecryptedMessage);
        }



    }
}
