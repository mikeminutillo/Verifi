using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Verifi
{
    public interface IReporterMetadata
    {
        string Name { get; }
    }

    [MetadataAttribute]
    public class ReporterAttribute : ExportAttribute, IReporterMetadata
    {
        public ReporterAttribute(string name) : base(typeof(IReporter))
        {
            Name = name.ToLower();
        }

        public string Name { get; private set; }
    }
}
