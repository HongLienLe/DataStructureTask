using System;
using System.IO;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;

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

            string path = "/Users/hongle/Projects/DataStructureTask/DataStructureTask/TestEntry.txt";


            FileInfo file = new FileInfo(path);
            List<string> lines = new List<string>();
            string line;
            using (var reader = new StreamReader(file.FullName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            foreach (var query in lines)
            {
                Console.WriteLine(query);
                readUser.ProcessInput(query);
            }




            while (readUser.Quit == 0)
            {
                string userInput = Console.ReadLine();
                readUser.ProcessInput(userInput);

            }
        }
    }
}
