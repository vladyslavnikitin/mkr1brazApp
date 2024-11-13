using System;
using System.IO;

namespace Lab1
{
    public class Program
    {
        static void Main()
        {
            int n, k;

            using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\INPUT.txt")))
            {
                string[] input = reader.ReadLine().Split(' ');
                n = int.Parse(input[0]);
                k = int.Parse(input[1]);
            }

            string minNumber = FindMinNumber(n, k);
            string maxNumber = FindMaxNumber(n, k);

            using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Files\OUTPUT.txt")))
            {
                writer.Write(minNumber);
                if (minNumber != "NO SOLUTION")
                    writer.Write('\n' + maxNumber);
            }
        }

        static readonly int[] segments = { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 }; // [0..9]

    
        public static string FindMinNumber(int n, int k)
        {
            string solution = "NO SOLUTION";

            if (k < n * 2 || k > n * 7) return solution;

            solution = new string('1', n); 
            k -= n * 2; 


            int i = 0;
            while (i < n && k > 0)
            {
  
                if (k >= 4) { solution = solution.Remove(i, 1).Insert(i, "0"); k -= 4; }
                else if (k >= 6) { solution = solution.Remove(i, 1).Insert(i, "6"); k -= 6; }
                else if (k >= 5) { solution = solution.Remove(i, 1).Insert(i, "5"); k -= 5; }
                else if (k >= 3) { solution = solution.Remove(i, 1).Insert(i, "7"); k -= 3; }
                else if (k >= 8) { solution = solution.Remove(i, 1).Insert(i, "8"); k -= 7; }

                i++;
            }

            if (k != 0) solution = "NO SOLUTION";

            return solution;
        }


        public static string FindMaxNumber(int n, int k)
        {
            char[] result = new char[n];
            int totalSegments = k;

 
            for (int i = 0; i < n; i++)
            {
                for (int digit = 9; digit >= 0; digit--)
                {
                    int neededSegments = segments[digit];

 
                    if (totalSegments >= neededSegments)
                    {
                        result[i] = (char)('0' + digit);
                        totalSegments -= neededSegments;
                        break;
                    }
                }
            }

            if (totalSegments != 0) return "NO SOLUTION";

            return new string(result);
        }
    }
}
