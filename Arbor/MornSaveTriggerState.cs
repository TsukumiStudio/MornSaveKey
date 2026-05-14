#if USE_MORNSTATE || USE_ARBOR
#if USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#elif USE_ARBOR
using Arbor;
#endif
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
#endif // USE_MORNSTATE || USE_ARBOR
