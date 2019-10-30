using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VigenereCipher\n1. Encrypt\n2. Decrypt");
            int choice = int.Parse(Console.ReadLine());
            Console.Write("Input Key: ");
            string key = Console.ReadLine().ToLower();
            Console.Write("Input: ");
            string input = Console.ReadLine().ToLower();
            string output = "";
            int i = 0;

            switch (choice)
            {
                case 1:
                    foreach (char c in input)
                    {
                        if (Char.IsLetter(c))
                        {
                            output += (char)(((((int)c + (int)key[i++]) - 194) % 26) + 97);
                        }
                        else
                        {
                            output += c;
                        }
                        i %= key.Length;
                    }
                    break;
                case 2:
                    foreach (char c in input)
                    {
                        if (Char.IsLetter(c))
                        {
                            int temp = ((((int)c - 97) - ((int)key[i++] - 97)));
                            if (temp < 0)
                            {
                                temp += 26;
                            }

                            output += (char)((temp % 26) + 97);
                        }
                        else
                        {
                            output += c;
                        }
                        i %= key.Length;
                    }
                    break;
            }

            Console.WriteLine("Output: " + output);
            Console.ReadKey();
        }
    }
}
