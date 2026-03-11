using System;

namespace Lab2
{
    class Task4
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n Завдання 4: Східчастий масив (кількість додатних)");

            Console.Write("Введіть кількість рядків східчастого масиву (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Помилка: кількість рядків має бути додатним цілим числом. ");
                return;
            }

            int[][] jaggedArray = new int[n][];

            for (int i =0; i < n; i++)
            {
                Console.Write($"\nВведіть кількість елементів для рядка {i}: ");
                if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
                {
                    Console.WriteLine("Помилка вводу. Рядок матиме 1 елемент за замовчуванням.");
                    m = 1;
                }

                jaggedArray[i] = new int[m];
                
                Console.WriteLine($"\nВведіть {m} цілих чисел для рядка {i}: ");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"\nЕлемент [{i}, {j}]: ");
                    if (!int.TryParse(Console.ReadLine(), out jaggedArray[i][j]))
                    {
                        Console.WriteLine("Помилка вводу. Замінено на 0.");
                        jaggedArray[i][j] = 0;
                    }
                }
            }

            int[] positiveCounts = new int[n];

            for (int i = 0; i < n; i++)
            {
                int count = 0;

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] > 0)
                    {
                        count++;
                    }
                }

                positiveCounts[i] = count;
            }

            Console.WriteLine("Ваш згенерований східчастий масив:");
            for (int i = 0; i < n; i++)
            {
                for (int j =0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(string.Format("{0, 5}", jaggedArray[i][j]));
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nНовий масив з кількостями додатних елементів: ");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"У рядку {i} додатних елементів: {positiveCounts[i]}");
            }

            Console.WriteLine("\nНатисніть Enter для повернення в меню...");
            Console.ReadLine();
        }
    }
}
