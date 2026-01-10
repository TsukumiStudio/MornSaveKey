using System;
using UniRx;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataTableTrigger : MornSaveKeyUserDataTableBase<MornSaveKeyUserDataTrigger, Unit>
    {
        [SerializeField] private System.Collections.Generic.List<MornSaveKeyUserDataTrigger> _values = new();
        protected override System.Collections.Generic.List<MornSaveKeyUserDataTrigger> Values => _values;

        public override MornSaveKeyUserDataTrigger CreateInstance(string key, Unit defaultValue = default)
        {
            return new MornSaveKeyUserDataTrigger(key, defaultValue);
        }
    }
}