using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Verifi.Reporters
{
    [Reporter("html")]
    public class HtmlReporter : IReporter
    {
        private readonly IList<Notification> _notifications = new List<Notification>();

        public void Handle(Notice message)
        {
            _notifications.Add(message);
        }

        public void Handle(Error message)
        {
            _notifications.Add(message);
        }

        public void Handle(RunResults message)
        {
            var template = new HtmlTemplate
            {
                Results = message,
                Notifications = _notifications.ToLookup(x => x.Source)
            };

            var html = template.TransformText();

            Console.WriteLine(html);

            // Write to a file
        }
    }
}
