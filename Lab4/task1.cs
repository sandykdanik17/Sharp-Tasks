using System;

namespace Lab4 
{
    public class Trapeze
    {
        private int a; // основа 1
        private int b; // основа 2
        private int h; // висота
        private int c; // колір

        public Trapeze(int a, int b, int h, int c)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = c;
        }

        
        // Дозволяє звертатися до полів об'єкта через квадратні дужки: t[0], t[1].

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return h;
                    case 3: return c;
                    default:
                        Console.WriteLine("Помилка: Неправильний індекс! Допустимі значення: 0, 1, 2, 3.");
                        return -1;
                }
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: h = value; break;
                    case 3: c = value; break;
                    default:
                        Console.WriteLine("Помилка: Неправильний індекс! Значення не змінено.");
                        break;
                }
            }
        }

        
        // Одночасно збільшує або зменшує поля 'a' та 'b' на 1
        
        public static Trapeze operator ++(Trapeze t)
        {
            t.a++;
            t.b++;
            return t;
        }

        public static Trapeze operator --(Trapeze t)
        {
            t.a--;
            t.b--;
            return t;
        }


        // Трапеція існує, якщо її довжини строго більші за нуль
        
        public static bool operator true(Trapeze t)
        {
            return t.a > 0 && t.b > 0 && t.h > 0;
        }

        public static bool operator false(Trapeze t)
        {
            return t.a <= 0 || t.b <= 0 || t.h <= 0;
        }

        
        
        // Одночасно множить поля 'a' та 'h' на передане число
       
        public static Trapeze operator *(Trapeze t, int scalar)
        {
            return new Trapeze(t.a * scalar, t.b, t.h * scalar, t.c);
        }

        // зворотний варіант, щоб можна було писати не тільки (t * 2), але й (2 * t)
        public static Trapeze operator *(int scalar, Trapeze t)
        {
            return t * scalar;
        }

        

        // Неявне (implicit) перетворення Trapeze у string

        public static implicit operator string(Trapeze t)
        {
            return $"[Trapeze: a={t.a}, b={t.b}, h={t.h}, c={t.c}]";
        }

        // Явне (explicit) перетворення string у Trapeze

        public static explicit operator Trapeze(string s)
        {
            try
            {
                string[] parts = s.Split(',');
                int newA = int.Parse(parts[0]);
                int newB = int.Parse(parts[1]);
                int newH = int.Parse(parts[2]);
                int newC = int.Parse(parts[3]);
                return new Trapeze(newA, newB, newH, newC);
            }
            catch
            {
                Console.WriteLine("Помилка конвертації рядка! Створено порожню трапецію.");
                return new Trapeze(0, 0, 0, 0);
            }
        }

        public void PrintLengths()
        {
            Console.WriteLine($"a={a}, b={b}, h={h}, c={c}");
        }
    }

    
    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n--- Завдання 1.7: Перевантаження операторів ---");

            Trapeze t = new Trapeze(5, 7, 4, 1);
            Console.Write("Початкова трапеція: ");
            t.PrintLengths();

            Console.WriteLine("\n1) Перевірка індексатора:");
            Console.WriteLine($"t[0] (поле a) = {t[0]}");
            Console.WriteLine($"t[2] (поле h) = {t[2]}");
            Console.WriteLine("Спроба звернутися до t[5]:");
            int errorTest = t[5];

            Console.WriteLine("\n2) Перевірка оператора ++:");
            t++;
            t.PrintLengths();

            Console.WriteLine("\n3) Перевірка операцій true/false:");
            if (t) Console.WriteLine("Об'єкт t існує (всі сторони > 0).");
            else Console.WriteLine("Об'єкт t НЕ існує (є нулі або від'ємні числа).");

            Console.WriteLine("\n4) Перевірка множення на скаляр (множимо a і h на 3):");
            Trapeze t2 = t * 3;
            t2.PrintLengths();

            Console.WriteLine("\n5) Перетворення Trapeze у string:");
            string strTrapeze = t;
            Console.WriteLine($"Отриманий рядок: {strTrapeze}");

            Console.WriteLine("\n6) Перетворення string у Trapeze:");
            string data = "20,30,15,2";
            Trapeze t3 = (Trapeze)data;
            Console.Write($"Трапеція, створена з рядка '{data}': ");
            t3.PrintLengths();

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}