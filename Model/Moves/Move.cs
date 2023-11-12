using Model.Enums;
using Model.Pieces;

namespace Model.Moves
{
    public class Move
    {
        public PieceType PieceTypeToMove;
        public PieceType? PieceTypeToPromoteTo;
        public Position? DestinationPosition;
        public Position? StartPosition;
        public bool IsCapture;
    }
}
