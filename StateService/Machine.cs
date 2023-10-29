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

        private static List<Piece> currentGame = null;

        public static List<Piece> CurrentGame { get => currentGame; set => currentGame = value; }

        public static List<Piece> StartMatch(string variant)
        {
            if (variant.ToLower() == Variant.Classic.ToString().ToLower()) 
            {
                CurrentGame = StartClassicMatch();
                return CurrentGame;
            }
            else
            {
                throw new ArgumentException(null, "That is not a valid variant.");
            }
        }

        public static List<Piece> Move(string moveChessNotation)
        {
            // if the move is a3 and there is a PAWN at a2 and no piece at a3
            
            if (moveChessNotation == "a3" && !CurrentGame.Any(p => p.GetPositionAlgebraicNotation() == "a3"))
            {
                if (CurrentGame.Any(p => p.GetType().Name == "Pawn" && p.GetPositionAlgebraicNotation() == "a2"))
                {
                    CurrentGame.Where(p => p.GetPositionAlgebraicNotation() == "a2").FirstOrDefault().Row = Row.Three;
                    return CurrentGame;
                }
                return CurrentGame;
            }
            else return CurrentGame;
        }

        private static List<Piece> StartClassicMatch() 
        {
            var pieces = new List<Piece>();

            // loops through each column on the board, adding one white and one black pawn on respective row
            for (int i = 1; i < 9; i++) 
            {
                pieces.Add(new Pawn(Colour.White, (Column)i, (Row)WhitePawnStartRow));
                pieces.Add(new Pawn(Colour.Black, (Column)i, (Row)BlackPawnStartRow));
            }

            pieces.Add(new Rook(Colour.White, Column.a, (Row)WhitePieceStartRow));
            pieces.Add(new Rook(Colour.White, Column.h, (Row)WhitePieceStartRow));
            pieces.Add(new Rook(Colour.Black, Column.a, (Row)BlackPieceStartRow));
            pieces.Add(new Rook(Colour.Black, Column.h, (Row)BlackPieceStartRow));

            pieces.Add(new Knight(Colour.White, Column.b, (Row)WhitePieceStartRow));
            pieces.Add(new Knight(Colour.White, Column.g, (Row)WhitePieceStartRow));
            pieces.Add(new Knight(Colour.Black, Column.b, (Row)BlackPieceStartRow));
            pieces.Add(new Knight(Colour.Black, Column.g, (Row)BlackPieceStartRow));

            pieces.Add(new Bishop(Colour.White, Column.c, (Row)WhitePieceStartRow));
            pieces.Add(new Bishop(Colour.White, Column.f, (Row)WhitePieceStartRow));
            pieces.Add(new Bishop(Colour.Black, Column.c, (Row)BlackPieceStartRow));
            pieces.Add(new Bishop(Colour.Black, Column.f, (Row)BlackPieceStartRow));

            pieces.Add(new Queen(Colour.White, Column.d, (Row)WhitePieceStartRow));
            pieces.Add(new Queen(Colour.Black, Column.d, (Row)BlackPieceStartRow));

            pieces.Add(new King(Colour.White, Column.e, (Row)WhitePieceStartRow));
            pieces.Add(new King(Colour.Black, Column.e, (Row)BlackPieceStartRow));

            return pieces;
        }
        
    }
}