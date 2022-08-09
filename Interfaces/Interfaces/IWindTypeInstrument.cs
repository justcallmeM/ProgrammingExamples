namespace Interfaces.Interfaces
{
    public interface IWindTypeInstrument : IInstrument
    {
        public int LengthOfPipe { get; set; }

        public void Blow();
    }
}
