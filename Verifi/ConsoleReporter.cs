using System;
using System.Linq;
using Newtonsoft.Json;

namespace Verifi
{
    class ConsoleReporter : IHandle<Notice>, IHandle<Error>, IHandle<RunResults>
    {
        public void Handle(Notice message)
        {
            ReportNoticiation(message, ConsoleColor.Cyan);

        }

        public void Handle(Error message)
        {
            ReportNoticiation(message, ConsoleColor.Red);
        }

        private static void ReportNoticiation(Notification notification, ConsoleColor color)
        {
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine("{2} - {0}: {1}", notification.Source.Name, notification.Description,
                                  notification.Prefix);
                if (notification.Context == null)
                    return;
                var serializer = JsonSerializer.Create(new JsonSerializerSettings());

                var writer = new JsonTextWriter(Console.Out);
                writer.Formatting = Formatting.Indented;

                serializer.Serialize(writer, notification.Context);
                Console.WriteLine();
                Console.WriteLine();
            }
            finally
            {
                Console.ResetColor();
            }
        }


        public void Handle(RunResults message)
        {
            var results = message;

            if (results == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No results were produced.");
                Console.ResetColor();
                return;
            }

            if (results.Total <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No verifications found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("** Results **");

            if (results.PassCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Passed: {0}", results.PassCount);
                Console.ResetColor();
                Console.WriteLine(String.Join(Environment.NewLine, results.Passed.Select(y => y.Name)));
                Console.WriteLine();
            }

            if (results.FailCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed: {0}", results.FailCount);
                Console.ResetColor();
                Console.WriteLine(String.Join(Environment.NewLine, results.Failed.Select(y => y.Name)));
                Console.WriteLine();
            }

            Console.ForegroundColor = results.FailCount > 0 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine("Pass rate: {0} out of {1} which is {2:#0.#}%", results.PassCount, results.Total, results.PassRate);
            Console.ResetColor();

        }
    }
}
