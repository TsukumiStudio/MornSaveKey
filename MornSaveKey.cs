using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public class MornSaveKey : MornEnumBase
    {
        public override string[] Values => MornSaveKeyGlobal.I.SaveKeyNames;
        public override UnityEngine.Object PingTarget => MornSaveKeyGlobal.I;
    }
}
