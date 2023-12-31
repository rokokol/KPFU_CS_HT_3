﻿using System;
using System.Text.RegularExpressions;

namespace TasksFrom1to5
{
    class MainClass
    {
        static int number = 1;

        static void Message(string message)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number++, message);
            Console.ReadKey();
        }

        // This not only just trim the string, but also convert all space sequence to one space
        static string TrueTrim(string input)
        {
            return Regex.Replace(input.Trim(), " +", " ");
        }

        enum DaysOfTheWeek
        {
            Monday,
            Thuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static int[] ReadRow()
        {
            bool temp = true;
            int[] result = new int[10];
            while(temp)
            {
                // Here is a one-space string "" because there is no Regex.Replace(string, string, char), only 3-string one
                string[] numbers = TrueTrim(Console.ReadLine()).Split(' ');
                bool correct = numbers.Length == 10;
                if (correct)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        correct = int.TryParse(numbers[i], out result[i]);
                        if (!correct) break;
                    }
                }
                if (correct)
                {
                    temp = false;
                }
                else
                {
                    Console.WriteLine("Incorrect input: there is no 10 elements or one of them is not an integer\n" +
                        "Please, try again:");
                }
            }

            return result;
        }

        static int ReadInt()
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool biggerThanZero = result > 0;
                if (convert && biggerThanZero)
                {
                    term = false;
                }
                else if (!biggerThanZero)
                {
                    Console.WriteLine("The input must be bigger than 0. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        public static void Main(string[] args)
        {
            void FirstProblem()
            {
                Message("checks whether the row is ascending\nIf not it prints the index of element that bigger than next one");
                Console.WriteLine("Please, enter a row of 10 numbers separated by a space:");
                int[] row = ReadRow();
                bool ascending = true;
                for (int i = 0; i < 9; i++)
                {
                    if (row[i] > row[i + 1])
                    {
                        ascending = false;
                        Console.WriteLine($"The row stops ascending in element number {++i} ({row[i]})");
                        break;
                    }
                }
                if (ascending) Console.WriteLine("The row is ascending");
            }
            
            void SecondProblem()
            {
                Message("tells card-type by its number");
                string[] cards = { "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace" };

                Console.WriteLine("NOTE: jack == 11, queen == 12, king == 13, ace == 14\nPlease, enter the number of the card:");
                try
                {
                    Console.WriteLine($"This is the {cards[ReadInt() - 6]} card!");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("There is no cards with such number...");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            void ThirdProblem()
            {
                Message("gives input string and returned another one");
                Console.WriteLine("Please, enter the string:");
                switch (TrueTrim(Console.ReadLine()).ToLower())
                {
                    case "jabroni": Console.WriteLine("Patron Tequila"); break;
                    case "school counselor": Console.WriteLine("Anything with Alcohol"); break;
                    case "programmer": Console.WriteLine("Hipster Craft Beer"); break;
                    case "bike gang member": Console.WriteLine("Moonshine"); break;
                    case "politician": Console.WriteLine("Your tax dollars"); break;
                    case "rapper": Console.WriteLine("Cristal"); break;
                    default: Console.WriteLine("Beer");break;
                }
            }

            void FourthProblem()
            {
                Message("reads a number of a week and prints its name");
                Console.WriteLine("Please, enter the number of the week:");
                switch (ReadInt())
                {
                    case 1: Console.WriteLine(DayOfWeek.Monday); break;
                    case 2: Console.WriteLine(DayOfWeek.Tuesday); break;
                    case 3: Console.WriteLine(DayOfWeek.Wednesday); break;
                    case 4: Console.WriteLine(DayOfWeek.Thursday); break;
                    case 5: Console.WriteLine(DayOfWeek.Friday); break;
                    case 6: Console.WriteLine(DayOfWeek.Saturday); break;
                    case 7: Console.WriteLine(DayOfWeek.Sunday); break;
                    default: Console.WriteLine("There is no day of the week with such number"); break;
                }
            }

            void FifthProblem()
            {
                Message("count number of strings \"Hello Kitty\" and \"Barbie doll\" in the array");
                string[] array = { "Barbie doll", "Another Doll", "Doll", "Cheese",
                     "Barbie doll", "Hello Kitty", "Amogus", "Barbie doll", "Car",
                      "Hello Kitty", "Hello World", "Bye World" };
                Console.WriteLine("The array of items:");
                int count = 0;
                foreach (string s in array)
                {
                    Console.WriteLine(s);
                    if (s.Equals("Hello Kitty") || s.Equals("Barbie doll")) count++;
                }
                Console.WriteLine($"\nThe count of the dolls the the basket is: {count}");
            }

            // Here solutions run
            FirstProblem();
            SecondProblem();
            ThirdProblem();
            FourthProblem();
            FifthProblem();

            Console.WriteLine("\nThat is all!\nPlease, enter any key to continue...");
            Console.ReadKey();
        }
    }
}
