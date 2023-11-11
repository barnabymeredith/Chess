using Model.Enums;

namespace Model.Pieces
{
    public abstract class Piece
    {
        private Colour _colour;
        private bool _isAlive;
        private Position _position;

        public Colour Colour { get => _colour; set => _colour = value; }

        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        protected Piece(Colour colour, Column column, Row row)
        {
            Column = column;
            Row = row;
            Colour = colour;
            IsAlive = true;
        }

        public abstract void Move();

        public abstract void Capture();

        public abstract bool CanMove(string move);

        public abstract bool IsMoveBlockedByOtherPiece(string move, List<Piece> pieces);

        public abstract bool SquaresToTraverse(string move);

        public string GetPositionAlgebraicNotation()
        {
            return Column.ToString() + ((int)Row).ToString();
        }
    }
}
