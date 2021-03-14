using System;

namespace Aufgabe_2
{
    class Program
    {
        // Author: Dirk Mueller
        // Date: 14.03.2021
        //
        static void Main(string[] args)
        {
            Console.WriteLine("************************************************************************");
            Console.WriteLine("* This program takes numbers and calculates the sum and the mean value *");
            Console.WriteLine("************************************************************************");

            string strInput;
            double cummulativeSum = 0;
            int countAmountOfNumbersGiven = 0;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Give a number by using a comma for separating the decimals (exit with 0): ");
                strInput = Console.ReadLine();

                // The case for exit:
                if (strInput == "0")
                    break;

                // When input was not acceptable:
                if (!Input_Accepted(strInput))
                {
                    Console.WriteLine("Input not accepted. Please try again!");
                    continue;
                }

                // Calculate running sum:
                cummulativeSum += Double.Parse(strInput);

                // Increment counter representing amount of numbers given:
                countAmountOfNumbersGiven += 1;
            }

            // Calculate mean value if it at least 1 number was given:
            if (countAmountOfNumbersGiven > 0)
            {
                Console.WriteLine("Sum: {0}", cummulativeSum);
                // Calculate mean value of all numbers:
                Console.WriteLine("Mean value: {0}", cummulativeSum / countAmountOfNumbersGiven);
            }
        }

        // Return false if input cannot be processed, and true when input was correct:
        static Boolean Input_Accepted(string strInput)
        {
            double number;
            bool result = Double.TryParse(strInput, out number);
            char charPeriod = '.';

            // Catch the case where the whole number is separated from the decimals by a '.':
            if (strInput.Contains(charPeriod))
            {
                Console.WriteLine("Please do not use \".\" in the input.");
                return false;
            }

            // Catch the case where the number is beyond the range ±5.0 × 10−^324 to ±1.7 × 10^308:
            if (Double.IsPositiveInfinity(number) || Double.IsNegativeInfinity(number))
            {
                Console.WriteLine("Number is beyond the range");
                return false;
            }

            // Input from the parsing function accepted:
            if (result)
            {
                Console.WriteLine("Your input was {0}", number);
                return true;
            }

            // Return false when input contained at least one character that is not a number:
            else
            {
                return false;
            }
        }
    }
}
