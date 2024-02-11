using Model.Enums;
using Model.Moves;
using Model.Pieces;

namespace StateService
{
    public static class Machine
    {
        private const int WhitePawnStartRow = 2;
        private const int BlackPawnStartRow = 7;
        private const int WhitePieceStartRow = 1;
        private const int BlackPieceStartRow = 8;

        private static List<Piece>? currentGame = null;
        private static Piece? PieceToMove;
        private static Colour ColourToMove = Colour.White;
        private static bool IsWhiteInCheck = false;
        private static bool IsBlackInCheck = false;
        private static Move? LastMove = null;

        public static List<Piece>? CurrentGame { get => currentGame; set => currentGame = value; }

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
            var move = MoveSerializer.Serialize(moveChessNotation);

            if (move.DestinationPosition == null)
            {
                throw new Exception();
            }

            foreach (Piece piece in CurrentGame.Where(p => p.GetType().Name == move.PieceTypeToMove.ToString()))
            {
                if (piece.Colour == ColourToMove && piece.CanMove(move))
                {
                    if (PieceToMove != null)
                    {
                        throw new ArgumentException("This move is ambiguous between two potential pieces.");
                    }
                    else
                    {
                        PieceToMove = piece;
                        move.StartPosition = piece.Position;
                    }
                }

            }
            // TBD this should return message to front-end and display to user
            if (PieceToMove == null)
            {
                throw new Exception("No piece can do that move.");
            }

            PieceToMove.Position = move.DestinationPosition;

            return CurrentGame;
        }
        
        private static List<Piece> StartClassicMatch() 
        {
            var pieces = new List<Piece>();

            // loops through each column on the board, adding one white and one black pawn on respective row
            for (int i = 1; i < 9; i++) 
            {
                pieces.Add(new Pawn(Colour.White, new Position() { Column = i, Row = WhitePawnStartRow }));
                pieces.Add(new Pawn(Colour.Black, new Position() { Column = i, Row = BlackPawnStartRow }));
            }

            pieces.Add(new Rook(Colour.White, new Position() { Column = 1, Row = WhitePieceStartRow }));
            pieces.Add(new Rook(Colour.White, new Position() { Column = 8, Row = WhitePieceStartRow }));
            pieces.Add(new Rook(Colour.Black, new Position() { Column = 1, Row = BlackPieceStartRow }));
            pieces.Add(new Rook(Colour.Black, new Position() { Column = 8, Row = BlackPieceStartRow }));

            pieces.Add(new Knight(Colour.White, new Position() { Column = 2, Row = WhitePieceStartRow }));
            pieces.Add(new Knight(Colour.White, new Position() { Column = 7, Row = WhitePieceStartRow }));
            pieces.Add(new Knight(Colour.Black, new Position() { Column = 2, Row = BlackPieceStartRow }));
            pieces.Add(new Knight(Colour.Black, new Position() { Column = 7, Row = BlackPieceStartRow }));

            pieces.Add(new Bishop(Colour.White, new Position() { Column = 3, Row = WhitePieceStartRow }));
            pieces.Add(new Bishop(Colour.White, new Position() { Column = 6, Row = WhitePieceStartRow }));
            pieces.Add(new Bishop(Colour.Black, new Position() { Column = 3, Row = BlackPieceStartRow }));
            pieces.Add(new Bishop(Colour.Black, new Position() { Column = 6, Row = BlackPieceStartRow }));

            pieces.Add(new Queen(Colour.White, new Position() { Column = 4, Row = WhitePieceStartRow }));
            pieces.Add(new Queen(Colour.Black, new Position() { Column = 4, Row = BlackPieceStartRow }));

            pieces.Add(new King(Colour.White, new Position() { Column = 5, Row = WhitePieceStartRow }));
            pieces.Add(new King(Colour.Black, new Position() { Column = 5, Row = BlackPieceStartRow }));

            return pieces;
        }
        
    }
}