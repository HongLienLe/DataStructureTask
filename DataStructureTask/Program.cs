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
            container.Register(Component.For<IExecuteUserInput>().ImplementedBy<ExecuteUserInput>());


            var readUserEntry = container.Resolve<IReadUserEntry>();
            var history = container.Resolve<IHistory>();
            var ExecuteUserInput = container.Resolve<IExecuteUserInput>();

            int quit = 0;

            while(quit == 0)
            {
                var readInput = readUserEntry.SetProperties();

                if (!readInput.Command.Contains("QUIT"))
                {
                    ExecuteUserInput.callCommand(readInput);
                } else
                {
                    quit++;
                }
            }
        }
    }
}
