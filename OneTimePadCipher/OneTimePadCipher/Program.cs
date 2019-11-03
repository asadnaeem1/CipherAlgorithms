using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePadCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("One Time Pad Cipher\n1. Encrypt\n2. Decrypt");
            int choice = int.Parse(Console.ReadLine());
            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.Write("Key: ");
            string key = Console.ReadLine();
            if (input.Length != key.Length)
            {
                Console.Clear();
                Console.WriteLine("Input and Key should be of equal length");
                goto start;
            }
            string output = "";
            
            switch (choice)
            {
                //Ecryption
                case 1:
                //Decryption
                case 2:
                    for (int i = 0; i < input.Length; i++)
                    {
                        output += Convert.ToInt16((input[i] == '1') ^ (key[i] == '1'));
                    }
                        break;
            }
            Console.WriteLine("Output: " + output);
            Console.ReadKey();
        }
    }
}