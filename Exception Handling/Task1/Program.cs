using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                PrintFirstCharacter();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void PrintFirstCharacter()
        {
            Console.Write("Input: ");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null or white space.");
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            Console.WriteLine($"First character of the input: {input[0]}");
            Console.ReadLine();
        }
    }
}