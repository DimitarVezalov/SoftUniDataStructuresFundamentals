﻿namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            ResizeIfNeeded();
            this._items[this.Count] = item; 
            this.Count++;
        }

        

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0 ; i--)
            {
                if (this._items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ResizeIfNeeded();
            this.ValidateIndex(index);
            int indexToInsert = this.Count - index;

            for (int i = this.Count; i >= indexToInsert; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[indexToInsert] = item;
            this.Count++;

        }

        public bool Remove(T item)
        {
            int indexOfItem = this.IndexOf(item);

            if (indexOfItem == -1)
            {
                return false;
            }

            this.RemoveAt(indexOfItem);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = this.Count - 1 - index; i < this.Count; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ResizeIfNeeded()
        {
            if (this.Count == this._items.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            T[] newArray = new T[this._items.Length * 2];
            Array.Copy(this._items, newArray, this._items.Length);
            this._items = newArray;
        }
    }
}