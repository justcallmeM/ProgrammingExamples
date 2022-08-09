namespace Interfaces.Interfaces
{
    // convention is to start an interface name with a capital I.
    public interface IStringTypeInstrument : IInstrument
    {
        public int NumOfStrings { get; set; }

        public void Strum();
        public void Pick();
    }
}
