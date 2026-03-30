using System;

namespace Lab5.Task3
{
    abstract class Function
    {
        public abstract double Calculate(double x);
        public abstract void PrintInfo(double x);
    }

    class Line : Function
    {
        public double A { get; set; }
        public double B { get; set; }

        public Line(double a, double b)
        {
            A = a;
            B = b;
        }

        public override double Calculate(double x)
        {
            return A * x + B;
        }

        public override void PrintInfo(double x)
        {
            Console.WriteLine($"[Пряма]     y = {A}*x + {B}. \tПри x = {x}, y = {Calculate(x)}");
        }
    }

    class Quadratic : Function
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Quadratic(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double Calculate(double x)
        {
            return A * Math.Pow(x, 2) + B * x + C;
        }

        public override void PrintInfo(double x)
        {
            Console.WriteLine($"[Парабола]  y = {A}*x^2 + {B}*x + {C}. \tПри x = {x}, y = {Calculate(x)}");
        }
    }

    class Hyperbola : Function
    {
        public double K { get; set; }

        public Hyperbola(double k)
        {
            K = k;
        }

        public override double Calculate(double x)
        {
            if (x == 0) return double.NaN;
            return K / x;
        }

        public override void PrintInfo(double x)
        {
            if (x == 0)
            {
                Console.WriteLine($"[Гіпербола] y = {K}/x. \tПри x = {x}, значення не існує (ділення на нуль)!");
            }
            else
            {
                Console.WriteLine($"[Гіпербола] y = {K}/x. \tПри x = {x}, y = {Calculate(x):F2}");
            }
        }
    }

    public class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== Завдання 3: Математичні функції ===");

            double x = 2.5;

            Function[] functions = new Function[]
            {
                new Line(2, 3),
                new Quadratic(1, -2, 5),
                new Hyperbola(10),
                new Line(-1, 10),
                new Hyperbola(5)
            };

            Console.WriteLine($"Кількість функцій у масиві (n) = {functions.Length}");
            Console.WriteLine($"\n--- Обчислення значень у точці x = {x} ---");

            foreach (Function func in functions)
            {
                func.PrintInfo(x);
            }

            Console.WriteLine("\n--- Перевірка надійності (x = 0) ---");
            functions[2].PrintInfo(0);

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}