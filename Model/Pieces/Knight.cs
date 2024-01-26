using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class Knight : Piece
    {
        public Knight(Colour colour, Position position) : base(colour, position)
        {
        }

        public override bool CanMove(Move move)
        {
            var (rowDifference, colDifference) = GetDifferenceStartDestinationPosition(move);
            rowDifference = Math.Abs(rowDifference);
            colDifference = Math.Abs(colDifference);

            if (rowDifference > 0 && colDifference > 0 && rowDifference + colDifference == 3)
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