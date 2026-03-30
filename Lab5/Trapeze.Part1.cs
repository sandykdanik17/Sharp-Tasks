using System;

namespace Lab5.Task4
{
    public sealed partial class Trapeze
    {
        private int a;
        private int b;
        private int h;
        private int c;

        public Trapeze(int a, int b, int h, int c)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = c;
        }

        public partial void PrintLengths();
    }
}