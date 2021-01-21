namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {

        }

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this._items[index];
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
            EnsureHaveSpace();
            this._items[this.Count++] = item;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.EnsureHaveSpace();

            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;

            this.Count++;
        }


        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[Count - 1] = default;

            this.Count--;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureHaveSpace()
        {
            if (this.Count == this._items.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            T[] newItems = new T[this._items.Length * 2];

            for (int i = 0; i < this._items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"The given index {index} is not valid!");
            }
        }
    }
}