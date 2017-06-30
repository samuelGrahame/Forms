using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public interface IServiceProvider
    {
        object GetService(Type serviceType);
    }
}
