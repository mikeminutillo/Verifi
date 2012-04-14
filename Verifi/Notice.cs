
namespace Verifi
{
    public abstract class Notification
    {
        public Verification Source { get; set; }
        public string Description { get; set; }
        public object Context { get; set; }

        public abstract string Prefix { get; }
    }

    public class Notice : Notification
    {
        public override string Prefix
        {
            get { return "NOTE"; }
        }
    }

    public class Error : Notification
    {
        public override string Prefix
        {
            get { return "FAIL"; }
        }
    }

}
