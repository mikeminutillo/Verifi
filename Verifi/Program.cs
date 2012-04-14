using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.ComponentModel.Composition.Primitives;

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

            var batch = new CompositionBatch();

            foreach (var arg in args)
            {
                var values = arg.Split(':');
                if (values.Length != 2)
                {
                    Console.Error.WriteLine("Args should be in the form name:value. Not sure what to do with `{0}`", arg);
                    continue;
                }

                var name = values.First();
                var value = values.Last();

                batch.AddExport(new Export("Arg:" + name, () => value));
            }

            container.Compose(batch);

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
