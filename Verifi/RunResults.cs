using System.Collections.Generic;
using System.Linq;

namespace Verifi
{
    public class RunResults
    {
        public RunResults(IEnumerable<Verification> passed, IEnumerable<Verification> failed)
        {
            Passed = passed;
            Failed = failed;

            PassCount = passed.Count();
            FailCount = failed.Count();
        }

        public IEnumerable<Verification> Passed { get; private set; }
        public IEnumerable<Verification> Failed { get; private set; }

        public int PassCount { get; private set; }
        public int FailCount { get; private set; }
        public int Total { get { return PassCount + FailCount; } }
        public decimal PassRate { get { return Total == 0 ? 0 : 100m * PassCount / Total; } }

    }
}
