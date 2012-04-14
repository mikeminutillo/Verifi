using System;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;

namespace Verifi
{
    [InheritedExport]
    public abstract class Verification
    {
        private bool _errrors = false;

        internal bool Run()
        {
            try
            {
                BeforeRun();
                DoRun();
            }
            catch (Exception ex)
            {
                AddError(ex.Message, context: new { Exception = ex });
            }

            return _errrors == false;
        }

        protected abstract void DoRun();

        protected virtual void BeforeRun() { }

        protected void AddError(string description, object context = null)
        {
            _errrors = true;
            Events.Publish(new Error
            {
                Source = this,
                Description = description, 
                Context = context
            });
        }

        protected void AddNotice(string description, object context = null)
        {
            Events.Publish(new Notice
            {
                Source = this,
                Description = description,
                Context = context
            });
        }

        public virtual string Name
        {
            get { return Regex.Replace(GetType().Name, @"([a-z])([A-Z])", "$1 $2"); }
        }
    }
}
