namespace MornLib
{
    public interface IMornSaveKeyUserDataStore
    {
        internal MornSaveKeyUserDataTableTrigger TriggerTable { get; }
        internal MornSaveKeyUserDataTableBool BoolTable { get; }
        internal MornSaveKeyUserDataTableInt IntTable { get; }
        internal MornSaveKeyUserDataTableFloat FloatTable { get; }
        internal MornSaveKeyUserDataTableString StringTable { get; }
    }
}