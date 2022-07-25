namespace Interfaces.Interfaces
{
    public interface IWindType : IInstrument
    {
        public string Pipes { get; set; }

        public void Blow();
    }
}
