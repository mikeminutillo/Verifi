using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Verifi
{
    public class ArgAttribute : ImportAttribute
    {
        public ArgAttribute(string argName) : base("Arg:" + argName.ToLower())
        {
            AllowDefault = true;
        }
    }

    public static class Args
    {
        public static void Add(CompositionContainer container, string[] args)
        {
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

                container.ComposeExportedValue("Arg:" + name.ToLower(), value);
            }
        }
    }
}
