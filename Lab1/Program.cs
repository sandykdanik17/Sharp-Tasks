using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Оберіть номер завдання (1-6) або 0 для виходу:");
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
                    case "4":
                        Task4.Run();
                        break;
                    case "5":
                        Task5.Run();
                        break;
                    case "6":
                        Task6.Run();
                        break;
                    default:
                        Console.WriteLine("Помилка: такого завдання немає.");
                        break;
                }
            }
        }
    }
}