using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Verifi
{
    [Export]
    class ReporterFilter
    {
        [Arg("report")]
        string Report { get; set; }

        [ImportMany]
        IEnumerable<Lazy<IReporter, IReporterMetadata>> Reporters { get; set; }

        public IDisposable AddReporters()
        {
            IEnumerable<IReporter> reporters = Enumerable.Empty<IReporter>();
            if (String.IsNullOrEmpty(Report) == false)
            {
                reporters = from r in Reporters
                            where String.Equals(r.Metadata.Name, Report, StringComparison.CurrentCultureIgnoreCase)
                            select r.Value;

            }

            reporters = reporters.Concat(
                Reporters.Where(x => String.Equals(x.Metadata.Name, "console", StringComparison.CurrentCultureIgnoreCase))
                         .Select(x => x.Value)
            );

            var reporter = reporters.FirstOrDefault();

            if (reporter == null)
                throw new Exception("No reporters were found");

            return Events.Add(reporter);
        }

    }
}
