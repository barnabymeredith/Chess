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
            throw new NotImplementedException();
        }

        public override List<Position> SquaresToTraverse(Move move)
        {
            throw new NotImplementedException();
        }
    }
}
