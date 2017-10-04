using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random Array:");
            var v = RandomArray();
            PrintMinMaxAndAverage(v);

            TossCoin();

            TossMultipleCoins(10);

            var rtn = Names();
            Console.WriteLine("Returned name array = ");
            PrintArray<string>(rtn);
        }

        static int[] RandomArray(int capacity = 10) 
        {
            var rarray = new int[capacity];
            var rand = new Random();

            for (int i = 0; i < capacity; i++)
            {
                rarray[i] = rand.Next(5, 25);
            }
            return rarray;
        }

        private static void PrintMinMaxAndAverage(int[] arr)
        {
            if (arr.Length < 1)
                throw new ApplicationException("Unable to process empty array in PrintMinMaxAndAverage.");
            var sum = 0;
            var min = arr[0];
            var max = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
			}
            var avg = (float)sum / arr.Length;
            Console.Write("For the array ");
            PrintArray(arr, false);
            Console.WriteLine($"  Min={min}  Max={max}  Avg={avg} .");
            return;
        }
        private static void PrintArray<T>(T[] arr, bool UseWriteLine = true)
		{
			Console.Write(" [ ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1)
                    Console.Write(arr[i] + ", ");
                else
                {
                    if (UseWriteLine)
                        Console.WriteLine(arr[i] + "] ");
                    else
                        Console.Write(arr[i] + "] ");
                }
			}
		}

        private static string TossCoin()
        {
            var rnd = new Random();
            var val = rnd.Next(0, 100);
            if (val < 50)
            {
                Console.WriteLine("Tossing a Coin!  Heads!");
                return "Heads";
            } else {
				Console.WriteLine("Tossing a Coin!  Tails!");
                return "Tails";
			}
        }

		private static double TossMultipleCoins(int num)
        {
            if (num < 1)
                throw new IndexOutOfRangeException("Number must be positive.");
            int heads = 0;
            int tails = 0;
            int lostCoin = 0;

            for (int i = 0; i < num; i++)
            {
                var result = TossCoin();
                if ("Heads" == result)
                    heads++;
                else if ("Tails" == result)
                    tails++;
                else
                    lostCoin++;
            }
            var percent = 100d * (double) heads / num;
            Console.WriteLine($"  Results:    Heads:{heads} Tails:{tails} LostCoins:{lostCoin} for H/T of {percent}%");
            return percent;
        }

        private static string[] Names()
        {
            Random rdn = new Random();
            var source = new string[] { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            for (int i = 0; i < 30; i++)
            {
                var indA = rdn.Next(0, source.Length);
				var indB = rdn.Next(0, source.Length);
                var temp = source[indA];
                source[indA] = source[indB];
                source[indB] = temp;
			}
            Console.Write("Reordered names array = ");
            PrintArray<string>(source);
            int numberOfLongNames = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Length > 5)
                    numberOfLongNames++;
            }
            var rtnarr = new string[numberOfLongNames];
            var rtn_ptr = 0;
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i].Length > 5)
					rtnarr[rtn_ptr++] = source[i];
			}
            return rtnarr;
        }
	} //class
}
