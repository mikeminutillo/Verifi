using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Verifi
{
    public interface IReporter : IHandle<Notice>, IHandle<Error>, IHandle<RunResults>
    {
    }
}
