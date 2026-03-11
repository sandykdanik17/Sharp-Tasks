using System;

namespace Lab1
{
    class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Перевірка попадання точки в область");

            Console.Write("Введіть координату Х: ");
            double x = ParseInput(Console.ReadLine());

            Console.Write("Введіть координату Y: ");
            double y = ParseInput(Console.ReadLine());

            bool isInsideWhiteSquare = (x > -15 && x < 0) && (y > -15 && y < 0);

            bool isOnBoundary = (x >= -15 && x <= 0 && (y == 0 || y == -15)) || (y >= -15 && y <= 0 && (x == 0 || x == -15));

            Console.Write("\nРезультат: ");

            if (isOnBoundary)
            {
                Console.WriteLine("На межі");
            }
            else if (isInsideWhiteSquare)
                {
                Console.WriteLine("Ні");
            }
            else
            {
                Console.WriteLine("Так");
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

            Console.WriteLine("Попередження: некоректний ввід, вставлено значення 0");
            return 0;
        }
    }
}