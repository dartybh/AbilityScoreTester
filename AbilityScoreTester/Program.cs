using System;
using System.Runtime.Intrinsics.Arm;

namespace AbilityScoreTester
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            char keepRunning = 'y';
            while(keepRunning != 'q' && keepRunning != 'Q')
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "DivideBy");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated Ability Score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                keepRunning = Console.ReadKey(true).KeyChar;
            }
        }

        ///
        /// <summary>
        /// Writes a prompt and reads an int value form the console
        /// </summary>
        /// <param name="lastUsedValue">The default value</param>
        /// <param name="prompt">Prompt to print to console</param>
        /// <returns>The int value read or the default value if unable to parse</returns>
        static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write(prompt + "[" + lastUsedValue + "]: ");
            string value = Console.ReadLine();

            if (int.TryParse(value, out int num))
            {
                Console.WriteLine("\tUsing value " + num);
                return num;
            }
            else
            {
                Console.WriteLine("\tUsing default value " + lastUsedValue);
                return lastUsedValue;
            }
        }

        ///
        /// <summary>
        /// Writes a prompt and reads a double value form the console
        /// </summary>
        /// <param name="lastUsedValue">The default value</param>
        /// <param name="prompt">Prompt to print to console</param>
        /// <returns>The double value read or the default value if unable to parse</returns>
        static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write(prompt + "[" + lastUsedValue + "]: ");
            string value = Console.ReadLine();

            if (double.TryParse(value, out double num))
            {
                Console.WriteLine("\tUsing value " + num);
                return num;
            }
            else
            {
                Console.WriteLine("\tUsing default value " + lastUsedValue);
                return lastUsedValue;
            }
        }




    }
}
