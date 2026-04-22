using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Лабораторна робота №6");
                Console.WriteLine("Оберіть номер завдання або 0 для виходу:");
                Console.WriteLine("1. Завдання 1.2 (Інтерфейси та Type Pattern)");
                Console.WriteLine("2. Завдання 2.7 (Спадкування інтерфейсів .NET)");
                Console.WriteLine("3. Завдання 3.3 (Обробка винятків / Exceptions)");
                Console.WriteLine("4. Завдання 4 (IEnumerable та IEnumerator)");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("Вихід з програми...");
                    break;
                }

                switch (choice)
                {
                    case "1":
                        Lab6.Task1.Task1.Run();
                        break;

                    case "2":
                        Lab6.Task2.Task2.Run();
                        break;

                    case "3":
                        Lab6.Task3.Task3.Run();
                        break;

                    case "4":
                        Lab6.Task4.Task4.Run();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Помилка: такого завдання немає. Спробуйте ще раз.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}