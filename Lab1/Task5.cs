using System;

namespace Lab1
{
    class Task5
    {
        static long GetCube(int number)
        {
            return (long)number * number * number;
        }

        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8; 

            Console.WriteLine("Піднесення цілого числа до куба");
            Console.Write("Введіть ціле число: ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int num))
            {
                long result = GetCube(num);

                Console.WriteLine($"\nРезультат: число {num} у кубі дорівнює {result}");
            }
            else
            {
                Console.WriteLine("\nПомилка: Будь - ласка, введіть коректне ціле число.");
            }

            Console.WriteLine("\nНатисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}