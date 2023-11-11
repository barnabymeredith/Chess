using Model.Enums;
using Model.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Moves
{
    public class Promotion : Move
    {
        public PieceType PieceTypeToPromoteTo;

        public Promotion(Position destinationPosition, bool isCapture, PieceType pieceTypeToPromoteTo) : base(PieceType.Pawn, destinationPosition, isCapture) 
        {
            PieceTypeToPromoteTo = pieceTypeToPromoteTo;
        }
    }
}
