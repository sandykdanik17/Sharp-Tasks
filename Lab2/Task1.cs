using System;

namespace Lab2
{
    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\nДобуток елементів (1D та 2D масиви)");

            Console.WriteLine("\nОдновимірний масив");
            Console.Write("Введіть розмірність масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            int[] array1D = new int[n];
            long product1D = 1; 

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                array1D[i] = int.Parse(Console.ReadLine());
                product1D *= array1D[i];
            }

            Console.WriteLine($"\nДобуток елементів 1D масиву: {product1D}");
            CheckThreeDigit(product1D);


            Console.WriteLine("Двовимірний масив");
            Console.Write("Введіть кількість рядків: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість стовпців: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] array2D = new int[rows, cols];
            long product2D = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i},{j}]: ");
                    array2D[i, j] = int.Parse(Console.ReadLine());
                    product2D *= array2D[i, j];
                }
            }

            Console.WriteLine($"\nДобуток елементів 2D масиву: {product2D}");
            CheckThreeDigit(product2D);

            Console.WriteLine("\nНатисніть Enter для повернення в меню...");
            Console.ReadLine();
        }

        static void CheckThreeDigit(long product)
        {
            long absProduct = Math.Abs(product);

            if (absProduct >= 100 && absProduct <= 999)
            {
                Console.WriteLine("Результат: Так, добуток Є тризначним числом.");
            }
            else
            {
                Console.WriteLine("езультат: Ні, добуток НЕ Є тризначним числом.");
            }
        }
    }
}