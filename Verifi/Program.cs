using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Verifi
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly);
            var directoryCatalog = new DirectoryCatalog(".");
            var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);

            var container = new CompositionContainer(aggregateCatalog);

            Args.Add(container, args);

            RunResults results;
            using (Events.Add(new ConsoleReporter()))
                results = container.GetExportedValue<Runner>().Run();

            if (results == null)
            {
                Console.Error.WriteLine("No results were produced");
                Environment.Exit(-1);
            }

            if (results.Total <= 0)
            {
                Console.Error.WriteLine("No verifications published results");
                Environment.Exit(-2);
            }

            Environment.Exit(results.FailCount);
        }
    }
}
