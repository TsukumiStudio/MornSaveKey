using System;
using UniRx;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataTrigger : MornSaveKeyUserDataBase<Unit>
    {
        public MornSaveKeyUserDataTrigger(string key, Unit value) : base(key, value)
        {
            OnNext(value);
        }

        public override void OnNext(Unit value)
        {
            MornSaveKeyCore<Unit>.OnNext(Key, value);
        }

        public override IObservable<Unit> OnValueChanged()
        {
            return MornSaveKeyCore<Unit>.GetObservable(Key);
        }
    }
}