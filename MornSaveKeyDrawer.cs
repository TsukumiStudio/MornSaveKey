#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MornLib
{
    [CustomPropertyDrawer(typeof(MornSaveKey))]
    public class MornSaveKeyDrawer : MornEnumDrawerBase
    {
        protected override string[] Values => MornSaveKeyGlobal.I.SaveKeyNames;
        protected override Object PingTarget => MornSaveKeyGlobal.I;
    }
}
#endif