namespace Interfaces.Interfaces
{
    public interface IStringType : IInstrument
    {
        public int NumOfStrings { get; set; }

        public void Strum();
        public void Pick();
    }
}
