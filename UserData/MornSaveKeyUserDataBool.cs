using System;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataBool : MornSaveKeyUserDataBase<bool>
    {
        public MornSaveKeyUserDataBool(string key, bool value) : base(key, value)
        {
            OnNext(value);
        }

        public override void OnNext(bool value)
        {
            MornSaveKeyCore<bool>.OnNext(Key, value);
        }

        public override IObservable<bool> OnValueChanged()
        {
            return MornSaveKeyCore<bool>.GetObservable(Key);
        }
    }
}