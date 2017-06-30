using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public class Component : MarshalByRefObject, IComponent, IDisposable
    {
        // Fill out props #TODO

        private static readonly object EventDisposed;
        private EventHandlerList events;
        private ISite site;

        public event EventHandler Disposed;

        static Component()
        {
            EventDisposed = new object();
        }

        public void Dispose()
        {
            
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
