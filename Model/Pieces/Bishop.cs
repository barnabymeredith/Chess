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

            var rowDifference = move.DestinationPosition.Row - base.Position.Row;
            var colDifference = move.DestinationPosition.Column - base.Position.Column;

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

            // could make Difference() method in position class
            var rowIterator = Math.Sign(move.DestinationPosition.Row - move.StartPosition.Row);
            var colIterator = Math.Sign(move.DestinationPosition.Column - move.StartPosition.Column);

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
