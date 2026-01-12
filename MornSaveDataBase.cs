using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public class MornSaveDataBase : IMornSaveKeyUserDataStore
    {
        [SerializeField] protected MornSaveKeyUserDataTableTrigger TriggerTable = new();
        [SerializeField] protected MornSaveKeyUserDataTableBool BoolTable = new();
        [SerializeField] protected MornSaveKeyUserDataTableInt IntTable = new();
        [SerializeField] protected MornSaveKeyUserDataTableFloat FloatTable = new();
        [SerializeField] protected MornSaveKeyUserDataTableString StringTable = new();
        MornSaveKeyUserDataTableTrigger IMornSaveKeyUserDataStore.TriggerTable => TriggerTable;
        MornSaveKeyUserDataTableBool IMornSaveKeyUserDataStore.BoolTable => BoolTable;
        MornSaveKeyUserDataTableInt IMornSaveKeyUserDataStore.IntTable => IntTable;
        MornSaveKeyUserDataTableFloat IMornSaveKeyUserDataStore.FloatTable => FloatTable;
        MornSaveKeyUserDataTableString IMornSaveKeyUserDataStore.StringTable => StringTable;
    }
}