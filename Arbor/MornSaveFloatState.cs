#if USE_ARBOR
using Arbor;
using System;
using UnityEngine;
using VContainer;

namespace MornLib
{
    [Serializable]
    public class MornSaveFloatState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStoreSolver _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private bool _isAdditive;
        [SerializeField] private float _value;

        public override void OnStateBegin()
        {
            var userData = _save.Solve().FloatTable.GetOrCreateUserData(_saveKey);
            if (_isAdditive)
            {
                userData.Value += _value;
            }
            else
            {
                userData.Value = _value;
            }
        }
    }
}
#endif