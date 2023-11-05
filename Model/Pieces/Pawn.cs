using Model.Enums;

namespace Model.Pieces
{
    public class Pawn : Piece
    {
        public const int WhiteDoubleSquareStart = 2;
        public const int BlackDoubleSquareStart = 7;
        public const int WhiteDoubleDifference = -2;
        public const int BlackDoubleDifference = 2;
        public const int WhiteSingleDifference = -1;
        public const int BlackSingleDifference = 1;

        public Pawn(Colour colour, Column column, Row row) : base(colour, column, row) 
        {
        }

        public override void Move()
        {

        }

        public override void Capture()
        {

        }

        public override bool CanMove(string move)
        {
            if (move[0].ToString() != base.Column.ToString()) return false;

            var rowStartAsInt = (int)base.Row;
            var rowEndAsInt = Convert.ToInt32(move[1].ToString());
            var rowDifference = rowStartAsInt - rowEndAsInt;

            switch ((base.Colour, rowStartAsInt, rowDifference))
            {
                case (Colour.White, WhiteDoubleSquareStart, WhiteDoubleDifference):
                    return true;
                case (Colour.Black, BlackDoubleSquareStart, BlackDoubleDifference):
                    return true;
                case (Colour.White, > 0, WhiteSingleDifference):
                    return true;
                case (Colour.Black, > 0, BlackSingleDifference):
                    return true;
            }
            return false;
        }
    }
}
