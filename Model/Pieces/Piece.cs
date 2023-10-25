using Model.Enums;

namespace Model.Pieces
{
    public abstract class Piece
    {
        private Position? _position;
        private Colour _colour;
        private bool _isAlive;

        public Position? Position { get => _position; set => _position = value; }

        public Colour Colour { get => _colour; set => _colour = value; }

        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        protected Piece(Colour colour, Position position)
        {
            Position = position;
            Colour = colour;
            IsAlive = true;
        }

        public abstract void Move();

        public abstract void Capture();
    }
}
