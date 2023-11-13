using Model.Enums;

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

        public override bool CanMove(string move)
        {
            throw new NotImplementedException();
        }

        public override bool IsMoveBlockedByOtherPiece(string move, List<Piece> pieces)
        {
            throw new NotImplementedException();
        }

        public override bool SquaresToTraverse(string move)
        {
            throw new NotImplementedException();
        }
    }
}
