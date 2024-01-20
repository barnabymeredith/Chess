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
            throw new NotImplementedException();
        }
    }
}
