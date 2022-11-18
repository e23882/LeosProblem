using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    #region Memberfunction
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("program starting....");
            
            //Create builder instance
            var builder = new ContainerBuilder();

            //bind object to interface
            builder.RegisterType<Test>().As<ITest>();
            //builder.RegisterDecorator<LeoDecorate, ITest>();

            //Build
            var container = builder.Build();

            var testClassInstance = container.Resolve<IEnumerable<ITest>>();

            using (var scope = container.BeginLifetimeScope())
            {
                ITest instance = container.Resolve<ITest>();
                instance.Hit();
            }
            

            Console.ReadLine();
        }
    }
    #endregion

    public class LeoDecorate:ITest
    {
        public LeoDecorate() 
        {
        }

        public void Hit()
        {
            Console.WriteLine("hits decorate");
        }
    }

    public interface ITest 
    {
        void Hit();
    }

    public class Test : ITest
    {
        public void Hit()
        {
            Console.WriteLine("function got hits");
        }
    }
}
