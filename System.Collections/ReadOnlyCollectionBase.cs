using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    public class ReadOnlyCollectionBase : ICollection, IEnumerable
    {
        // Fields
        private ArrayList list;

        // Methods
        protected ReadOnlyCollectionBase()
        {
        }

        public virtual IEnumerator GetEnumerator()
        {
            return this.InnerList.GetEnumerator();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            this.InnerList.CopyTo(array, index);
        }

        // Properties
        public virtual int Count
        {
            get
            {
                return this.InnerList.Count;
            }
        }

        protected ArrayList InnerList
        {
            get
            {
                if (this.list == null)
                {
                    this.list = new ArrayList();
                }
                return this.list;
            }
        }

        bool IsSynchronized
        {
            get
            {
                return this.InnerList.IsSynchronized;
            }
        }

        object SyncRoot
        {
            get
            {
                return this.InnerList.SyncRoot;
            }
        }

    }
}
