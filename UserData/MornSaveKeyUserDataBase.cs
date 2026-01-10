using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public abstract class MornSaveKeyUserDataBase<TValue>
    {
        [SerializeField] private string _key;
        [SerializeField] private TValue _value;
        internal string Key => _key;
        public virtual TValue Value
        {
            get => _value;
            set
            {
                _value = value;
                OnNext(value);
            }
        }

        protected MornSaveKeyUserDataBase(string key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public abstract void OnNext(TValue value);
        public abstract IObservable<TValue> OnValueChanged();
    }
}