using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class Rook : Piece
    {
        public Rook(Colour colour, Position position) : base(colour, position)
        {
        }

        public override bool CanMove(Move move)
        {
            var (rowDifference, colDifference) = GetDifferenceStartDestinationPosition(move);
            rowDifference = Math.Abs(rowDifference);
            colDifference = Math.Abs(colDifference);

            if (rowDifference * colDifference == 0 && rowDifference + colDifference > 0)
            {
                return true;
            }

            return false;
        }

        public override List<Position> SquaresToTraverse(Move move)
        {
            if (move.StartPosition == null || move.DestinationPosition == null)
            {
                throw new Exception();
            }

            var squaresToTraverse = new List<Position>();

            var (rowDifference, colDifference) = GetDifferenceStartDestinationPosition(move);
            var rowIterator = Math.Sign(rowDifference);
            var colIterator = Math.Sign(colDifference);

            if (rowDifference == 0)
            {
                for (var i = move.StartPosition.Column + colIterator; i != move.DestinationPosition.Column; i+=colIterator)
                {
                    squaresToTraverse.Add(new Position() { Column = i, Row = move.StartPosition.Row });
                }
                return squaresToTraverse;
            }
            for (var i = move.StartPosition.Row + rowIterator; i != move.DestinationPosition.Row; i += rowIterator)
            {
                squaresToTraverse.Add(new Position() { Column = move.StartPosition.Column, Row = i });
            }
            return squaresToTraverse;
        }
    }
}