using System;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataFloat : MornSaveKeyUserDataBase<float>
    {
        public MornSaveKeyUserDataFloat(string key, float value) : base(key, value)
        {
            OnNext(value);
        }

        public override void OnNext(float value)
        {
            MornSaveKeyCore<float>.OnNext(Key, value);
        }

        public override IObservable<float> OnValueChanged()
        {
            return MornSaveKeyCore<float>.GetObservable(Key);
        }
    }
}