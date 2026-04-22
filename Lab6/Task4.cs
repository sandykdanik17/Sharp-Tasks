using System;
using System.Collections;

namespace Lab6.Task4
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public abstract void PrintInfo();
    }

    public class Book : Product
    {
        public string Author { get; set; }
        public Book(string name, double price, string author) : base(name, price) { Author = author; }
        public override void PrintInfo() => Console.WriteLine($"[Книга] {Name}, Автор: {Author}, {Price} грн");
    }

    public class Toy : Product
    {
        public Toy(string name, double price) : base(name, price) { }
        public override void PrintInfo() => Console.WriteLine($"[Іграшка] {Name}, {Price} грн");
    }


    public class ProductCatalog : IEnumerable
    {
        private Product[] _products;

        public ProductCatalog(Product[] pArray)
        {
            _products = new Product[pArray.Length];
            for (int i = 0; i < pArray.Length; i++)
            {
                _products[i] = pArray[i];
            }
        }


        public IEnumerator GetEnumerator()
        {
            return new ProductEnumerator(_products);
        }
    }


    public class ProductEnumerator : IEnumerator
    {
        public Product[] _products;

        int position = -1;

        public ProductEnumerator(Product[] list)
        {
            _products = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _products.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _products[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }



    public class Task4
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== Завдання 4: Інтерфейси IEnumerable та IEnumerator ===");

            Product[] productsArray = new Product[]
            {
                new Book("Гаррі Поттер", 450, "Роулінг"),
                new Toy("LEGO", 1500),
                new Book("C# для початківців", 900, "Троєлсен")
            };

            ProductCatalog myCatalog = new ProductCatalog(productsArray);

            Console.WriteLine("Перебір власного класу ProductCatalog через foreach:\n");

            foreach (Product p in myCatalog)
            {
                p.PrintInfo();
            }

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}