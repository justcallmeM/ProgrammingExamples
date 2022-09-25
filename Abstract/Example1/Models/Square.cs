namespace Abstract.Example1.Models
{
    using Abstract.Example1.Models.Abstractions;

    class Square : Shape
    {
        private int _sideLength;

        public Square(int sideLength) => _sideLength = sideLength;

        // GetArea method is required to avoid a compile-time error.
        public override int GetArea() => _sideLength * _sideLength;
    }
}