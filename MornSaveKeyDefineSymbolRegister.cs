#if UNITY_EDITOR
using UnityEditor;

namespace MornLib
{
    [InitializeOnLoad]
    public static class MornSaveKeyDefineSymbolRegister
    {
        static MornSaveKeyDefineSymbolRegister()
        {
            MornSaveKeyGlobal.I.RegisterDefineSymbol();
        }
    }
}
#endif