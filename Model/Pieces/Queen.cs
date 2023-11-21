using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class Queen : Piece
    {
        public Queen(Colour colour, Position position) : base(colour, position)
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