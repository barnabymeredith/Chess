using Model.Enums;
using Model.Pieces;

namespace Model.Moves
{
    public class Move
    {
        public PieceType PieceTypeToMove;
        public Position DestinationPosition;
        public Position? StartPosition;
        public bool IsCapture;

        public Move(PieceType pieceTypeToMove, Position destinationPosition, bool isCapture)
        {
            PieceTypeToMove = pieceTypeToMove;
            DestinationPosition = destinationPosition;
            IsCapture = isCapture;
        }

        public Move(PieceType pieceTypeToMove, Position destinationPosition, Position startPosition, bool isCapture)
        {
            PieceTypeToMove = pieceTypeToMove;
            DestinationPosition = destinationPosition;
            StartPosition = startPosition;
            IsCapture = isCapture;
        }
    }
}
