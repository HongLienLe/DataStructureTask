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

            history.Create(0, 10, "10");
            history.Update(0, 15, "TestingUpdated");
            history.Update(0, 20, "Come on work");

            history.Get(0, 18);


        }
    }
}
