#if USE_ARBOR
using Arbor;
using System;
using UnityEngine;
using VContainer;

namespace MornLib
{
    [Serializable]
    public class MornSaveBoolState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStoreSolver _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private bool _value;

        public override void OnStateBegin()
        {
            var userData = _save.Solve().BoolTable.GetOrCreateUserData(_saveKey);
            userData.Value = _value;
        }
    }
}
#endif