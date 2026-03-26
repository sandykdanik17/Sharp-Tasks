using System;

namespace Lab4
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
                Console.WriteLine("1. Завдання 1.(Перевантаження Trapeze)");
                Console.WriteLine("2. Завдання 2.(Клас VectorFloat)");
                Console.WriteLine("3. Завдання 3.(Структури, Кортежі, Записи)");
                Console.WriteLine("4. Завдання 4.(Клас FloatMatrix)");
                Console.Write("Поточний вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Task1.Run();
                        break;
                    case "2":
                        Task2.Run();
                        break;
                    case "3":
                        Task3.Run();
                        break;
                    default:
                        Console.WriteLine("Помилка: такого завдання немає. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}