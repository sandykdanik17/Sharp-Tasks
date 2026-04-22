using System;

namespace Lab6.Task3
{
    // Помилка неправильних розмірів матриці
    public class InvalidMatrixDimensionException : Exception
    {
        public InvalidMatrixDimensionException(string message) : base(message) { }
    }

    // Помилка математичної операції
    public class MatrixOperationException : Exception
    {
        public MatrixOperationException(string message) : base(message) { }
    }

    public class FloatMatrix
    {
        private float[,] FMArray;
        public uint Rows { get; private set; }
        public uint Cols { get; private set; }

        public FloatMatrix(uint rows, uint cols)
        {
            if (rows == 0 || cols == 0)
            {
                throw new InvalidMatrixDimensionException("Помилка! Розміри матриці не можуть дорівнювати нулю.");
            }

            Rows = rows;
            Cols = cols;
            FMArray = new float[Rows, Cols];
        }

        public float this[uint i, uint j]
        {
            get
            {
                if (i >= Rows || j >= Cols)
                {
                    throw new IndexOutOfRangeException($"Помилка! Індекс [{i},{j}] виходить за межі матриці {Rows}x{Cols}!");
                }
                return FMArray[i, j];
            }
            set
            {
                if (i >= Rows || j >= Cols)
                {
                    throw new IndexOutOfRangeException($"Помилка! Індекс [{i},{j}] виходить за межі матриці {Rows}x{Cols}!");
                }
                FMArray[i, j] = value;
            }
        }

        public static FloatMatrix operator +(FloatMatrix m1, FloatMatrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new MatrixOperationException($"Неможливо додати матриці різних розмірів: {m1.Rows}x{m1.Cols} та {m2.Rows}x{m2.Cols}");
            }

            FloatMatrix res = new FloatMatrix(m1.Rows, m1.Cols);
            for (uint i = 0; i < m1.Rows; i++)
                for (uint j = 0; j < m1.Cols; j++)
                    res[i, j] = m1[i, j] + m2[i, j];
            return res;
        }
    }


    public class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== Завдання 3: Обробка виняткових ситуацій ===");

            try
            {
                Console.WriteLine("\n--- Тест 1: Створення правильної матриці ---");
                FloatMatrix m1 = new FloatMatrix(2, 2);
                m1[0, 0] = 5.5f;
                Console.WriteLine("Матриця m1 успішно створена. Елемент [0,0] = " + m1[0, 0]);



                Console.WriteLine("\n--- Тест 2: Додавання матриць різних розмірів ---");
                FloatMatrix m2 = new FloatMatrix(3, 3);


                Console.WriteLine("\n--- Тест 3: Вихід за межі масиву (Завдання 3.3) ---");
                Console.WriteLine(m1[5, 5]);

                Console.WriteLine("Цей текст не виведеться, бо програма перестрибне в блок catch");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[СТАНДАРТНИЙ ВИНИТОК ПЕРЕХОПЛЕНО]");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (InvalidMatrixDimensionException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[ВЛАСНИЙ ВИНЯТОК ПЕРЕХОПЛЕНО: Неправильний розмір]");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (MatrixOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[ВЛАСНИЙ ВИНЯТОК ПЕРЕХОПЛЕНО: Помилка операції]");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[НЕВІДОМА ПОМИЛКА]: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nБлок finally: Завершення перевірки матриць.");
            }

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}