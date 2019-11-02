using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFenceCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Playfair Cipher\n1. Encrypt\n2. Decrypt");
            int choice = int.Parse(Console.ReadLine());
            Console.Write("Depth: ");
            int depth = int.Parse(Console.ReadLine());
            Console.Write("Input: ");
            string input = new string(Console.ReadLine().ToLower().ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            string[] depthList = new string[depth];
            for (int i = 0; i < depth; i++)
            {
                depthList[i] = "";
            }
            string output = "";
            int n = 0;
            bool forward = true;
            //encryption
            foreach (char c in input)
            {
                if (forward && n == depth)
                {
                    n -= 2;
                    forward = false;
                }
                else if (n < 0)
                {
                    n += 2;
                    forward = true;
                }
                if (forward)
                {
                    depthList[n] += c;
                    n++;
                }
                else
                {
                    depthList[n] += c;
                    n--;
                }
            }
            switch (choice)
            {
                //Ecryption
                case 1:
                    foreach (string s in depthList)
                    {
                        output += s;
                    }
                    break;

                //Decryption
                case 2:
                    int temp = 0;
                    for (int i = 0; i < depth; i++)
                    {
                        string sTemp = "";
                        for (int j = 0; j < depthList[i].Length; j++)
                        {
                            sTemp += input[temp];
                            temp++;
                        }
                        depthList[i] = sTemp;
                    }

                    n = 0;
                    forward = true;
                    int[] count = new int[depth];
                    for (int i = 0; i < depth; i++)
                    {
                        count[i] = 0;
                    }
                    foreach (char c in input)
                    {
                        if (forward && n == depth)
                        {
                            n -= 2;
                            forward = false;
                        }
                        else if (n < 0)
                        {
                            n += 2;
                            forward = true;
                        }
                        output += depthList[n][count[n]];
                        count[n]++;
                        if (forward)
                        {
                            n++;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    break;
            }
            Console.WriteLine("Output: " + output);
            Console.ReadKey();
        }
    }
}