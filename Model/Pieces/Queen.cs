using Model.Enums;

namespace Model.Pieces
{
    public class Queen : Piece
    {
        public Queen(Colour colour, Column column, Row row) : base(colour, column, row)
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