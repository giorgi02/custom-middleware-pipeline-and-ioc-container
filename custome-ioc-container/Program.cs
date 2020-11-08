using custome_ioc_container.Models.Contracts;
using custome_ioc_container.Models.Implementatioins;
using System;

namespace custome_ioc_container
{
    class Program
    {
        static void Main(string[] args)
        {
            IoCContainer.Register<IPerson, Person>();

            var personTransient1 = IoCContainer.GetTransient<IPerson>();
            var personTransient2 = IoCContainer.GetTransient<IPerson>();


            var personSingleton1 = IoCContainer.GetSingleton<IPerson>();
            var personSingleton2 = IoCContainer.GetSingleton<IPerson>();

            Console.WriteLine(personTransient1);
            Console.WriteLine(personTransient2);
            Console.WriteLine(personSingleton1);
            Console.WriteLine(personSingleton2);

            if(personTransient1 != personTransient2)
            {
                Console.WriteLine("Transient OK");
            }

            if(personSingleton1 == personSingleton2)
            {
                Console.WriteLine("Singleton OK");
            }


        }
    }
}
