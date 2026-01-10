using System;
using System.Collections.Generic;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataTableBool : MornSaveKeyUserDataTableBase<MornSaveKeyUserDataBool, bool>
    {
        [SerializeField] private List<MornSaveKeyUserDataBool> _values = new();
        protected override List<MornSaveKeyUserDataBool> Values => _values;

        public override MornSaveKeyUserDataBool CreateInstance(string key, bool defaultValue = false)
        {
            return new MornSaveKeyUserDataBool(key, defaultValue);
        }
    }
}