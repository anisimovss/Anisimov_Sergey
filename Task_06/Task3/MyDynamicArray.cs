using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class MyDynamicArray<T> : IEnumerable<T>
    {
        private T[] _data;

        private int _length;
        private int _capacity;

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                _length = value;
            }
        }
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            private set
            {
                _capacity = value;
            }
        }

        public T this[int i]
        {
            get
            {
                if ((i < _capacity) && (i >= 0)) return _data[i];
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if ((i < _capacity) && (i >= 0))
                {
                    _length++;
                    _data[i] = value;
                } 
                else throw new ArgumentOutOfRangeException();
            }
        }

        public MyDynamicArray()
        {
            _capacity = 8;
            _data = new T[_capacity];
            _length = 0;
        }

        public MyDynamicArray(int n)
        {
            _capacity = n;
            _data = new T[_capacity];
            _length = 0;
        }

        public MyDynamicArray(IEnumerable<T> collection)
        {
            _data = collection.ToArray();
            _length = _data.Length;
            _capacity = _data.Length;
        }

        public void Add(T elem)
        {
            if (_length < _capacity) _data[_length] = elem;
            else
            {
                _capacity = _capacity * 2;
                Array.Resize(ref _data, _capacity);
                _data[_length] = elem;
            }
            _length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if ((collection.Count() + _length) > _capacity)
            {
                _capacity = _length + collection.Count();
                Array.Resize(ref _data, _capacity);
            }
            foreach (T elem in collection)
            {
                _data[Length] = elem;
                Length++;
            }
        }

        public bool Remove(T element)
        {
            int i = 0;
            int index = 0;
            bool flag = false;
            if (_length > 0)
            {
                for (i = 0; i < _length; i++)
                {
                    if (((IComparable)(_data[i])).CompareTo(element) == 0) 
                    {
                        index = i;
                        flag = true;
                    }
                    if (flag)
                    {
                        if ((i + 1) == _length)
                        {
                            _data[i] = default(T);
                            _length--;
                            return true;
                        }
                        else
                        {
                            _data[i] = _data[i + 1];
                        }
                    }
                }
            }
            return false;
        }

        public bool Insert(T element, int index)
        {
            if (index < _length)
            {
                if (_length + 1 > _capacity)
                {
                    _capacity = _capacity * 2;
                    Array.Resize(ref _data, _capacity);
                }
                for (int i = _length; i > index; i--)
                {
                    _data[i] = _data[i-1];
                }
                _data[index] = element;
                _length++;
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }
    }
}
