using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bogosort
{
    class Program
    {
        static void Main(string[] args)
        {

            /*initialze random once (not once per shuffle) to avoid risk of same seed 
             * due to rapid repeated calls to random within short time span
             * see remarks in https://docs.microsoft.com/en-us/dotnet/api/system.random.-ctor?view=netframework-4.7.2
             */
            Random rand = new Random();

            string desiredString = "Hello";

            int trials = 10;

            List<long> results = new List<long>();  //used to store the number of random shuffles needed for each trial before target word was reached

            for(int t = trials; t > 0; t--)
            {
                //order of letters to be randomized and bogosorted
                int[] letterOrder = new int[desiredString.Length];
                for (int i = 0; i < desiredString.Length; i++)
                {
                    letterOrder[i] = i;
                }

                long attempts = 0;

                while (true)
                {
                    attempts++;
                    
                    //bogosort - randomize the order of letters
                    Shuffle(ref letterOrder, rand);

                    string currentValue = StringFromOrder(desiredString, letterOrder);

                    Console.WriteLine(currentValue);

                    if (currentValue == desiredString) break;
                }

                Console.WriteLine("Completed after " + attempts.ToString() + " attempts\n");

                results.Add(attempts);
            }//trials for loop

            Console.WriteLine("There were " + results.Count().ToString() + " trials.");
            Console.WriteLine("  The minimum attempts needed to sort was " + results.Min().ToString());
            Console.WriteLine("  The maximum attempts needed to sort was " + results.Max().ToString());
            Console.WriteLine("  The average attempts needed to sort was " + results.Average().ToString());
            Console.WriteLine("Press any key to end program");
            Console.ReadKey();

        }//main

        /// <summary>
        /// Shuffle the input array
        /// </summary>
        /// <param name="input">an array of integers to shuffle</param>
        /// <remarks>Based on https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle </remarks>
        static void Shuffle(ref int[] input, Random rand)
        {
            
            int n = input.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int j = rand.Next(i, n);
                if (i != j) //don't attempt to swap elment with itself using XOR swap, (would always result in 0)
                {
                    //swap input[i] and input[j] using XOR swap
                    input[i] = input[i] ^ input[j];
                    input[j] = input[j] ^ input[i];
                    input[i] = input[i] ^ input[j];
                }
            }
        }//Shuffle

        /// <summary>
        /// Return a string given an input string and array of int where output[i] = letters[order[i]]
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        static string StringFromOrder(string letters, int[] order)
        {
            StringBuilder s = new StringBuilder(letters.Length);
            for (int i = 0; i < letters.Length; i++)
            {
                s.Append(letters[order[i]]);
            }
            return s.ToString();
        } //StringFromOrder
    
    }//Program

}//bogosort
