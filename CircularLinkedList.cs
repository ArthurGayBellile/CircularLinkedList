using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CircularLinkedList
{
    public class CircularLinkedList<T> : LinkedList<T>
    {
        public new IEnumerator GetEnumerator()
        {
            return new SingleCircularLinkedListEnumerator<T>(this);
        }
    }
}
