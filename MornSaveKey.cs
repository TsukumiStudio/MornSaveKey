using System;
using MornEnum;

namespace MornLib
{
    [Serializable]
    public class MornSaveKey : MornEnumBase
    {
        protected override string[] Values => MornSaveKeyGlobal.I.SaveKeyNames;
    }
}