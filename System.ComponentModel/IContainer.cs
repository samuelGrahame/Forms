using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public interface IContainer : IDisposable
    {        
        void Add(IComponent component);
        void Add(IComponent component, string name);
        void Remove(IComponent component);
        
        ComponentCollection Components { get; }
    }
}
