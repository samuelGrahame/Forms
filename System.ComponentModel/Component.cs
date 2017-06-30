using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public class Component : MarshalByRefObject, IComponent, IDisposable
    {
        private static readonly object EventDisposed;
        private EventHandlerList events;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal bool CanRaiseEventsInternal
        {
            get
            {
                return this.CanRaiseEvents;
            }
        }

        protected virtual bool CanRaiseEvents
        {
            get
            {
                return true;
            }
        }



    }
}
