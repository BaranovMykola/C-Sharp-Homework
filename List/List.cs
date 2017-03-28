using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node()
        {
        }
        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
    class List<T> : IEnumerable<T>
    {
        Node<T> head;
        public List(Node<T> head)
        {
            this.head = head;
        }
        public List(T element)
        {
            head = new Node<T>(element);
        }
        public List(T[] array)
        {
            head = new Node<T>();
            Node<T> current = head;
            foreach (T item in array)
            {
                current.Right = new Node<T>(item);
                current = current.Right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator<T>(head);
        }

        public void PushBack(T element)
        {
            var enumerator = ((IEnumerable<T>)this).GetEnumerator();
            while (enumerator.MoveNext())
            {
            }
            ((ListEnumerator<T>)enumerator).push(element);
        }
    }

    class ListEnumerator<T> : IEnumerator<T>
    {
        Node<T> current;
        public ListEnumerator(Node<T> head)
        {
            current = head;
        }
        object IEnumerator.Current
        {
            get
            {
                return current.Data;
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return current.Data;
            }
        }

        bool IEnumerator.MoveNext()
        {
            if (current != null)
            {

                if (current.Right != null)
                {
                    current = current.Right;
                    return true;
                }
            }
            return false;
        }

        void IEnumerator.Reset()
        {
            current = null;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ListEnumerator() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        public void push(T elemnt)
        {
            Node<T> right = current.Right;
            current.Right = new Node<T>(elemnt);
            current.Right.Right = right;
        }

    }
}
