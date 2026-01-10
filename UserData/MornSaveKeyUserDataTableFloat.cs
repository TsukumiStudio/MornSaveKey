using System;
using System.Collections.Generic;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataTableFloat : MornSaveKeyUserDataTableBase<MornSaveKeyUserDataFloat, float>
    {
        [SerializeField] private List<MornSaveKeyUserDataFloat> _values = new();
        protected override List<MornSaveKeyUserDataFloat> Values => _values;

        public override MornSaveKeyUserDataFloat CreateInstance(string key, float defaultValue = 0)
        {
            return new MornSaveKeyUserDataFloat(key, defaultValue);
        }
    }
}