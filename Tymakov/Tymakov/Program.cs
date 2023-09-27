using System;
using System.Collections;

namespace Tymakov4
{
    class MainClass
    {
        static int ReadDay(bool leap)
        {
            bool term = true;
            int result = 0;
            while (term)
            {
                string input = Console.ReadLine();
                int max = leap ? 366 : 365;
                bool correctInput = int.TryParse(input, out result);
                if (correctInput && result >= 1 && result <= max)
                {
                    term = false;
                }
                else if (!correctInput)
                {
                    Console.WriteLine("The input value is not an integer. Please, try again:");
                }
                else if(!leap && result == 366)
                {
                    Console.WriteLine("This is not a leap year. Please, try again:");
                }
                else
                {
                    Console.WriteLine($"The input value is bigger than {max} or less than 1. Please, try again:");
                }
            }
            return result;
        }

        static public int ReadYear()
        {
            bool term = true;
            int result = 0;
            while (term)
            {
                string input = Console.ReadLine();
                bool correctInput = int.TryParse(input, out result);
                bool nonZero = result != 0;
                if (correctInput && nonZero)
                {
                    term = false;
                }
                else if (!nonZero)
                {
                    Console.WriteLine("There is no zero year");
                }
                else
                {
                    Console.WriteLine("The input value is not an integer. Please, try again:");
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
            Console.WriteLine("Input a year and a day " +
            "and this program will calculate which is a month and a day of the year\n" +
                "Please, input the year (a non-zero value):");

            int year = ReadYear();
            // the first leap year was at 46 BC
            bool isALeapYear = year > -46 && (year % 400 == 0 ||
             year % 100 != 0 && year % 4 == 0) || year == -46;

            Console.WriteLine($"Please, input the number of the day (a number from 1 to {(isALeapYear ? 366 : 365)}):");
            int number = ReadDay(isALeapYear);
            int[] months = new int[] {31, isALeapYear ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            Months[] names = (Months[])Enum.GetValues(typeof(Months));

            int i;
            for (i = 0; number > months[i] && i < 12; i++) number -= months[i];

            Console.WriteLine($"It is a {names[i]} {number}\nPlease, enter any key to continue...");
	        Console.ReadKey();
        }
    }
}
