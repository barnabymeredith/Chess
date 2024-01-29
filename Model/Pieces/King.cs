using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class King : Piece
    {
        public King(Colour colour, Position position) : base(colour, position)
        {
        }

        public override bool CanMove(Move move)
        {
            if (move.DestinationPosition == null)
            {
                throw new Exception();
            }

            var (rowDifference, colDifference) = GetDifferenceStartDestinationPosition(move);
            rowDifference = Math.Abs(rowDifference);
            colDifference = Math.Abs(colDifference);

            if (rowDifference + colDifference < 3 && colDifference < 2 && rowDifference < 2)
            {
                return true;
            }

            return false;
        }

        public override List<Position> SquaresToTraverse(Move move)
        {
            return null;
        }
    }
}