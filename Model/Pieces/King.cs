﻿using Model.Enums;
using Model.Moves;

namespace Model.Pieces
{
    public class King : Piece
    {
        public King(Colour colour, Position position) : base(colour, position)
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