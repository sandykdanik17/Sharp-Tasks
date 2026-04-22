using System;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("               Лабораторна робота №8");
                Console.WriteLine("Оберіть номер завдання або 0 для виходу:");
                Console.WriteLine("1. Завдання 1.2 (Пошук та заміна IP-адрес через Regex)");
                Console.WriteLine("2. Завдання 2.2 (Фільтрація слів за довжиною)");
                Console.WriteLine("3. Завдання 3.17 (Вилучення слів непарної довжини)");
                Console.WriteLine("4. Завдання 4.17 (Робота з двійковими файлами)");
                Console.WriteLine("5. Завдання 5 (Робота з папками та файловою системою)");
                Console.WriteLine("0. Вихід з програми");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("\nЗавершення роботи програми...");
                    break;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        IPProcessor.Run();
                        break;

                    case "2":
                        WordLengthFilter.Run();
                        break;

                    case "3":
                        OddWordRemover.Run();
                        break;

                    case "4":
                        BinaryWordFilter.Run();
                        break;

                    case "5":
                        Lab8.Task5.FileSystemManager.Run();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Помилка: такого пункту меню не існує. Спробуйте ще раз.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до меню...");
                Console.ReadKey();
                Console.Clear(); 
            }
        }
    }
}