using System;

namespace Lab1
{
    class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Перевірка існування трикутника");

            Console.Write("Введіть довжину першої сторони (а): ");
            double a = ParseInput(Console.ReadLine());

            Console.Write("Введыть довжину другої сторони (b): ");
            double b = ParseInput(Console.ReadLine());

            Console.Write("Введіть довжину третьої сторони (с): ");
            double c = ParseInput(Console.ReadLine());

            if (a > 0 && b > 0 && c > 0)
            {
                if (a + b > c && a + c > b && b + c > a)
                {
                    Console.WriteLine("\nРезультат: Трикутник з такими сторонами ІСНУЄ.");
                }
                else
                {
                    Console.WriteLine("\nРезультат: Трикутник з такими сторонами НЕ ІСНУЄ.");
                }
            }
            else
            {
                Console.WriteLine("\nПомилка: Всі сторони повинні бути додатними числами.");
            }


            Console.WriteLine("\nНатисніть Enter для завершення...");
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
            return -1; 
        }
    }
}