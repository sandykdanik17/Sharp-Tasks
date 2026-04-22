using System;

namespace Lab6.Task2 
{
    public interface IProduct : IComparable<IProduct>
    {
        string Name { get; set; }
        double Price { get; set; }
        int TargetAge { get; set; }

        void PrintInfo();
        bool IsMatchType(string searchType);
    }

    public abstract class BaseProduct : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int TargetAge { get; set; }

        public BaseProduct(string name, double price, int targetAge)
        {
            Name = name;
            Price = price;
            TargetAge = targetAge;
        }

        public abstract void PrintInfo();
        public abstract bool IsMatchType(string searchType);

        public int CompareTo(IProduct other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
    }

   
    public class Toy : BaseProduct
    {
        public string Manufacturer { get; set; }
        public string Material { get; set; }

        public Toy(string name, double price, int targetAge, string manufacturer, string material)
            : base(name, price, targetAge)
        {
            Manufacturer = manufacturer;
            Material = material;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"[Іграшка] {Name} | Ціна: {Price} грн | Вік: {TargetAge}+ | Виробник: {Manufacturer} | Матеріал: {Material}");
        }

        public override bool IsMatchType(string searchType)
        {
            return searchType.ToLower() == "іграшка";
        }
    }

    public class Book : BaseProduct
    {
        public string Author { get; set; }
        public string Publisher { get; set; }

        public Book(string name, double price, int targetAge, string author, string publisher)
            : base(name, price, targetAge)
        {
            Author = author;
            Publisher = publisher;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"[Книга] «{Name}» | Автор: {Author} | Ціна: {Price} грн | Вік: {TargetAge}+ | Видавництво: {Publisher}");
        }

        public override bool IsMatchType(string searchType)
        {
            return searchType.ToLower() == "книга";
        }
    }

    public class SportsEquipment : BaseProduct
    {
        public string Manufacturer { get; set; }

        public SportsEquipment(string name, double price, int targetAge, string manufacturer)
            : base(name, price, targetAge)
        {
            Manufacturer = manufacturer;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"[Спорт-інвентар] {Name} | Ціна: {Price} грн | Вік: {TargetAge}+ | Виробник: {Manufacturer}");
        }

        public override bool IsMatchType(string searchType)
        {
            return searchType.ToLower() == "спорт-інвентар" || searchType.ToLower() == "спорт";
        }
    }

 
    public class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== Завдання 2: Інтерфейси товарів ===");

            IProduct[] database = new IProduct[]
            {
                new Toy("Конструктор LEGO", 1500, 6, "LEGO Group", "Пластик"),
                new Book("Гаррі Поттер", 450, 10, "Дж. К. Роулінг", "А-БА-БА-ГА-ЛА-МА-ГА"),
                new SportsEquipment("Велосипед", 8500, 12, "Kellys"),
                new Toy("М'який Ведмідь", 600, 3, "KidsToys", "Плюш"),
                new Book("C# 10 і .NET 6", 1200, 16, "Троєлсен", "Вільямс")
            };

            // Демонстрація роботи інтерфейсу .NET (IComparable)
            Console.WriteLine("\n1. Повна база товарів (Відсортована за ЗРОСТАННЯМ ЦІНИ)");
            Array.Sort(database);

            foreach (IProduct item in database)
            {
                item.PrintInfo();
            }

            Console.WriteLine("\n2. Пошук товарів");
            Console.Write("Введіть тип товару для пошуку (Іграшка, Книга, Спорт): ");
            string searchType = Console.ReadLine();

            Console.WriteLine($"\nРезультати пошуку для «{searchType}»:");
            bool found = false;

            foreach (IProduct item in database)
            {
                if (item.IsMatchType(searchType))
                {
                    item.PrintInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Товарів такого типу не знайдено у базі.");
            }

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}