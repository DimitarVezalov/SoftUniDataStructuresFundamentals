namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }

        public Queue(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node<T> currentItem = this._head;
            Node<T> itemToInsert = new Node<T>(item);

            if (this.Count == 0)
            {
                this._head = itemToInsert;
            }
            else
            {
                while (currentItem.Next != null)
                {
                    currentItem = currentItem.Next;
                }

                currentItem.Next = itemToInsert;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.CheckIfEmpty();

            Node<T> currentItem = this._head;
            this._head = this._head.Next;
            this.Count--;

            return currentItem.Value;
        }

        public T Peek()
        {
            this.CheckIfEmpty();

            return this._head.Value;
        }

        public bool Contains(T item)
        {
            Node<T> currentItem = this._head;

            while (currentItem != null)
            {
                if (currentItem.Value.Equals(item))
                {
                    return true;
                }

                currentItem = currentItem.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentItem = this._head;

            while (currentItem != null)
            {
                yield return currentItem.Value;
                currentItem = currentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}