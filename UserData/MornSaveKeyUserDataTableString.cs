using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public sealed class MornSaveKeyUserDataTableString : MornSaveKeyUserDataTableBase<MornSaveKeyUserDataString, string>
    {
        [SerializeField] private System.Collections.Generic.List<MornSaveKeyUserDataString> _values = new();
        protected override System.Collections.Generic.List<MornSaveKeyUserDataString> Values => _values;

        public override MornSaveKeyUserDataString CreateInstance(string key, string defaultValue = null)
        {
            return new MornSaveKeyUserDataString(key, defaultValue);
        }
    }
}