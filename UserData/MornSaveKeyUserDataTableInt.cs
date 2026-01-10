using System;
using System.Collections.Generic;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataTableInt : MornSaveKeyUserDataTableBase<MornSaveKeyUserDataInt, int>
    {
        [SerializeField] private List<MornSaveKeyUserDataInt> _values = new();
        protected override List<MornSaveKeyUserDataInt> Values => _values;

        public override MornSaveKeyUserDataInt CreateInstance(string key, int defaultValue = 0)
        {
            return new MornSaveKeyUserDataInt(key, defaultValue);
        }
    }
}