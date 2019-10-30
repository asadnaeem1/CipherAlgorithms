using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyAlphabeticCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PolyAlphabeticCipher\n1. Encrypt\n2. Decrypt");
            int choice = int.Parse(Console.ReadLine());
            string[] keys = new string[]{
                "asdfghjklpoiuytrewqzxcvbnm",
                "qazwsxedcrfvtgbyhnupjmikol",
                "zxcvbnmkioplujhytgfredswqa"
            };
            Console.Write("Input: ");
            string input = Console.ReadLine().ToLower();
            string output = "";
            int n = 0;
            switch (choice)
            {
                case 1:
                    foreach (char c in input)
                    {
                        if (Char.IsLetter(c))
                        {
                            output += keys[n][(int)c - 97];
                        }
                        else
                        {
                            output += c;
                        }
                        n++;
                        n %= 3;
                    }
                    break;
                case 2:
                    foreach (char c in input)
                    {
                        if (Char.IsLetter(c))
                        {
                            output += (char)(keys[n].IndexOf(c) + 97);
                        }
                        else
                        {
                            output += c;
                        }
                        n++;
                        n %= 3;
                    }
                    break;
            }

            Console.WriteLine("Output: " + output);
            Console.ReadKey();
        }
    }
}

