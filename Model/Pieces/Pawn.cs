using Model.Enums;

namespace Model.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Colour colour) : base(colour) 
        {
            SetStartingPosition();
        }

        protected override void SetStartingPosition()
        {
            // classic chess setup, may add other variants later e.g. fischer random
            if (this.Colour == Colour.White)
            {

            }
        }

        protected override void Move()
        {

        }

        protected override void Capture()
        {

        }
    }
}
