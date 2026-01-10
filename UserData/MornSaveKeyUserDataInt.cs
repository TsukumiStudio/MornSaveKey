using System;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataInt : MornSaveKeyUserDataBase<int>
    {
        public MornSaveKeyUserDataInt(string key, int value) : base(key, value)
        {
            OnNext(value);
        }

        public override void OnNext(int value)
        {
            MornSaveKeyCore<int>.OnNext(Key, value);
        }

        public override IObservable<int> OnValueChanged()
        {
            return MornSaveKeyCore<int>.GetObservable(Key);
        }
    }
}