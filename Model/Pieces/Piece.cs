using Model.Enums;

namespace Model.Pieces
{
    public abstract class Piece
    {
        private Colour _colour;
        private bool _isAlive;
        private Column _column;
        private Row _row;

        public Column Column { get => _column; set => _column = value; }
        public Row Row { get => _row; set => _row = value; }

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

        public string GetPositionAlgebraicNotation()
        {
            return Column.ToString() + ((int)Row).ToString();
        }
    }
}
