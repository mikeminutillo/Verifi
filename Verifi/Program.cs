using System.ComponentModel.Composition.Hosting;

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

            container.GetExportedValue<Runner>().Run(args);
        }
    }
}
