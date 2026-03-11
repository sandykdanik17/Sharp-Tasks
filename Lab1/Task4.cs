using System;

namespace Lab1
{
    class Task4
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Максимальна швидкість транспортного засобу");
            Console.WriteLine("Ознаки транспорту");
            Console.WriteLine("а - автомобіль");
            Console.WriteLine("в - велосипед");
            Console.WriteLine("м - мотоцикл");
            Console.WriteLine("л - літак");
            Console.WriteLine("п - потяг");

            Console.Write("\nВведіть ознаку транспортного засобу (одну літеру): ");

            string input = Console.ReadLine()?.ToLower();

            if (!string.IsNullOrEmpty(input) && input.Length == 1)
            {
                char vehicleChar = input[0];

                switch (vehicleChar)
                {
                    case 'а':
                        Console.WriteLine("Результат: Максимальна швидкість автомобіля ~ 250 - 320 км/год");
                        break;
                    case 'в':
                        Console.WriteLine("Результат: Максимальна швидкість велосипеда ~ 50 - 80 км/год");
                        break;
                    case 'м':
                        Console.WriteLine("Результат: максимальна швидкість мотоцикла ~ 300 - 350 км/год");
                        break;
                    case 'л':
                        Console.WriteLine("Результат: максимальна швидкість пасажирського літака ~ 900 - 950 км/год");
                        break;
                    case 'п':
                        Console.WriteLine("Результат: максимальна швидкість швидкісного потяга ~ 300 - 350 км/год");
                        break;
                    default:
                        Console.WriteLine("Помилка: Транспортний засіб з такою ознакою не знайдено");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Помилка: Будь - ласка, введіть рівно одну літеру.");
            }

            Console.WriteLine("\nНатисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}