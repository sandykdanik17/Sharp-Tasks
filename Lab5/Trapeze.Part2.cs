using System;

namespace Lab5.Task4
{
    public sealed partial class Trapeze
    {
        public partial void PrintLengths()
        {
            Console.WriteLine($"a={a}, b={b}, h={h}, c={c}");
        }

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
                    default: return -1;
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
                }
            }
        }

        public static Trapeze operator ++(Trapeze t)
        {
            t.a++; t.b++;
            return t;
        }

        public static Trapeze operator --(Trapeze t)
        {
            t.a--; t.b--;
            return t;
        }

        public static Trapeze operator *(Trapeze t, int scalar)
        {
            return new Trapeze(t.a * scalar, t.b, t.h * scalar, t.c);
        }

        public static bool operator true(Trapeze t)
        {
            return t.a > 0 && t.b > 0 && t.h > 0;
        }

        public static bool operator false(Trapeze t)
        {
            return t.a <= 0 || t.b <= 0 || t.h <= 0;
        }

        public static implicit operator string(Trapeze t)
        {
            return $"[Trapeze: a={t.a}, b={t.b}, h={t.h}, c={t.c}]";
        }
    }
}