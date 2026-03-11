using System;

namespace Lab1
{
    class Task6
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Обчислення математичного виразу");

            Console.Write("Введіть дійсне число (x): ");
            double x = ParseInput(Console.ReadLine());

            Console.Write("Введіть дійсне число (y): ");
            double y = ParseInput(Console.ReadLine());

            if (x != 0 && y != 0)
            {
                double part1 = 1.0 / (x * y);
                double part2 = 1.0 / (x * x + 1);
                double result = (part1 + part2) * (x + y);

                Console.WriteLine($"\nРезультат обчислення виразу: {result:F4}");
            }
            else
            {
                Console.WriteLine("\nПомилка: Змінні x та y не можуть дорівнювати нулю (ділення на нуль).");
            }

            Console.WriteLine("\nНатисність Enter для завершення...");
            Console.ReadLine();
        }

        static double ParseInput(string input)
        {
            if (input != null)
            {
                input = input.Replace('.', ',');
            }

            if (double.TryParse(input, out double result))
            {
                return result;
            }

            Console.WriteLine("Помилка вводу: встановлено значення за замовчуванням 0");
            return 0;
        }
    }
}
