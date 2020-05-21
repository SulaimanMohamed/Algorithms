using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Loader;
using System.Text;



namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Sulai\Projects\AlgorithmTasks\AlgorithmTasks\unsorted_numbers.csv";

            List<string> Path = File.ReadLines(path).ToList();
            string[] numbers = Path.ToArray();
            int[] myInts = Array.ConvertAll(numbers, s => int.Parse(s));
            int[] unsortedNumbers = myInts.ToArray();

            int lenght = 15000; // Used for Shell Sort

            Console.WriteLine("\nUnsorted array of numbers: ");
            foreach (var number in unsortedNumbers)
            {
                Console.Write(number + ",");
            }
            Console.WriteLine();

            // Insertion Sort
            Console.WriteLine("\nSorted array of numbers/Insertion Sort: ");
            PrintIntegerArray(InsertionSort(unsortedNumbers));

            // Shell Sort
            Console.WriteLine("\nSorted array of numbers/Shell Sort; ");
            PrintIntegerArray(ShellSort(unsortedNumbers, lenght));

            // Linear Search
            Console.WriteLine("\n                                       Welcome to THEE Linear Searcher");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Enter a number.");
            while (true)
            {

                int input = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please wait....Searching");
                LinearSearch(unsortedNumbers, input);
                break;
            }

            // Binary Search
            Console.WriteLine("\n                                       Welcome to THEE Binary Searcher");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Enter a number.");
            while (true)
            {

                int x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please wait....Searching");
                BinarySearch(unsortedNumbers, x);
                break;
            }

        }

        static void PrintIntegerArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i.ToString() + "  ");
            }
        }

        static int[] InsertionSort(int[] unsortedNumbers)
        {
            for (int i = 0; i < unsortedNumbers.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (unsortedNumbers[j - 1] > unsortedNumbers[j])
                    {
                        int temp = unsortedNumbers[j - 1];
                        unsortedNumbers[j - 1] = unsortedNumbers[j];
                        unsortedNumbers[j] = temp;
                    }
                }
            }
            return unsortedNumbers;
        }
        static int[] ShellSort(int[] unsortedNumbers, int length)
        {
            int gap = length / 2;
            while (gap > 0)
            {
                int j = 0;
                for (int i = gap; i < length; i++)
                {

                    int temp = unsortedNumbers[i];

                    for (j = i; j >= gap && unsortedNumbers[j - gap] > temp; j -= gap)
                    {

                        unsortedNumbers[j] = unsortedNumbers[j - gap];

                    }

                    unsortedNumbers[j] = temp;


                }

                gap = gap / 2;
            }
            return unsortedNumbers;

        }
        public static int LinearSearch(int[] arr, int count)
        {

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < arr.Length; i++)
            {
                if (count == arr[i])
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Search successful");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Element {0} found at location {1}\n", count, i + 1);
                    sw.Stop();
                    Console.WriteLine("Time taken: {0}ms", sw.ElapsedMilliseconds);
                    return arr[i];
                }
 
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("Search unsuccessful.");
            Console.WriteLine("-----------------");
            Console.WriteLine("The number you are looking for is not in this array");
            return -1;
        }

        public static int BinarySearch(int[] arr, int count)
        {
            InsertionSort(arr);
            
            int first = 0, last = arr.Length - 1;
            try
            {
                do
                {

                    Stopwatch sw = Stopwatch.StartNew();
                    int mid = (first + last + 1) / 2;
                    if (count == arr[mid])
                    {
                        Console.WriteLine("-----------------");
                        Console.WriteLine("Search successful");
                        Console.WriteLine("-----------------");
                        Console.WriteLine("Element {0} found at location {1}\n", count, mid + 1);
                        sw.Stop();
                        Console.WriteLine("Time taken: {0}ms", sw.ElapsedMilliseconds);
                        return arr[mid];


                    }
                    else if (count > arr[mid])
                    {
                        first = mid + 1;
                    }
                    else if (count < arr[mid])
                    {
                        last = mid - 1;
                    }
                    mid = (first + last + 1) / 2;
                   
                } while (first <= last);
                Console.WriteLine("-----------------");
                Console.WriteLine("Search unsuccessful.");
                Console.WriteLine("-----------------");
                Console.WriteLine("The number you are looking for is not in this array");
                

            }
            catch (Exception)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Search unsuccessful.");
                Console.WriteLine("-----------------");
                Console.WriteLine("The number you are looking for is not in this array");

            }
           
            return -1;
        }
    }
}

