using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    static class Task
    {
        private static readonly Random random = new Random(); // OMG

        private static void RandArr(int[] arr, int min, int max)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] = random.Next(min, max);
        }

        private static void PrintArr(int[] arr)
        {
            Console.Write("{");
            foreach (int item in arr) Console.Write($"{item} ");
            Console.Write("}\n");
        }
        public static void N1()
        {
            int[] arr = new int[20];
            RandArr(arr, 0, 100);
            PrintArr(arr);

            int maxOdd = int.MinValue; // int.MinValue = -2147483648

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0 && arr[i] > maxOdd)
                {
                    maxOdd = arr[i];
                }
            }
            int maxIndex = Array.IndexOf(arr, maxOdd);
            int shiftSize = arr.Length - maxIndex - 1;
            int[] shiftArr = new int[shiftSize];
            Array.Copy(arr, maxIndex + 1, shiftArr, 0, arr.Length - maxIndex - 1);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < shiftArr.Length - 1; j++)
                    (shiftArr[j], shiftArr[j + 1]) = (shiftArr[j + 1], shiftArr[j]); // OMG!!! C++, извини, но я нашёл другую
            for (int i = maxIndex + 1; i < arr.Length; i++) arr[i] = shiftArr[i - maxIndex - 1];
            PrintArr(arr);
        }
        public static void N2()
        {
            int[] arr = new int[10];
            RandArr(arr, 0, 10);
            PrintArr(arr);
            int firstZeroIndex = Array.IndexOf(arr, 0);
            int secondZeroIndex = -1;
            for (int i = firstZeroIndex; i < arr.Length; i++)
                if (arr[i] == 0) secondZeroIndex = i;
            int sum = 0;
            if (firstZeroIndex != -1 || secondZeroIndex != -1)
            {
                for (int i = firstZeroIndex + 1; i < secondZeroIndex; i++)
                {
                    sum += arr[i];
                }
            }
            Console.WriteLine($"Sum between zeros: {sum}");
        }
        public static void N3()
        {
            int[] arr = new int[8];
            RandArr(arr, 0, 10);
            PrintArr(arr);
            Console.Write("Enter a number: ");
            int enteredNumber = int.Parse(Console.ReadLine());
            bool[] binary = new bool[arr.Length];
            for(int i = 0; i < Math.Pow(2, arr.Length); i++)
            {
                int sum = 0;
                int x = i;
                for (int j = 0; j < binary.Length; j++)
                {
                    binary[j] = (x % 2 == 1);
                    x /= 2;
                }
                for(int j = 0; j < arr.Length; j++)
                {
                    if (binary[j]) sum += arr[j];
                }
                if(sum == enteredNumber)
                {
                    Console.WriteLine();
                    int count = 0;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (binary[j]) count++;
                    }
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (binary[j])
                        {
                            Console.Write(arr[j]);
                            if (--count != 0) Console.Write(" + ");
                        }
                    }
                    Console.Write($" = {enteredNumber}\n");
                    return;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N1:");
            Task.N1();
            Console.WriteLine("\n\nN2:");
            Task.N2();
            Console.WriteLine("\n\nN3:");
            Task.N3();

            Console.WriteLine("\nPress eny key!!!!!!!!");
            Console.ReadKey();
        }
    }
}
