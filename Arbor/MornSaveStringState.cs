#if USE_ARBOR
using Arbor;
using System;
using UnityEngine;
using VContainer;

namespace MornLib
{
    [Serializable]
    public class MornSaveStringState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStoreSolver _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private string _value;

        public override void OnStateBegin()
        {
            var userData = _save.Solve().StringTable.GetOrCreateUserData(_saveKey);
            userData.Value = _value;
        }
    }
}
#endif