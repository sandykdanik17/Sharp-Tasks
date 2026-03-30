using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Оберіть номер завдання або 0 для виходу:");
                Console.WriteLine("1. Завдання 1.2 (Ієрархія класів)");
                Console.WriteLine("2. Завдання 2.2 (Конструктори та деструктори)");
                Console.WriteLine("3. Завдання 3.7 (Пошук Іграшок)");
                Console.WriteLine("4. Завдання 4 (Частковий запечатаний клас Trapeze)");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Task1.Run();
                        break;
                    case "2":
                        Lab5.Task2.Task2.Run();
                        break;
                    case "3":
                        Lab5.Task3.Task3.Run();
                        break;
                    case "4":
                        Lab5.Task4.Task4.Run();
                        break;
                    default:
                        Console.WriteLine("Помилка: такого завдання немає. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}