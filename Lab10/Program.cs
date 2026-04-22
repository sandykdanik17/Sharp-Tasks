using System;
using System.Threading.Tasks; 

namespace Lab10
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("1. Запустити Завдання 1 (Класичні події)");
            Console.WriteLine("2. Запустити Завдання 2 (Асинхронність, Черги, Статистика)");
            Console.Write("Вибір: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Task1.Run();
            }
            else if (choice == "2")
            {
                await Task2.RunAsync();
            }

            Console.ReadLine();
        }
    }
}