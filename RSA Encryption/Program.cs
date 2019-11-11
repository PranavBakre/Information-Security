using System;
using System.Collections.Generic;



namespace RSA_Encryption
{
    class Program
    {


        static long p, q;
        static Tuple<long, long> EncryptionKey;
        static Tuple<long, long> DecryptionKey;



        public static List<long> GeneratePrime(long num)
        {
            List<long> primes = new List<long> {2,3 };
            List<long> PrimeDivider = new List<long>();
            for (long i=4;i<=num/2;i++)
            {
                foreach (long j in primes)
                {
                    if (j*j > i)
                    {
                        primes.Add(i);
                        break;
                    }
                    else if (i%j==0)
                    {

                        break;
                        
                    }
                }

            }
            foreach (long i in primes)
            {

                if (num%i==0)
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

        public static Tuple<long,long,long,long> KeyGen(long p,long q)
        {
            var n = p * q;
            var z = (p - 1) * (q - 1);
            long d = 0;
            long e = CoPrime(z);
            long i = 0;
            while (d == 0)
            {

                if (i * e % z == 1)
                {
                    d = i;
                    break;
                }
                i++;
            }

            Console.WriteLine(" " + d + " " + e + " " + z + " " + n);
            return Tuple.Create(e, d, z,n);

        }


        public static long[] Encrypt(string message,Tuple<long,long> EnryptionKey)
        {
            var MessageArray = message.ToCharArray();
            var EncryptionArray = new long[MessageArray.Length];
            for (long i=0;i<MessageArray.Length;i++)
            {
                var c = Math.Pow(((long)MessageArray[i]-97), EncryptionKey.Item1) % EncryptionKey.Item2;
               
                
                EncryptionArray[i] = (long)c;
            }
            return EncryptionArray;
        }


        public static string Decrypt(long[] EncryptedArray,Tuple<long,long> DecryptionKey)
        {


            var DecryptedArray = new char[EncryptedArray.Length];

            for (long i = 0; i < EncryptedArray.Length; i++)
            {
                var d = Math.Pow(EncryptedArray[i], DecryptionKey.Item1) % DecryptionKey.Item2;
                DecryptedArray[i] = (char)(d+97);
            }
            return new string(DecryptedArray);
        }
        public  static void Main(string[] args)
        {


            p = 11; q = 3;
            Tuple<long, long, long, long> Keys = KeyGen(p, q);
            EncryptionKey = new Tuple<long, long>(Keys.Item1,Keys.Item4);
            DecryptionKey = new Tuple<long, long>(Keys.Item2, Keys.Item4);
            Console.WriteLine("Enter the message to be encrypted");
            var Message = Console.ReadLine();

            var EncryptedMessage = Encrypt(Message, EncryptionKey);
            Console.Write("Encrypted Message:");
            foreach (int i in EncryptedMessage)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            var DecryptedMessage=Decrypt(EncryptedMessage,DecryptionKey);

            Console.WriteLine("Decrypted Message: "+ DecryptedMessage);
        }



    }
}
