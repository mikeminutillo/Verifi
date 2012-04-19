using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Verifi
{
    [Export]
    public class Runner
    {
        [ImportMany]
        private IEnumerable<Verification> _verifications = null;

        [Import]
        private ReporterFilter _reporterFilter = null;

        public RunResults Run()
        {
            using (_reporterFilter.AddReporters())
            {

                var passing = new List<Verification>();
                var failing = new List<Verification>();
                foreach (var verificiation in _verifications)
                {
                    if (verificiation.Run())
                    {
                        passing.Add(verificiation);
                    }
                    else
                    {
                        failing.Add(verificiation);
                    }
                }

                var results = new RunResults(passing, failing);

                Events.Publish(results);

                return results;
            }
        }
    }
}
