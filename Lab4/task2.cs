using System;

namespace Lab4
{
    
    public class VectorFloat
    {
        protected float[] FArray;
        protected uint num;
        protected int codeError;
        protected static uint num_vec = 0;

        // Конструктори
        // Без параметрів
        public VectorFloat()
        {
            num = 1;
            FArray = new float[1];
            FArray[0] = 0;
            codeError = 0;
            num_vec++;
        }

        // З одним параметром
        public VectorFloat(uint size)
        {
            num = size;
            FArray = new float[size];
            for (int i = 0; i < size; i++) FArray[i] = 0;
            codeError = 0;
            num_vec++;
        }

        // З двома параметрами
        public VectorFloat(uint size, float initValue)
        {
            num = size;
            FArray = new float[size];
            for (int i = 0; i < size; i++) FArray[i] = initValue;
            codeError = 0;
            num_vec++;
        }

        // Деструктор 
        ~VectorFloat()
        {
            Console.WriteLine("Деструктор: об'єкт VectorFloat видалено з пам'яті.");
            num_vec--;
        }

        // Методи 
        public void Input()
        {
            Console.WriteLine($"Введіть {num} дійсних чисел вектора:");
            for (uint i = 0; i < num; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                if (float.TryParse(Console.ReadLine(), out float val))
                    FArray[i] = val;
                else
                {
                    Console.WriteLine("Помилка вводу. Записано 0.");
                    FArray[i] = 0;
                }
            }
        }

        public void Print()
        {
            Console.Write("[ ");
            for (uint i = 0; i < num; i++) Console.Write($"{FArray[i]} ");
            Console.WriteLine("]");
        }

        public void AssignValue(float val)
        {
            for (uint i = 0; i < num; i++) FArray[i] = val;
        }

        public static uint GetNumVec()
        {
            return num_vec;
        }

        // Властивості 
        public uint Size
        {
            get { return num; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        //  Індексатор 
        public float this[uint index]
        {
            get
            {
                if (index >= num)
                {
                    codeError = -1;
                    return 0;
                }
                return FArray[index];
            }
            set
            {
                if (index >= num)
                {
                    codeError = -1;
                }
                else
                {
                    FArray[index] = value;
                }
            }
        }

        
        public static VectorFloat operator ++(VectorFloat v)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = v[i] + 1;
            return res;
        }

        public static VectorFloat operator --(VectorFloat v)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = v[i] - 1;
            return res;
        }

        public static bool operator true(VectorFloat v)
        {
            if (v.num == 0) return false;
            foreach (var f in v.FArray) if (f != 0) return true;
            return false;
        }

        public static bool operator false(VectorFloat v)
        {
            if (v.num == 0) return true;
            bool allZero = true;
            foreach (var f in v.FArray) if (f != 0) { allZero = false; break; }
            return allZero;
        }

        public static bool operator !(VectorFloat v)
        {
            return v.num != 0;
        }

        public static VectorFloat operator ~(VectorFloat v)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = (float)(~((int)v[i]));
            return res;
        }

        
        // Допоміжний метод для визначення розмірів при бінарних операціях
        private static void GetSizes(VectorFloat v1, VectorFloat v2, out uint min, out uint max)
        {
            min = Math.Min(v1.num, v2.num);
            max = Math.Max(v1.num, v2.num);
        }

