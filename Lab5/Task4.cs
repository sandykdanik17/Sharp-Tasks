using System;

namespace Lab5.Task4
{
    public class Task4
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nЗавдання 4: Запечатаний частковий клас");

           
            Trapeze t = new Trapeze(5, 7, 4, 1);

            Console.Write("Початкова трапеція: ");
      
            t.PrintLengths();

            Console.WriteLine("\nПеревірка індексатора:");
            Console.WriteLine($"Основа 'a' (t[0]) = {t[0]}");

            Console.WriteLine("\nПеревірка множення на скаляр (на 2):");
            Trapeze t2 = t * 2;
            t2.PrintLengths();

            

            Console.WriteLine("\nКлас успішно зшитий з двох файлів і працює!");
            Console.WriteLine("Натисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}