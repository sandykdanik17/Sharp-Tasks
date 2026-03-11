using System;

namespace Lab2
{
    class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n Завдання 3: Сума на побічній діагоналі");

            Console.Write("Введіть розмірність квадратної матриці (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Помилка: розмірність має бути цілим додатним числом.");
                return;
            }

            int[,] array = new int[n, n];

            Console.WriteLine($"\nВведіть елементи масиву ({n * n} цілих чисел): ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    Console.Write($"\nЕлемент [{i}, {j}]: ");
                    if (!int.TryParse(Console.ReadLine(),  out array[i, j]))
                    {
                        Console.WriteLine("Помилка вводу. Замінено на 0.");
                        array[i, j] = 0;
                    }    
                }
            }
            Console.WriteLine("\nВаша матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0, 5}", array[i, j]));
                }
                Console.WriteLine();
            }

            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i, n - 1 - i];
            }

            Console.WriteLine($"\nРезультат: Сума елементів на побічній діагоналі дорінює {sum}");

            Console.WriteLine("\nНатисніть Enter для повернення в меню...");
            Console.ReadLine();
        }
    }
}