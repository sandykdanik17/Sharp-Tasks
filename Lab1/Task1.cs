using System;

namespace Lab1
{
    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Обчислення радіуса вписаного кола");
            Console.Write("Введіть довжину сторони рівностороннього трикутника (а): ");

            string input = Console.ReadLine();

            if (input != null)
            {
                input = input.Replace('.', ',');
            }

            if (double.TryParse(input, out double a) && a > 0)
            {
                double r = (a * Math.Sqrt(3)) / 6;

                Console.WriteLine($"Радіус вписаного кола дорівнює: {r:F4}");
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректне додатне число.");
            }

            Console.WriteLine("\nНатисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}