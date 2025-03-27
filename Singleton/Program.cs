using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код Singleton.
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton работает, обе переменные содержат один и тот же экземпляр");
            }
            else
            {
                Console.WriteLine("Singleton не удался, переменные содержат разные экземпляры");
            }

            Console.WriteLine();
            
            // Клиентский код SingletonMTE.
            Console.WriteLine("Если вы видите то же значение, то Singleton был использован повторно\n" +
                "Если вы видите разные значения, значит, было создано 2 экземпляра\n" +
                "RESULT:"
            );
            
            Thread process1 = new Thread(() =>
            {
                TestSingletonMTE("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingletonMTE("BAR");
            });
            
            process1.Start();
            process2.Start();
            
            process1.Join();
            process2.Join();
        }
        
        public static void TestSingletonMTE(string value)
        {
            SingletonMTE singleton = SingletonMTE.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}