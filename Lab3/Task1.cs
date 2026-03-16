using System;

namespace Lab3
{
    public class Trapeze
    {
        private int a;
        private int b;
        private int h;
        private int c;

        public int A
        {
            get { return a; }
            set { if (value > 0) a = value; }
        }

        public int B
        {
            get { return b; }
            set { if (value > 0) b = value; }
        }

        public int H
        {
            get { return h; }
            set { if (value > 0) h = value; }
        }

        public int C
        {
            get { return c; }
        }

        public bool IsSquareProp
        {
            get { return a == b && a == h; }
        }

        public Trapeze(int a, int b, int h, int c)
        {
            this.a = Math.Max(a, 1);
            this.b = Math.Max(b, 1);
            this.h = Math.Max(h, 1);
            this.c = c;
        }

        public void PrintLengths()
        {
            Console.WriteLine($"Основи: a={a} та b={b},Висота: h={h}, Колір: c={c}");
        }

        public double GetArea()
        {
            return (a + b) / 2.0 * h;
        }

        public double GetPerimeter()
        {
            double side = Math.Sqrt(Math.Pow(Math.Abs(a - b) / 2.0, 2) + Math.Pow(h, 2));
            return a + b + 2 * side;
        }

        public bool IsSquare()
        {
            return a == b && a == h;
        }
    }

    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Завдання 1: Масив Трапецій");

            Trapeze[] array = new Trapeze[4];

            array[0] = new Trapeze(5, 7, 4, 1);
            array[1] = new Trapeze(6, 6, 6, 2);
            array[2] = new Trapeze(10, 4, 8, 3);
            array[3] = new Trapeze(3, 3, 3, 1);

            int squareCount = 0;

            Console.WriteLine("Інформація про всі трапеції в масиві:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Трапеція Номер{i + 1}: ");

                array[i].PrintLengths();

                Console.WriteLine($"Площа: {array[i].GetArea():F2}");
                Console.WriteLine($"Периметр: {array[i].GetPerimeter():F2}");

                if (array[i].IsSquare())
                {
                    Console.WriteLine("Увага: Ця фігура є КВАДРАТОМ!");
                    squareCount++;
                }
            }

            Console.WriteLine($"Загальний результат: У масиві знайдено квадратів - {squareCount} ");

            Console.WriteLine("Натисніть Enter для повернення в меню...");
            Console.ReadLine();
        }
    }
}