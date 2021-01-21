namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public Stack()
        {
            this._top = null;
            this.Count = 0;
        }

        public Stack(Node<T> top)
        {
            this._top = top;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node<T> itemToInsert = new Node<T>(item);
            itemToInsert.Next = this._top;
            this._top = itemToInsert;

            this.Count++;

        }

        public T Pop()
        {
            CheckIfEmpty();
            Node<T> currentTop = this._top;
            this._top = this._top.Next;
            this.Count--; 

            return currentTop.Value; 
        }

        public T Peek()
        {
            this.CheckIfEmpty();
            return this._top.Value;
        }

        public bool Contains(T item)
        {
            Node<T> currentItem = this._top;

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
            Node<T> currentItem = this._top;

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
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}