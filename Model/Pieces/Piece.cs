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
            _colour = colour;
            _isAlive = true;
            _position = position;
        }

        public abstract bool CanMove(Move move);

        public abstract List<Position>? SquaresToTraverse(Move move);

        public string GetPositionAlgebraicNotation()
        {
            return Enum.Parse(typeof(Column), Position.Column.ToString()).ToString() + Position.Row;
        }

        public bool MatchesMoveStartPosition(Move move)
        {
            if (move.StartPosition == null) return true;

            return move.StartPosition.IsEqualTo(Position);
        }

        public bool PositionIs(int row, int col)
        {
            if (row == Position.Row && col == Position.Column) return true;
            return false;
        }

        protected Tuple<int, int> GetDifferenceStartDestinationPosition(Move move)
        {
            var rowDifference = move.DestinationPosition.Row - Position.Row;
            var colDifference = move.DestinationPosition.Column - Position.Column;
            return Tuple.Create(rowDifference, colDifference);
        }
    }
}
