using System;

namespace Lab5.Task3
{
    abstract class Product
    {
      
        public string Name { get; set; }
        public double Price { get; set; }
        public int TargetAge { get; set; }

        public Product(string name, double price, int targetAge)
        {
            Name = name;
            Price = price;
            TargetAge = targetAge;
        }

       
        public abstract void PrintInfo();
        public abstract bool IsMatchType(string searchType);
    }

   
    class Toy : Product
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
            Console.WriteLine($"[Іграшка] Назва: {Name}, Ціна: {Price} грн, Вік: {TargetAge}+, Виробник: {Manufacturer}, Матеріал: {Material}");
        }

        public override bool IsMatchType(string searchType)
        {
            
            return searchType.ToLower() == "іграшка";
        }
    }

   
    class Book : Product
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
            Console.WriteLine($"[Книга] Назва: «{Name}», Автор: {Author}, Ціна: {Price} грн, Вік: {TargetAge}+, Видавництво: {Publisher}");
        }

        public override bool IsMatchType(string searchType)
        {
            return searchType.ToLower() == "книга";
        }
    }

   
    class SportsEquipment : Product
    {
        public string Manufacturer { get; set; }

        public SportsEquipment(string name, double price, int targetAge, string manufacturer)
            : base(name, price, targetAge)
        {
            Manufacturer = manufacturer;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"[Спорт-інвентар] Назва: {Name}, Ціна: {Price} грн, Вік: {TargetAge}+, Виробник: {Manufacturer}");
        }

        public override bool IsMatchType(string searchType)
        {
            return searchType.ToLower() == "спорт-інвентар" || searchType.ToLower() == "спорт";
        }
    }

   
    public class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nЗавдання 3.7: База товарів");

          
            Product[] database = new Product[]
            {
                new Toy("Конструктор LEGO", 1500, 6, "LEGO Group", "Пластик"),
                new Book("Гаррі Поттер і філософський камінь", 450, 10, "Дж. К. Роулінг", "А-БА-БА-ГА-ЛА-МА-ГА"),
                new SportsEquipment("Футбольний м'яч", 800, 7, "Nike"),
                new Toy("М'який Ведмідь", 600, 3, "KidsToys", "Плюш"),
                new Book("Крос-платформенне програмування на C#", 900, 16, "Троєлсен", "Вільямс")
            };

           
            Console.WriteLine("\nПовна інформація про всі товари");
            foreach (Product item in database)
            {
                item.PrintInfo(); 
            }

            
            Console.WriteLine("\nПошук товарів");
            Console.Write("Введіть тип товару для пошуку (Іграшка, Книга, Спорт-інвентар): ");
            string searchType = Console.ReadLine();

            Console.WriteLine($"\nРезультати пошуку для типу «{searchType}»:");
            bool found = false;

            foreach (Product item in database)
            {
                if (item.IsMatchType(searchType))
                {
                    item.PrintInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Товарів такого типу не знайдено.");
            }

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}