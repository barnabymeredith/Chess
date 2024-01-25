using Model.Enums;
using Model.Moves;

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

        public Pawn(Colour colour, Position position) : base(colour, position) 
        {
        }

        public override void Move()
        {

        }

        public override void Capture()
        {

        }

        public override bool CanMove(Move move)
        {
            if (move.DestinationPosition == null)
            {
                throw new Exception();
            }

            if (move.IsCapture && move.DestinationPosition.Column != base.Position.Column - 1 && move.DestinationPosition.Column != base.Position.Column + 1)
            {
                return false;
            }
            else if (!move.IsCapture && move.DestinationPosition.Column != base.Position.Column) return false;

            var rowStartAsInt = base.Position.Row;
            var rowEndAsInt = move.DestinationPosition.Row;
            var rowDifference = rowStartAsInt - rowEndAsInt;

            switch ((base.Colour, move.IsCapture, rowStartAsInt, rowDifference))
            {
                case (Colour.White, false, WhiteDoubleSquareStart, WhiteDoubleDifference):
                    return true;
                case (Colour.Black, false, BlackDoubleSquareStart, BlackDoubleDifference):
                    return true;
                case (Colour.White, false, > 0, WhiteSingleDifference):
                    return true;
                case (Colour.Black, false, > 0, BlackSingleDifference):
                    return true;
                case (Colour.White, true, > 0, WhiteSingleDifference):
                    return true;
                case (Colour.Black, true, > 0, BlackSingleDifference):
                    return true;
                default:
                    break;
            }
            return false;
        }

        public override List<Position>? SquaresToTraverse(Move move)
        {
            if (move.StartPosition == null || move.DestinationPosition == null)
            {
                throw new Exception();
            }

            var rowDifference = move.DestinationPosition.Row - move.StartPosition.Row;
            if (Math.Abs(rowDifference) == 2)
            {
                var squareList = new List<Position>();
                squareList.Add(new Position() { Column = base.Position.Column, Row = base.Position.Row + (rowDifference/2)});
                return squareList;
            }
            else
            {
                return null;
            }
        }
    }
}
