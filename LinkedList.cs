using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DaLinkedList
{
    public class LinkedObject<T>
    {
        public LinkedObject<T> pPrev = null;
        public LinkedObject<T> pNext = null;
        public T _object;

        public LinkedObject(T obj)
        {
            _object = obj;
        }

        public void Unlink()
        {
            if (pPrev != null)
                pPrev.pNext = pNext;
            if (pNext != null)
                pNext.pPrev = pPrev;

            pNext = null;
            pPrev = null;
            _object = default;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedObject<T> pFirst = null;
        private LinkedObject<T> pLast = null;
        private int objectCount = 0;

        public LinkedList()
        {

        }

        public LinkedObject<T> GetFirst()
        {
            return pFirst;
        }

        public void Add(T obj)
        {
            LinkedObject<T> lobj = new LinkedObject<T>(obj);

            if (pFirst == null)
            {
                // first time, list was empty.
                pFirst = lobj;
                pLast = lobj;
            }
            else
            {
                // add last
                pLast.pNext = lobj;
                lobj.pPrev = pLast;
                pLast = lobj;
            }

            objectCount++;
        }

        public bool Remove(T obj)
        {
            LinkedObject<T> lo = pFirst;
            while (lo != null)
            {
                if(lo._object.Equals(obj))
                {
                    if(pFirst.Equals(lo))
                    {
                        pFirst = pFirst.pNext;
                    }
                    if(pLast.Equals(lo))
                    {
                        pLast = pLast.pPrev;
                    }

                    lo.Unlink();

                    objectCount--;
                    return true;
                }

                lo = lo.pNext;
            }

            return false;
        }

        // Find and return the value if present in list, otherwise default (null) value.
        public T Find(T lookFor)
        {
            LinkedObject<T> lo = pFirst;
            while(lo != null)
            {
                if (lo._object.Equals(lookFor))
                    return lo._object;

                lo = lo.pNext;
            }

            // not in list, so return 'default'. (normally null)
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        LinkedList<T> linkedList = null;
        LinkedObject<T> linkedObject = null;

        public T Current
        {
            get
            {
                if (linkedObject == null)
                    return default;

                return linkedObject._object;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public LinkedListEnumerator(LinkedList<T> ll)
        {
            linkedList = ll;
        }

        public void Dispose()
        {
            // nada. called as soon as the foreach() ends. 
        }

        public bool MoveNext()
        {
            if (linkedObject == null)
                linkedObject = linkedList.GetFirst();
            else
                linkedObject = linkedObject.pNext;

            if (linkedObject == null)
                return false;

            return true;
        }

        public void Reset()
        {
            linkedObject = null;
        }
    }
}
