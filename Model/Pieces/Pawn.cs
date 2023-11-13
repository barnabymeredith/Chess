﻿using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class Pawn : Piece
    {
        public const int WhiteDoubleSquareStart = 2;
        public const int BlackDoubleSquareStart = 7;
        public const int WhiteDoubleDifference = -2;
        public const int BlackDoubleDifference = 2;
        public const int WhiteSingleDifference = -1;
        public const int BlackSingleDifference = 1;

        public Pawn(Colour colour, Position position) : base(colour, position) 
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
            if (move.IsCapture && move.DestinationPosition.Column != base.Position.Column - 1 && move.DestinationPosition.Column != base.Position.Column + 1)
            {
                return false;
            }
            else if (!move.IsCapture && move.DestinationPosition.Column != base.Position.Column) return false;

            var rowStartAsInt = base.Position.Row;
            var rowEndAsInt = move.DestinationPosition.Row;
            var rowDifference = rowStartAsInt - rowEndAsInt;

            switch ((base.Colour, move.IsCapture, rowStartAsInt, rowDifference))
            {
                case (Colour.White, false, WhiteDoubleSquareStart, WhiteDoubleDifference):
                    return true;
                case (Colour.Black, false, BlackDoubleSquareStart, BlackDoubleDifference):
                    return true;
                case (Colour.White, false , > 0, WhiteSingleDifference):
                    return true;
                case (Colour.Black, false, > 0, BlackSingleDifference):
                    return true;
                case (Colour.White, true, > 0, WhiteSingleDifference):
                    return true;
                case (Colour.Black, true, > 0, BlackSingleDifference):
                    return true;
            }
            return false;
        }

        public override bool IsMoveBlockedByOtherPiece(string move, List<Piece> pieces)
        {
            // make Position.cs so we can return in positions to traverse, also add to piece classes
            return true;
        }

        public override bool SquaresToTraverse(string move)
        {
            throw new NotImplementedException();
        }
    }
}
