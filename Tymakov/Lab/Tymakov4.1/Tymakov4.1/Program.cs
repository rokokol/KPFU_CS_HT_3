using System;
using System.Collections;

namespace Tymakov4
{
    class MainClass
    {
        static int ReadInt()
        {
            bool term = true;
            int result = 0;
            while (term)
            {
                string input = Console.ReadLine();
                bool correctInput = int.TryParse(input, out result);
                if (correctInput && result >= 1 && result <= 365)
                {
                    term = false;
                }
                else if (!correctInput)
                {
                    Console.WriteLine("The input value is not an integer. Please, try again:");
                }
                else
                {
                    Console.WriteLine("The input value is bigger than 365 or less than 1. Please, try again:");
                }
            }
            return result;
        }

        enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Input number from 1 to 365 and this program" +
            "will calculate which is month and day of the year:");

            int number = ReadInt();
            int[] months = new int[] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            Months[] names = (Months[])Enum.GetValues(typeof(Months));

            int i;
            for (i = 0; number > months[i] && i < 12; i++) number -= months[i];

            Console.WriteLine($"It is a {names[i]} {number}");
	    Console.ReadKey();
        }
    }
}
