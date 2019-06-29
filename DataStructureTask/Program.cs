using System;
using System.IO;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<IReadUserEntry>().ImplementedBy<ReadUserEntry>());
            container.Register(Component.For<IHistory>().ImplementedBy<History>());

            var history = container.Resolve<IHistory>();
            var readUser = container.Resolve<IReadUserEntry>();



            while (readUser.Quit == false)
            {
                string userInput = Console.ReadLine();
                var output = readUser.ProcessInput(userInput);
                if (!output.Equals(null))
                {
                    Console.WriteLine($"OK {output}");
                }
            }


        }
    }
}
