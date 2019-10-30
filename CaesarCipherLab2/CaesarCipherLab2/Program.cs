using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Ceasar Cipher\n1. Encrypt\n2. Decrypt");
            char choice = Console.ReadKey().KeyChar;
            Console.Write("\nInput: ");
            string input = Console.ReadLine().ToLower();
            string output = "";
            switch (choice)
            {
                case '1':
                    for (int i = 0; i < input.Length; i++)
                    {
                        output += (char)((((int)input[i] -94)%26)+97);
                    };
                    break;
                case '2':
                    for (int i = 0; i < input.Length; i++)
                    {
                        int temp = (int)input[i] - 100;
                        if (temp < 0)
                        {
                            temp += 26;
                        }
                        output += (char)(((temp)%26)+97);
                    };
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
                    goto start;
                    break;
            }
            Console.WriteLine("Output: "+output);
            Console.ReadKey();
        }
    }
}
