using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml;

namespace CircularLinkedList
{
    public class SingleCircularLinkedListEnumerator<T> : IEnumerator<T>
    {

        private LinkedListNode<T> _current;
        public T Current => _current.Value;
        object IEnumerator.Current => Current;

        public SingleCircularLinkedListEnumerator(LinkedList<T> list)
        {
            _current = list.First;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                return false;
            }

            _current = _current.Next ?? _current.List.First;
            return true;
        }

        public void Reset()
        {
            _current = _current.List.First;
        }

        public void Dispose()
        {
        }
    }
}
