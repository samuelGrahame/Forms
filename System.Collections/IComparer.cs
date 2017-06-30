using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    public interface IComparer
    {
        int Compare(object x, object y);
    }
}
