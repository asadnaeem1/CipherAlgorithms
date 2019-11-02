using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Playfair Cipher\n1. Encrypt\n2. Decrypt");
            int choice = int.Parse(Console.ReadLine());
            string alphabets = "abcdefghiklmnopqrstuvwxyz";
            Console.Write("Input Key: ");
            string key = Console.ReadLine().ToLower();
            Console.Write("Input: ");
            string input = new string(Console.ReadLine().ToLower().ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            string output = "";

            char [] matrix = new char[25];
            int n = 0;
            char[] temp = key.ToCharArray().Distinct().ToArray();
            foreach (char c in temp)
            {
                matrix[n] = c;
                n++;
            }
            foreach (char c in alphabets)
            {
                if (!matrix.Contains(c))
                {
                    matrix[n] = c;
                    n++;
                }
            }
            n = 0;
            switch (choice)
            {
                case 1:
                    string tempInput = "";
                    for (n = 0; n < input.Length; n+=2)
                    {
                        if (!(n + 1 >= input.Length))
                        {
                            tempInput += input[n];
                            if (input[n] == input[n + 1])
                            {
                                tempInput += 'x';
                                n--;
                            }
                            else
                            {
                                tempInput += input[n + 1];
                            }
                            
                        }
                        else if (n < input.Length)
                        {
                            tempInput += input[n];
                        }
                    }
                    if (tempInput.Length % 2 != 0)
                    {
                        tempInput += 'x';
                    }
                    input = tempInput;
                    for (n = 0; n < input.Length; n+=2)
                    {
                        char c1 = input[n];
                        char c2 = input[n + 1];
                        if (c1 == c2)
                        {
                            c2 = 'x';
                            n--;
                        }
                        int indexc1 = Array.IndexOf(matrix, c1);
                        int indexc2 = Array.IndexOf(matrix, c2);
                        //same col
                        if (indexc1 % 5 == indexc2 % 5)
                        {
                            if (indexc1 < indexc2)
                            {
                                output += matrix[(indexc1 + 5) % 25];
                                output += matrix[(indexc2 + 5) % 25];
                            }
                            else
                            {
                                output += matrix[(indexc2 + 5) % 25];
                                output += matrix[(indexc1 + 5) % 25];
                            }
                        }
                        //same row
                        else if (Math.Floor((double)indexc1 / 5) == Math.Floor((double)indexc2 / 5))
                        {
                            int x = (int)Math.Floor((double)indexc1 / 5);
                            if (indexc1 < indexc2)
                            {
                                if ((int)Math.Floor((double)((indexc1 + 1) / 5)) == x)
                                {
                                    output += matrix[indexc1 + 1];
                                }
                                else
                                {
                                    output += matrix[indexc1 - 4];
                                }
                                if ((int)Math.Floor((double)((indexc2 + 1) / 5)) == x)
                                {
                                    output += matrix[indexc2 + 1];
                                }
                                else
                                {
                                    output += matrix[indexc2 - 4];
                                }
                            }
                            else
                            {
                                if ((int)Math.Floor((double)((indexc2 + 1) / 5)) == x)
                                {
                                    output += matrix[indexc2 + 1];
                                }
                                else
                                {
                                    output += matrix[indexc2 - 4];
                                } 
                                if ((int)Math.Floor((double)((indexc1 + 1) / 5)) == x)
                                {
                                    output += matrix[indexc1 + 1];
                                }
                                else
                                {
                                    output += matrix[indexc1 - 4];
                                }
                            }
                        }
                        //diff row and col 
                        else
                        {
                            if (indexc1 % 5 > indexc2 % 5)
                            {
                                int x = indexc1%5 - indexc2%5;
                                output += matrix[indexc1 - x];
                                output += matrix[indexc2 + x];
                            }
                            else
                            {
                                int x = indexc2 % 5 - indexc1 % 5;
                                output += matrix[indexc1 + x];
                                output += matrix[indexc2 - x];
                            }
                        }
                        output += ' ';
                    }
                        break;
                case 2:
                    for (n = 0; n < input.Length; n += 2)
                    {
                        char c1 = input[n];
                        char c2 = input[n + 1];
                        int indexc1 = Array.IndexOf(matrix, c1);
                        int indexc2 = Array.IndexOf(matrix, c2);
                        //same col
                        if (indexc1 % 5 == indexc2 % 5)
                        {
                            if (indexc1 - 5 < 0)
                            {
                                output += matrix[indexc1 + 20];
                            }
                            else
                            {
                                output += matrix[indexc1 - 5];
                            }
                            if (indexc2 - 5 < 0)
                            {
                                output += matrix[indexc2 + 20];
                            }
                            else
                            {
                                output += matrix[indexc2 - 5];
                            }
                        }
                        //same row
                        else if (Math.Floor((double)indexc1 / 5) == Math.Floor((double)indexc2 / 5))
                        {
                            int x = (int)Math.Floor((double)indexc1 / 5);
                            if ((int)Math.Floor((double)((indexc1 - 1) / 5)) != x)
                            {
                                output += matrix[indexc1 + 4];
                            }
                            else
                            {
                                output += matrix[indexc1 - 1];
                            }
                            if ((int)Math.Floor((double)((indexc2 - 1) / 5)) != x)
                            {
                                output += matrix[indexc2 + 4];
                            }
                            else
                            {
                                output += matrix[indexc2 - 1];
                            }
                        }
                        //diff row and col 
                        else
                        {
                            if (indexc1 % 5 > indexc2 % 5)
                            {
                                int x = indexc1 % 5 - indexc2 % 5;
                                output += matrix[indexc1 - x];
                                output += matrix[indexc2 + x];
                            }
                            else
                            {
                                int x = indexc2 % 5 - indexc1 % 5;
                                output += matrix[indexc1 + x];
                                output += matrix[indexc2 - x];
                            }
                        }
                    }
                    for (n = 1; n+1 < output.Length; n++)
                    {
                        if (output[n] == 'x')
                        {
                            if (output[n - 1] == output[n + 1])
                            {
                                output = output.Remove(n, 1);
                            }
                        }
                    }
                    n = output.Length - 1;
                    if (output[n] == 'x')
                    {
                        output = output.Remove(n, 1);
                    }
                    break;
            }

            Console.WriteLine("Output: " + output);
            Console.ReadKey();
        }
    }
}
