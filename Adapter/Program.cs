using System;

namespace Adapter
{
    // Целевой класс объявляет интерфейс, с которым может работать клиентский код.
    public interface ITarget
    {
        string GetRequest();
    }

    // Адаптируемый класс содержит некоторое полезное поведение, но его интерфейс несовместим с существующим клиентским
    // кодом. Адаптируемый класс нуждается в некоторой доработке, прежде чем клиентский код сможет его использовать.
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Конкретный запрос";
        }
    }

    // Адаптер делает интерфейс Адаптируемого класса совместимым с целевым интерфейсом.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"Это '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Интерфейс Adaptee несовместим с клиентом");
            Console.WriteLine("Но с помощью адаптера клиент может вызвать его метод");

            Console.WriteLine(target.GetRequest());
        }
    }
}