using Model.Enums;

namespace Model.Pieces
{
    public class Knight : Piece
    {
        public Knight(Colour colour, Column column, Row row) : base(colour, column, row)
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
    }
}