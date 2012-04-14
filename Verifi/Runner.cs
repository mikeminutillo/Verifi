using System.ComponentModel.Composition;
using System;

namespace Verifi
{
    [Export]
    public class Runner
    {
        public void Run(string[] args)
        {
            Console.WriteLine("I'm in the runner! With the args!");
            foreach(var arg in args)
                Console.WriteLine(arg);
        }
    }
}
