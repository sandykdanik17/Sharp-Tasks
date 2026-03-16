using System;

namespace Lab3
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void Show()
        {
            Console.WriteLine($"[Персона] Ім'я: {Name}, Вік: {Age} ");
        }

        public int CompareTo(Person other)
        {
            return this.Age.CompareTo(other.Age);
        }
    }

    class Employee : Person
    {
        public double Salary { get; set; }

        public Employee(string name, int age, double salary) : base(name, age)
        {
            Salary = salary;
        }

        public override void Show()
        {
            Console.WriteLine($"[Службовець] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн");
        }
    }

    class Worker : Employee
    {
        public string Specialty { get; set; }

        public Worker(string name, int age, double salary, string specialty) : base(name, age, salary)
        {
            Specialty = specialty;
        }

        public override void Show()
        {
            Console.WriteLine($"[Робітник] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн, Спеціальність: {Specialty}");
        }
    }

    class Engineer : Employee
    {
        public string ProjectName { get; set; }

        public Engineer(string name, int age, double salary, string projectName) : base(name, age, salary)
        {
            ProjectName = projectName;
        }

        public override void Show()
        {
            Console.WriteLine($"[Інженер] Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн,  Проєкт: {ProjectName}");
        }
    }

    class Task2
    {
        static Person[] GeneratePeopleArray()
        {
            Person[] array = new Person[5];

            array[0] = new Engineer("Олена", 28, 45000, "Розробка ШІ");
            array[1] = new Worker("Іван", 45, 20000, "Токар-фрезерувальник");
            array[2] = new Person("Студент Андрій", 19);
            array[3] = new Employee("Марія", 35, 30000);
            array[4] = new Engineer("Віктор", 50, 55000, "Будівництво мосту");

            return array;
        }

        public static void Run()
        {
            Console.WriteLine("Завдання 2: Ієрархія класів");

            Person[] people = GeneratePeopleArray();

            Console.WriteLine("Масив до сортування");
            foreach (Person p  in people)
            {
                p.Show();
            }

            Array.Sort(people);

            Console.WriteLine("Масив ПІСЛЯ сортування за віком");
            foreach (Person p in people)
            {
                p.Show();
            }

            Console.WriteLine("Натисність Enter для повернення в меню...");
            Console.ReadLine();
        }
    }
}