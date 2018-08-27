using System;
using System.Collections.Generic;

namespace Interview.Issues
{
    // Explain issues of the code below. How it could be fixed?
    public abstract class SomethingValuable<T>
    {
        private readonly IReadOnlyDictionary<int, T> _data;

        protected void InitDefaultValue()
        {
            _data = new Dictionary<int, T>();

            var dv = new T();
            _data.Add(dv.GetHashCode(), dv);
        }

        public bool TryGetValue(int key, out T value)
        {
            value = null;

            if (_data.ContainsKey(key))
                return false;

            value = _data[key];
            return true;
        }
    }
}