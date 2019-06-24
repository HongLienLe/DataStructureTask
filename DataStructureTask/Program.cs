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
            

            string path = "/Users/hongle/Projects/DataStructureTask/DataStructureTask/TestEntry.txt";
            FileInfo file = new FileInfo(path);
            var lines = File.ReadAllLines(path).ToList();

            foreach (var query in lines)
            {
                Console.WriteLine(query);
                readUser.ProcessInput(query);
            }

           var i =  history.GetHistoryOfObservationData();







            //while (readUser.Quit == 0)
            //{
            //    string userInput = Console.ReadLine();
            //    readUser.ProcessInput(userInput);

            //}
        }
    }
}
