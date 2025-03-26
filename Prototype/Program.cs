using System;

namespace Prototype
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            // Выполнить поверхностное копирование p1 и присвоить её p2.
            Person p2 = p1.ShallowCopy();
            // Сделать глубокую копию p1 и присвоить её p3.
            Person p3 = p1.DeepCopy();

            // Вывести значения p1, p2 и p3.
            Console.WriteLine("Исходные значения p1, p2, p3:");
            Console.WriteLine("\tзначения экземпляра p1:");
            DisplayValues(p1);
            Console.WriteLine("\tзначения экземпляра p2:");
            DisplayValues(p2);
            Console.WriteLine("\tзначения экземпляра p3:");
            DisplayValues(p3);

            // Изменить значение свойств p1 и отобразить значения p1, p2 и p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nЗначения p1, p2 и p3 after changes to p1:");
            Console.WriteLine("\tзначения экземпляра p1:");
            DisplayValues(p1);
            Console.WriteLine("\tзначения экземпляра p2 (эталонные значения изменились):");
            DisplayValues(p2);
            Console.WriteLine("\tзначения экземпляра p3 (все осталось прежним):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine($"\t\tName: {p.Name}, Age: {p.Age:d}, BirthDate: {p.BirthDate:MM/dd/yy}");
            Console.WriteLine($"\t\tID#: {p.IdInfo.IdNumber:d}");
        }
    }
}