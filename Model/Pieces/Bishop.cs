using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Colour colour, Position position) : base(colour, position)
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

            var (rowDifference, colDifference) = GetDifferenceStartDestinationPosition(move);

            if (Math.Abs(rowDifference) - Math.Abs(colDifference) == 0)
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

            var r = move.StartPosition.Row + rowIterator;
            var c = move.StartPosition.Column + colIterator;
            while (r != move.DestinationPosition.Row && c != move.DestinationPosition.Column)
            {
                squaresToTraverse.Add(new Position()
                {
                    Row = r,
                    Column = c,
                });
                r += rowIterator;
                c += colIterator;
            }
            return squaresToTraverse;
        }
    }
}
