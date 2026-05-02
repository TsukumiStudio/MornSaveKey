#if USE_ARBOR
using Arbor;
using System;
using UnityEngine;
using VContainer;

namespace MornLib
{
    [Serializable]
    public class MornSaveTriggerBranchState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStoreSolver _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private StateLink _successState;
        [SerializeField] private StateLink _failedState;

        public override void OnStateBegin()
        {
            var hasUserData = _save.Solve().TriggerTable.Contains(_saveKey);
            Transition(hasUserData ? _successState : _failedState);
        }
    }
}
#endif