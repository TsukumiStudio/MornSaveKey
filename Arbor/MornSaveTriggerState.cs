#if USE_ARBOR
using Arbor;
using System;
using UnityEngine;
using VContainer;

namespace MornLib
{
    [Serializable]
    public class MornSaveTriggerState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStoreSolver _save;
        [SerializeField] private MornSaveKey _saveKey;

        public override void OnStateBegin()
        {
            _save.Solve().TriggerTable.GetOrCreateUserData(_saveKey);
        }
    }
}
#endif