        // Додавання 
        public static VectorFloat operator +(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = v1[i] + v2[i];
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator +(VectorFloat v, float scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = v[i] + scalar;
            return res;
        }

        // Віднімання 
        public static VectorFloat operator -(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = v1[i] - v2[i];
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator -(VectorFloat v, float scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = v[i] - scalar;
            return res;
        }

        // Множення
        public static VectorFloat operator *(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = v1[i] * v2[i];
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator *(VectorFloat v, float scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = v[i] * scalar;
            return res;
        }

        // Ділення
        public static VectorFloat operator /(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = v2[i] != 0 ? v1[i] / v2[i] : 0;
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator /(VectorFloat v, float scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = scalar != 0 ? v[i] / scalar : 0;
            return res;
        }

        // Остача від ділення
        public static VectorFloat operator %(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = v2[i] != 0 ? v1[i] % v2[i] : 0;
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator %(VectorFloat v, float scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = scalar != 0 ? v[i] % scalar : 0;
            return res;
        }

        
        public static VectorFloat operator |(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = (float)((int)v1[i] | (int)v2[i]);
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator |(VectorFloat v, byte scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = (float)((int)v[i] | scalar);
            return res;
        }

        public static VectorFloat operator ^(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = (float)((int)v1[i] ^ (int)v2[i]);
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator ^(VectorFloat v, byte scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = (float)((int)v[i] ^ scalar);
            return res;
        }

        public static VectorFloat operator &(VectorFloat v1, VectorFloat v2)
        {
            GetSizes(v1, v2, out uint min, out uint max);
            VectorFloat res = new VectorFloat(max);
            for (uint i = 0; i < min; i++) res[i] = (float)((int)v1[i] & (int)v2[i]);
            for (uint i = min; i < max; i++) res[i] = v1.num > v2.num ? v1[i] : v2[i];
            return res;
        }

        public static VectorFloat operator &(VectorFloat v, byte scalar)
        {
            VectorFloat res = new VectorFloat(v.num);
            for (uint i = 0; i < v.num; i++) res[i] = (float)((int)v[i] & scalar);
            return res;
        }

        public static VectorFloat operator >>(VectorFloat v1, int shift)
        {
            VectorFloat res = new VectorFloat(v1.num);
            for (uint i = 0; i < v1.num; i++) res[i] = (float)((int)v1[i] >> shift);
            return res;
        }

        public static VectorFloat operator <<(VectorFloat v1, int shift)
        {
            VectorFloat res = new VectorFloat(v1.num);
            for (uint i = 0; i < v1.num; i++) res[i] = (float)((int)v1[i] << shift);
            return res;
        }

        
        public static bool operator ==(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++) if (v1[i] != v2[i]) return false;
            return true;
        }

        public static bool operator !=(VectorFloat v1, VectorFloat v2)
        {
            return !(v1 == v2);
        }

        public static bool operator >(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++) if (!(v1[i] > v2[i])) return false;
            return true;
        }

        public static bool operator <(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++) if (!(v1[i] < v2[i])) return false;
            return true;
        }

        public static bool operator >=(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++) if (!(v1[i] >= v2[i])) return false;
            return true;
        }

        public static bool operator <=(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++) if (!(v1[i] <= v2[i])) return false;
            return true;
        }

        // Перевизначення методів Equals і GetHashCode
        public override bool Equals(object obj)
        {
            if (obj is VectorFloat) return this == (VectorFloat)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n--- Завдання 2.7: Клас VectorFloat ---");

            // Тестування конструкторів
            VectorFloat v1 = new VectorFloat(3, 5.5f); 
            Console.Write("Вектор 1 (ініціалізований): ");
            v1.Print();

            VectorFloat v2 = new VectorFloat(4); 
            Console.WriteLine("\nВведіть дані для Вектора 2:");
            v2.Input();
            Console.Write("Вектор 2: ");
            v2.Print();

            // Тестування арифметичних операцій
            Console.WriteLine("\n--- Тест додавання (v1 + v2) ---");
            VectorFloat v3 = v1 + v2;
            Console.Write("Результат додавання векторів різних розмірів: ");
            v3.Print();

            Console.WriteLine("\n--- Тест множення на скаляр (v1 * 2) ---");
            VectorFloat v4 = v1 * 2.0f;
            v4.Print();

            // Тестування унарних операцій
            Console.WriteLine("\n--- Тест інкременту (v1++) ---");
            v1++;
            v1.Print();

            // Тестування порівняння
            Console.WriteLine("\n--- Тест порівняння ---");
            if (v1 == v2) Console.WriteLine("Вектори v1 та v2 рівні.");
            else Console.WriteLine("Вектори v1 та v2 НЕ рівні.");

            // Тестування індексатора та помилок
            Console.WriteLine("\n--- Тест індексатора ---");
            Console.WriteLine($"Отримуємо елемент v1[0]: {v1[0]}");

            Console.WriteLine("Спробуємо звернутися до неіснуючого елемента v1[10]:");
            float errorVal = v1[10];
            Console.WriteLine($"Значення: {errorVal}, Код помилки: {v1.CodeError}");

            // Кількість векторів
            Console.WriteLine($"\nЗагальна кількість створених векторів: {VectorFloat.GetNumVec()}");

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}