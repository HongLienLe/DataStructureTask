using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace DataStructureTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<IReadUserEntry>().ImplementedBy<ReadUserEntry>());
            container.Register(Component.For<IHistory>().ImplementedBy<History>());

            var readUser = container.Resolve<IReadUserEntry>();
            var history = container.Resolve<IHistory>();

           


        }
    }
}
