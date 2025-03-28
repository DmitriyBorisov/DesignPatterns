﻿using System;

namespace FactoryMethod
{
    // Класс Создатель объявляет фабричный метод, который должен возвращать объект класса Продукт.
    // Подклассы Создателя обычно предоставляют реализацию этого метода.
    abstract class Creator
    {
        // Обратите внимание, что Создатель может также обеспечить реализацию фабричного метода по умолчанию.
        public abstract IProduct FactoryMethod();

        // Также заметьте, что, несмотря на название, основная обязанность Создателя не заключается в создании продуктов.
        // Обычно он содержит некоторую базовую бизнес-логику, которая основана на объектах Продуктов, возвращаемых
        // фабричным методом. Подклассы могут косвенно изменять эту бизнес-логику, переопределяя фабричный метод и
        // возвращая из него другой тип продукта.
        public string SomeOperation()
        {
            // Вызываем фабричный метод, чтобы получить объект-продукт.
            var product = FactoryMethod();
            // Далее, работаем с этим продуктом.
            var result = $"Creator: Тот же код создателя только что сработал c {product.Operation()}";
            return result;
        }
    }

    // Конкретные Создатели переопределяют фабричный метод для того, чтобы изменить тип результирующего продукта.
    class ConcreteCreator1 : Creator
    {
        // Обратите внимание, что сигнатура метода по-прежнему использует тип абстрактного продукта, хотя фактически из
        // метода возвращается конкретный продукт. Таким образом, Создатель может оставаться независимым от конкретных
        // классов продуктов.
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    // Интерфейс Продукта объявляет операции, которые должны выполнять все конкретные продукты.
    public interface IProduct
    {
        string Operation();
    }

    // Конкретные Продукты предоставляют различные реализации интерфейса Продукта.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "результатом ConcreteProduct1";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "результатом ConcreteProduct2";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Запущено с помощью ConcreteCreator1");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine();

            Console.WriteLine("App: Запущено с помощью ConcreteCreator2");
            ClientCode(new ConcreteCreator2());
        }

        // Клиентский код работает с экземпляром конкретного создателя, хотя и через его базовый интерфейс. Пока клиент
        // продолжает работать с создателем через базовый интерфейс, вы можете передать ему любой подкласс создателя.
        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: Я не знаю класс создателя, но он все еще работает");
            Console.WriteLine(creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}