using Model.Enums;

namespace Model.Pieces
{
    public abstract class Piece
    {
        private int[]? _position;
        private Colour _colour;
        private bool _isAlive;

        public int[]? Position { get => _position; set => _position = value; }

        public Colour Colour { get => _colour; set => _colour = value; }

        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        protected Piece(Colour colour)
        {
            Colour = colour;
            IsAlive = true;
        }

        protected abstract void SetStartingPosition();

        protected abstract void Move();

        protected abstract void Capture();
    }
}
