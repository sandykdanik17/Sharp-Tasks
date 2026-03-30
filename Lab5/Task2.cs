using System;

namespace Lab5.Task2
{
   
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        
        public Person()
        {
            Name = "Невідомо";
            Age = 0;
            Console.WriteLine(" [+] Викликано конструктор Person (0 параметрів)");
        }

        
        public Person(string name)
        {
            Name = name;
            Age = 0;
            Console.WriteLine($" [+] Викликано конструктор Person (1 параметр: {name})");
        }

       
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($" [+] Викликано конструктор Person (2 параметри: {name}, {age})");
        }

        
        ~Person()
        {
            Console.WriteLine($" [-] Деструктор Person видаляє: {Name}");
        }

        public virtual void Show()
        {
            Console.WriteLine($"[Персона] Ім'я: {Name}, Вік: {Age}");
        }
    }

   
    class Employee : Person
    {
        public double Salary { get; set; }

        public Employee() : base() 
        {
            Salary = 0;
            Console.WriteLine(" [+] Викликано конструктор Employee (0 параметрів)");
        }

        public Employee(string name, int age) : base(name, age) 
        {
            Salary = 0;
            Console.WriteLine(" [+] Викликано конструктор Employee (2 параметри: ім'я, вік)");
        }

        public Employee(string name, int age, double salary) : base(name, age)
        {
            Salary = salary;
            Console.WriteLine($" [+] Викликано конструктор Employee (3 параметри, Зарплата: {salary})");
        }

        ~Employee()
        {
            Console.WriteLine($" [-] Деструктор Employee видаляє: {Name}");
        }

        public override void Show()
        {
            Console.WriteLine($"[Службовець] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн");
        }
    }

    
    class Worker : Employee
    {
        public string Specialty { get; set; }

        public Worker() : base()
        {
            Specialty = "Не вказана";
            Console.WriteLine(" [+] Викликано конструктор Worker (0 параметрів)");
        }

        public Worker(string name, int age, double salary) : base(name, age, salary)
        {
            Specialty = "Універсал";
            Console.WriteLine(" [+] Викликано конструктор Worker (3 параметри)");
        }

        public Worker(string name, int age, double salary, string specialty) : base(name, age, salary)
        {
            Specialty = specialty;
            Console.WriteLine($" [+] Викликано конструктор Worker (4 параметри, Спеціальність: {specialty})");
        }

        ~Worker()
        {
            Console.WriteLine($" [-] Деструктор Worker видаляє: {Name}");
        }

        public override void Show()
        {
            Console.WriteLine($"[Робітник] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Спеціальність: {Specialty}");
        }
    }

    
    class Engineer : Employee
    {
        public string Project { get; set; }

        public Engineer() : base()
        {
            Project = "Без проєкту";
            Console.WriteLine(" [+] Викликано конструктор Engineer (0 параметрів)");
        }

        public Engineer(string name, int age, double salary) : base(name, age, salary)
        {
            Project = "Загальний відділ";
            Console.WriteLine(" [+] Викликано конструктор Engineer (3 параметри)");
        }

        public Engineer(string name, int age, double salary, string project) : base(name, age, salary)
        {
            Project = project;
            Console.WriteLine($" [+] Викликано конструктор Engineer (4 параметри, Проєкт: {project})");
        }

        ~Engineer()
        {
            Console.WriteLine($" [-] Деструктор Engineer видаляє: {Name}");
        }

        public override void Show()
        {
            Console.WriteLine($"[Інженер] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Проєкт: {Project}");
        }
    }

    
    class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n=== СТВОРЕННЯ ОБ'ЄКТІВ (Робота конструкторів) ===");

            Console.WriteLine("\n--- 1. Створення Персон ---");
            Person p1 = new Person();
            Person p2 = new Person("Максим");
            Person p3 = new Person("Анна", 22);

            Console.WriteLine("\n--- 2. Створення Службовців ---");
            Employee e1 = new Employee();
            Employee e2 = new Employee("Олексій", 30);
            Employee e3 = new Employee("Ірина", 28, 15000);

            Console.WriteLine("\n--- 3. Створення Робітників ---");
            Worker w1 = new Worker();
            Worker w2 = new Worker("Петро", 40, 20000);
            Worker w3 = new Worker("Степан", 45, 25000, "Слюсар");

            Console.WriteLine("\n--- 4. Створення Інженерів ---");
            Engineer eng1 = new Engineer();
            Engineer eng2 = new Engineer("Ольга", 32, 40000);
            Engineer eng3 = new Engineer("Віталій", 35, 50000, "АЕС");

            Console.WriteLine("\n=== ЗНИЩЕННЯ ОБ'ЄКТІВ (Робота деструкторів) ===");
            Console.WriteLine("Викликаємо Збирача сміття (Garbage Collector)...");

           
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\nНатисніть Enter для повернення...");
            Console.ReadLine();
        }
    }
}