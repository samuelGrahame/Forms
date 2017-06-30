using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public interface ISite : IServiceProvider
    {
        IComponent Component { get; }
        IContainer Container { get; }
        bool DesignMode { get; }
        string Name { get; set; }
    }
}
