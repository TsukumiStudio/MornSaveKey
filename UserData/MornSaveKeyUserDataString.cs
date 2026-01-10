using System;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataString : MornSaveKeyUserDataBase<string>
    {
        public MornSaveKeyUserDataString(string key, string value) : base(key, value)
        {
            OnNext(value);
        }

        public override void OnNext(string value)
        {
            MornSaveKeyCore<string>.OnNext(Key, value);
        }

        public override IObservable<string> OnValueChanged()
        {
            return MornSaveKeyCore<string>.GetObservable(Key);
        }
    }
}