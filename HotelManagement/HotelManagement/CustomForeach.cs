using System;
using System.Collections;

namespace HotelManagement
{
    public partial class CustomList<Type>:IEnumerable,IEnumerator
    {
        int position;
        public IEnumerator GetEnumerator()
        {
            position=-1;
            return (IEnumerator) this;
        }
        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position=-1;
        }
        public Object Current { get{return _array[position];} }
    }
}