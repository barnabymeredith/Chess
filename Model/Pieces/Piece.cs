using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public abstract class Piece
    {
        private Colour _colour;
        private bool _isAlive;
        private Position _position;

        public Colour Colour { get => _colour; set => _colour = value; }

        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public Position Position { get => _position; set => _position = value; }

        protected Piece(Colour colour, Position position)
        {
            Colour = colour;
            IsAlive = true;
            Position = position;
        }

        public abstract void Move();

        public abstract void Capture();

        public abstract bool CanMove(Move move);

        public abstract bool IsMoveBlockedByOtherPiece(string move, List<Piece> pieces);

        public abstract bool SquaresToTraverse(string move);

        public string GetPositionAlgebraicNotation()
        {
            return Enum.Parse(typeof(Column), Position.Column.ToString()).ToString() + Position.Row;
        }
    }
}
