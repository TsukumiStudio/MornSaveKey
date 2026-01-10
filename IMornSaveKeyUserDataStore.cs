namespace MornLib
{
    public interface IMornSaveKeyUserDataStore
    {
        public MornSaveKeyUserDataTableTrigger TriggerTable { get; }
        public MornSaveKeyUserDataTableBool BoolTable { get; }
        public MornSaveKeyUserDataTableInt IntTable { get; }
        public MornSaveKeyUserDataTableFloat FloatTable { get; }
        public MornSaveKeyUserDataTableString StringTable { get; }
    }
}