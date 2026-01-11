using UnityEngine;

namespace MornLib
{
    [CreateAssetMenu(fileName = nameof(MornSaveKeyGlobal), menuName = "Morn/" + nameof(MornSaveKeyGlobal))]
    public sealed class MornSaveKeyGlobal : MornGlobalBase<MornSaveKeyGlobal>
    {
        [SerializeField] private string[] _saveKeys;
        protected override string ModuleName => nameof(MornSaveKey);
        public string[] SaveKeyNames => _saveKeys;
    }
}