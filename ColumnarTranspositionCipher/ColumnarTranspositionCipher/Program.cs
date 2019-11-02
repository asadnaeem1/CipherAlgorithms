using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnarTranspositionCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Columnar Transposition Cipher\n1. Encrypt\n2. Decrypt");
            int choice = int.Parse(Console.ReadLine());
            Console.Write("Key: ");
            string key = Console.ReadLine();
            Console.Write("Input: ");
            int keyLength = key.Length;
            string input = new string(Console.ReadLine().ToLower().ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            List<char> keyCharList = new List<char>();
            keyCharList.AddRange(key.ToCharArray());
            keyCharList.Sort();
            List<int> doneIndex = new List<int>();
            string output = "";
            string[] matrix = new string[keyLength];
            for (int i = 0; i < keyLength; i++)
            {
                matrix[i] = "";
            }
            switch (choice)
            {
                //Ecryption
                case 1:
                    for (int i = 0; i < input.Length; i++)
                    {
                        matrix[i % keyLength] += input[i];
                    }
                    int maxColLength = matrix[0].Length;
                    for (int i = 1; i < keyLength; i++)
                    {
                        if (matrix[i].Length < maxColLength)
                        {
                            matrix[i] += 'x';
                        }
                    }
                    for (int i = 0; i < keyLength; i++)
                    {
                        char lowestCurrentChar = keyCharList[i];
                        for (int j = 0; j < keyLength; j++)
                        {
                            if (key[j] == lowestCurrentChar && !doneIndex.Contains(j))
                            {
                                output += ' ' + matrix[j];
                                doneIndex.Add(j);
                                break;
                            }
                        }
                    }
                    break;

                //Decryption
                case 2:
                    int count = 0;
                    for (int i = 0; i < keyLength; i++)
                    {
                        for (int j = 0; j < input.Length/keyLength; j++)
                        {
                            matrix[i] += input[count];
                            count++;
                        }
                    }
                    int[] trueOrder = new int[keyLength];
                    count = 0;
                    foreach (char c in keyCharList)
                    {
                        for (int i = 0; i < keyLength; i++)
                        {
                            if (key[i] == c && !doneIndex.Contains(i))
                            {
                                trueOrder[count] = i;
                                doneIndex.Add(i);
                                count++;
                                break;
                            }
                        }
                    }
                    string[] matrixTemp = new string[keyLength];
                    count = 0;
                    foreach (int i in trueOrder)
                    {
                        matrixTemp[i] = matrix[count++];
                    }
                    for (int i = 0; i < matrixTemp[0].Length; i++)
                    {
                        for (int j = 0; j < keyLength; j++)
                        {
                            output += matrixTemp[j][i];
                        }
                        
                    }
                        break;
            }
            Console.WriteLine("Output: " + output);
            Console.ReadKey();
        }
    }
}