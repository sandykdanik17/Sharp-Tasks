using System;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\nЛАБОРАТОРНА РОБОТА №9 (Колекції)");
                Console.WriteLine("1. Завдання 1.7 (Stack)");
                Console.WriteLine("2. Завдання 2.7 (Queue)");
                Console.WriteLine("3. Завдання 3 (ArrayList)");
                Console.WriteLine("4. Завдання 4 (Hashtable - Каталог CD)");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть номер завдання: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1": Task1.Run(); break;
                    case "2": Task2.Run(); break;
                    case "3": Task3.Run(); break;
                    case "4": Task4.Run(); break;
                }
            }
        }
    }
}