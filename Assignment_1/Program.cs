using System;
using System.IO;

namespace Assignment_1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Type Conversion");
                Console.WriteLine("2. String Operations");
                Console.WriteLine("3. File Handling");
                Console.WriteLine("4. Quit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        TypeConversion();
                        break;
                    case 2:
                        StringOperations();
                        break;
                    case 3:
                        FileHandling();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option.");
                        break;
                }
            }
        }

        static void TypeConversion()
        {
            Console.Write("Enter a value to typecast: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int intValue))
                Console.WriteLine($"Integer value: {intValue}");
            else if (double.TryParse(input, out double doubleValue))
                Console.WriteLine($"Double value: {doubleValue}");
            else if (decimal.TryParse(input, out decimal decimalValue))
                Console.WriteLine($"Decimal value: {decimalValue}");
            else if (bool.TryParse(input, out bool boolValue))
                Console.WriteLine($"Boolean value: {boolValue}");
            else if (DateTime.TryParse(input, out DateTime dateValue))
                Console.WriteLine($"DateTime value: {dateValue}");
            else
                Console.WriteLine("Could not determine the type of input.");
        }

        static void StringOperations()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            Console.WriteLine("Uppercase: " + input.ToUpper());
            Console.WriteLine("Lowercase: " + input.ToLower());
            Console.WriteLine("Reversed: " + ReverseString(input));

            int countL = input.Count(c => c == 'l' || c == 'L');
            string formatted = string.Join("*", input.ToCharArray());

            Console.WriteLine("Formatted Output: *" + formatted + "*");
            Console.WriteLine($"'l' appears {countL} times");
        }

        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void FileHandling()
        {
            string filePath = "sample.txt";

            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Append text to file");
            Console.WriteLine("2. Read file contents");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int fileChoice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                return;
            }

            switch (fileChoice)
            {
                case 1:
                    Console.Write("Enter text to append to the file: ");
                    string input = Console.ReadLine();
                    File.AppendAllText(filePath, input + Environment.NewLine);
                    Console.WriteLine("Text appended to file successfully.");
                    break;

                case 2:
                    if (File.Exists(filePath))
                    {
                        Console.WriteLine("\nFile Contents:");
                        Console.WriteLine(File.ReadAllText(filePath));
                    }
                    else
                    {
                        Console.WriteLine("File does not exist.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
