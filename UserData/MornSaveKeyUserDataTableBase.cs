using System;
using System.Collections.Generic;

namespace MornLib
{
    [Serializable]
    public abstract class MornSaveKeyUserDataTableBase<TData, TValue> where TData : MornSaveKeyUserDataBase<TValue>
    {
        protected abstract List<TData> Values { get; }

        public bool Contains(string key)
        {
            for (var i = 0; i < Values.Count; i++)
            {
                var matchPair = Values[i];
                if (matchPair.Key == key)
                {
                    return true;
                }
            }

            return false;
        }

        public TData GetOrNullUserData(string key)
        {
            for (var i = 0; i < Values.Count; i++)
            {
                var matchPair = Values[i];
                if (matchPair.Key == key)
                {
                    return matchPair;
                }
            }

            return null;
        }

        public TData GetOrCreateUserData(string key, TValue defaultValue = default)
        {
            for (var i = 0; i < Values.Count; i++)
            {
                var matchPair = Values[i];
                if (matchPair.Key == key)
                {
                    return matchPair;
                }
            }

            var pair = CreateInstance(key, defaultValue);
            Values.Add(pair);
            return pair;
        }

        public abstract TData CreateInstance(string key, TValue defaultValue = default);
    }
}