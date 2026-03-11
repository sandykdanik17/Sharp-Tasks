using System;
using System.Globalization;

namespace Lab2
{
    class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n Завдання 2: Елементи більші за попередні");

            Console.Write("Введіть кількість дійсних чисел (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Помилка: введіть додатне ціле число.");
                return;
            }

            double[] array = new double[n];

            Console.WriteLine("Введіть елементи масиву (можна використовувати дроби): ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"\nЕлемент [{i}]: ");
                string input = Console.ReadLine()?.Replace(',', '.');

                if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out array[i]))
                {
                    Console.WriteLine("Помилка вводу. Замінено на 0.");
                    array[i] = 0;
                }
            }

            int count = 0;

            for (int i = 1; i < n; i++)
            {
                if (array[i] > array[i - 1])
                {
                    count++;
                }
            }

            Console.WriteLine($"\nРезультат: {count} елементів є більшими за свій попередній елемент.");

            Console.WriteLine("\nНатисніть Enter для повернення в меню...");
            Console.ReadLine();
        }
    }
}
