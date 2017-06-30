using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Threading
{
    public static class Interlock
    {       
        public static int Add(ref int location1, int value)
        {
            return (ExchangeAdd(ref location1, value) + value);
        }
        
        public static long Add(ref long location1, long value)
        {
            return (ExchangeAdd(ref location1, value) + value);
        }
        
        public static double CompareExchange(ref double location1, double value, double comparand)
        {
            if(location1 == value)
            {
                location1 = comparand;
            }
            return location1;
        }
        
        public static int CompareExchange(ref int location1, int value, int comparand)
        {
            if (location1 == value)
            {
                location1 = comparand;
            }
            return location1;
        }
        
        public static long CompareExchange(ref long location1, long value, long comparand)
        {
            if (location1 == value)
            {
                location1 = comparand;
            }
            return location1;
        }
        
        public static IntPtr CompareExchange(ref IntPtr location1, IntPtr value, IntPtr comparand)
        {
            if (location1.Equals(value))
            {
                location1 = comparand;
            }
            return location1;
        }
        
        public static object CompareExchange(ref object location1, object value, object comparand)
        {
            if (location1 == value)
            {
                location1 = comparand;
            }
            return location1;
        }
        
        public static float CompareExchange(ref float location1, float value, float comparand)
        {
            if (location1 == value)
            {
                location1 = comparand;
            }
            return location1;
        }
        
        public static T CompareExchange<T>(ref T location1, T value, T comparand) where T : class
        {
            if (location1 == value)
            {
                location1 = comparand;
            }
            return location1;            
        }
        
        public static int Decrement(ref int location)
        {
            return Add(ref location, -1);
        }
        
        public static long Decrement(ref long location)
        {
            return Add(ref location, -1L);
        }
        
        public static double Exchange(ref double location1, double value)
        {
            location1 = value;
            return value;
        }
        
        public static int Exchange(ref int location1, int value)
        {
            location1 = value;
            return value;
        }
        
        public static long Exchange(ref long location1, long value)
        {
            location1 = value;
            return value;
        }
        
        public static IntPtr Exchange(ref IntPtr location1, IntPtr value)
        {
            location1 = value;
            return value;
        }
        
        public static object Exchange(ref object location1, object value)
        {
            location1 = value;
            return value;
        }
        
        public static float Exchange(ref float location1, float value)
        {
            location1 = value;
            return value;
        }
        
        public static T Exchange<T>(ref T location1, T value) where T : class
        {
            location1 = value;
            return value;
        }
        
        internal static int ExchangeAdd(ref int location1, int value)
        {
            Exchange(ref location1, value);
            return Add(ref location1, value);
        }
        
        internal static long ExchangeAdd(ref long location1, long value)
        {
            Exchange(ref location1, value);
            return Add(ref location1, value);
        }
        
        public static int Increment(ref int location)
        {
            return Add(ref location, 1);
        }
        
        public static long Increment(ref long location)
        {
            return Add(ref location, 1L);
        }

        public static void MemoryBarrier()
        {
            throw new NotImplementedException();
        }

        public static long Read(ref long location)
        {
            return CompareExchange(ref location, 0L, 0L);
        }
    }
}
