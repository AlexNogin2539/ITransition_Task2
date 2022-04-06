using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SHA3.Net;

namespace Task2_ITransition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> HashList = new List<string>();

            string[] files = Directory.GetFiles("task2");
            foreach (string file in files)
            {
                byte[] data = File.ReadAllBytes(file);
                using (var shaAlg = Sha3.Sha3256())
                {
                    var hash = shaAlg.ComputeHash(data);
                    var strb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        strb.Append(hash[i].ToString("x2"));
                    }
                    Console.WriteLine($"Hash({file}): " + strb.ToString());
                    HashList.Add(strb.ToString());
                }
            }

            HashList.Sort();

            string result = string.Join("", HashList);
            string final = string.Concat(result, "alexnogin.ru@gmail.com");
            using (var shaAlg = Sha3.Sha3256())
            {
                var finalHash = shaAlg.ComputeHash(Encoding.UTF8.GetBytes(final));
                var stringBuilder = new StringBuilder();
                for (int i = 0; i < finalHash.Length; i++)
                {
                    stringBuilder.Append(finalHash[i].ToString("x2"));
                }

                Console.WriteLine("Final hash is: " + stringBuilder.ToString());
            }

            Console.WriteLine("Press any key to close the programm. . .");
            Console.ReadKey();
        }
    }
}
