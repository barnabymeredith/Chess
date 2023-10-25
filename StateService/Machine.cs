using Model.Enums;
using Model.Pieces;

namespace StateService
{
    public static class Machine
    {
        private const int WhitePawnStartRow = 2;
        private const int BlackPawnStartRow = 7;
        private const int WhitePieceStartRow = 1;
        private const int BlackPieceStartRow = 8;

        public static List<Piece> StartMatch(Variant variant)
        {
            if (variant == Variant.Classic) 
            {
                return StartClassicMatch();
            }
            else
            {
                throw new ArgumentException(null, "That is not a valid variant.");
            }
        }

        private static List<Piece> StartClassicMatch() 
        {
            var pieces = new List<Piece>();

            // loops through each column on the board, adding one white and one black pawn on respective row
            for (int i = 1; i < 9; i++) 
            {
                pieces.Add(new Pawn(Colour.White, new Position((Column)i, (Row)WhitePawnStartRow)));
                pieces.Add(new Pawn(Colour.Black, new Position((Column)i, (Row)BlackPawnStartRow)));
            }

            pieces.Add(new Rook(Colour.White, new Position(Column.a, (Row)WhitePieceStartRow)));
            pieces.Add(new Rook(Colour.White, new Position(Column.h, (Row)WhitePieceStartRow)));
            pieces.Add(new Rook(Colour.Black, new Position(Column.a, (Row)BlackPieceStartRow)));
            pieces.Add(new Rook(Colour.Black, new Position(Column.h, (Row)BlackPieceStartRow)));

            pieces.Add(new Knight(Colour.White, new Position(Column.b, (Row)WhitePieceStartRow)));
            pieces.Add(new Knight(Colour.White, new Position(Column.g, (Row)WhitePieceStartRow)));
            pieces.Add(new Knight(Colour.Black, new Position(Column.b, (Row)BlackPieceStartRow)));
            pieces.Add(new Knight(Colour.Black, new Position(Column.g, (Row)BlackPieceStartRow)));

            pieces.Add(new Bishop(Colour.White, new Position(Column.c, (Row)WhitePieceStartRow)));
            pieces.Add(new Bishop(Colour.White, new Position(Column.f, (Row)WhitePieceStartRow)));
            pieces.Add(new Bishop(Colour.Black, new Position(Column.c, (Row)BlackPieceStartRow)));
            pieces.Add(new Bishop(Colour.Black, new Position(Column.f, (Row)BlackPieceStartRow)));

            pieces.Add(new Queen(Colour.White, new Position(Column.d, (Row)WhitePieceStartRow)));
            pieces.Add(new Queen(Colour.Black, new Position(Column.d, (Row)BlackPieceStartRow)));

            pieces.Add(new King(Colour.White, new Position(Column.e, (Row)WhitePieceStartRow)));
            pieces.Add(new King(Colour.Black, new Position(Column.e, (Row)BlackPieceStartRow)));

            return pieces;
        }
        
    }
}