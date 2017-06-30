using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class EmptyArray<T>
    {
        // Fields
        public static readonly T[] Value;

        // Methods
        static EmptyArray()
        {
            Value = new T[0];
        }
    }   
}
