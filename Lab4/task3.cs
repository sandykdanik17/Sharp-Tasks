using System;

namespace Lab4
{
    public struct StudentStruct
    {
        public string FullName;
        public string Address;
        public string Group;
        public double Rating;

        public StudentStruct(string fullName, string address, string group, double rating)
        {
            FullName = fullName;
            Address = address;
            Group = group;
            Rating = rating;
        }

        public void Print()
        {
            Console.WriteLine($"[Структура] {FullName} | Група: {Group} | Рейтинг: {Rating} | Адреса: {Address}");
        }
    }

    
    public record StudentRecord(string FullName, string Address, string Group, double Rating);


    
    public class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n--- Завдання 3.7: Структури, Кортежі та Записи ---");

            double minRating = 70.0;
            Console.WriteLine($"\nКРИТЕРІЙ ВИДАЛЕННЯ: рейтинг менше {minRating}\n");

            DemoStructs(minRating);
            DemoTuples(minRating);
            DemoRecords(minRating);

            Console.WriteLine("\nНатисніть Enter для повернення в меню...");
            Console.ReadLine();
        }

     
        
        static void DemoStructs(double minRating)
        {
            Console.WriteLine("СТРУКТУРИ (STRUCT)");

            StudentStruct[] students = new StudentStruct[]
            {
                new StudentStruct("Іваненко Іван Іванович", "вул. Головна 1", "КН-21", 85.5),
                new StudentStruct("Петренко Петро Петрович", "вул. Садова 5", "КН-21", 65.0),
                new StudentStruct("Сидоренко Анна Ігорівна", "вул. Миру 10", "КН-21", 92.0)
            };

     
            students = Array.FindAll(students, s => s.Rating >= minRating);

            Array.Resize(ref students, students.Length + 1); 
            students[students.Length - 1] = new StudentStruct("Новенко Олег Петрович", "вул. Нова 3", "КН-22", 78.5);

            foreach (var s in students) s.Print();
            Console.WriteLine();
        }

     
        // ВИКОРИСТАННЯ КОРТЕЖІВ (TUPLE)
        
        static void DemoTuples(double minRating)
        {
            Console.WriteLine("=== ВАРІАНТ 2: КОРТЕЖІ (TUPLE) ===");

            (string FullName, string Address, string Group, double Rating)[] students =
            {
                ("Коваленко Марія Іванівна", "вул. Франка 2", "ІПЗ-21", 88.0),
                ("Григоренко Максим Олегович", "вул. Київська 8", "ІПЗ-21", 55.5), 
                ("Лисенко Юлія Володимирівна", "вул. Лісова 4", "ІПЗ-21", 95.0)
            };

        
            students = Array.FindAll(students, s => s.Rating >= minRating);

           
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = ("Ткаченко Ілля Сергійович", "вул. Шевченка 15", "ІПЗ-22", 81.0);

            
            foreach (var s in students)
            {
                Console.WriteLine($"[Кортеж] {s.FullName} | Група: {s.Group} | Рейтинг: {s.Rating} | Адреса: {s.Address}");
            }
            Console.WriteLine();
        }

       
        // ВИКОРИСТАННЯ ЗАПИСІВ (RECORD)
        
        static void DemoRecords(double minRating)
        {
            Console.WriteLine("=== ВАРІАНТ 3: ЗАПИСИ (RECORD) ===");

            
            StudentRecord[] students = new StudentRecord[]
            {
                new StudentRecord("Шевчук Дмитро Олексійович", "вул. Квіткова 7", "КІ-21", 72.0),
                new StudentRecord("Кравчук Олена Миколаївна", "вул. Південна 11", "КІ-21", 45.0), 
                new StudentRecord("Мельник Сергій Андрійович", "вул. Залізнична 9", "КІ-21", 90.5)
            };

            
            students = Array.FindAll(students, s => s.Rating >= minRating);

            
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = new StudentRecord("Павленко Вікторія Іванівна", "вул. Соборна 20", "КІ-22", 89.0);

            
            foreach (var s in students)
            {
                Console.WriteLine($"[Запис] {s}");
            }
            Console.WriteLine();
        }
    }
}