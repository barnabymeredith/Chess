﻿using Model.Enums;
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
        private static bool IsWhiteInCheckMate = false;
        private static bool IsBlackInCheckMate = false;
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

            if (move.IsCastlingKingSide)
            {
                var king = CurrentGame.Where(p => p.GetType().Name == "King" && p.Colour == ColourToMove).FirstOrDefault();
                var rook = CurrentGame.Where(p => p.PositionIs(king.Position.Row, king.Position.Column + 3)).FirstOrDefault();

                if (rook != null && !king.HasMoved && !rook.HasMoved)
                {
                    var newRookPosition = new Position()
                    {
                        Column = king.Position.Column + 1,
                        Row = king.Position.Row,
                    };

                    var tempRookMove = new Move()
                    {
                        DestinationPosition = newRookPosition,
                        StartPosition = rook.Position,
                        PieceTypeToMove = MoveSerializer.GeneratePiece(rook.GetType().Name[0]),
                    };

                    if (CanMoveInGameContext(tempRookMove) && !CanAnyPieceGoToAnyOfTheseSquares(rook.SquaresToTraverse(tempRookMove)))
                    {
                        rook.Position = newRookPosition;
                        king.Position = new Position()
                        {
                            Column = king.Position.Column + 2,
                            Row = king.Position.Row,
                        };

                        if (ColourToMove == Colour.White)
                        {
                            ColourToMove = Colour.Black;
                        }
                        else
                        {
                            ColourToMove = Colour.White;
                        }

                        return CurrentGame;
                    }
                }
            }

            if (move.IsCastlingQueenSide)
            {
                var king = CurrentGame.Where(p => p.GetType().Name == "King" && p.Colour == ColourToMove).FirstOrDefault();
                var rook = CurrentGame.Where(p => p.PositionIs(king.Position.Row, king.Position.Column - 4)).FirstOrDefault();

                if (rook != null && !king.HasMoved && !rook.HasMoved)
                {
                    var newRookPosition = new Position()
                    {
                        Column = king.Position.Column - 1,
                        Row = king.Position.Row,
                    };

                    var tempRookMove = new Move()
                    {
                        DestinationPosition = newRookPosition,
                        StartPosition = rook.Position,
                        PieceTypeToMove = MoveSerializer.GeneratePiece(rook.GetType().Name[0]),
                    };

                    if (CanMoveInGameContext(tempRookMove) && !CanAnyPieceGoToAnyOfTheseSquares(rook.SquaresToTraverse(tempRookMove)))
                    {
                        rook.Position = newRookPosition;
                        king.Position = new Position()
                        {
                            Column = king.Position.Column - 2,
                            Row = king.Position.Row,
                        };

                        if (ColourToMove == Colour.White)
                        {
                            ColourToMove = Colour.Black;
                        }
                        else
                        {
                            ColourToMove = Colour.White;
                        }

                        return CurrentGame;
                    }
                }
            }

            if (move.DestinationPosition == null)
            {
                PieceToMove = null;
                return null;
            }

            if (!CanMoveInGameContext(move)) 
            {
                PieceToMove = null;
                return null; 
            }

            move.StartPosition = PieceToMove!.Position;

            var pieceToRemove = CurrentGame.Where(p => p.Position.IsEqualTo(move.DestinationPosition)).FirstOrDefault();

            if (pieceToRemove != null)
            {
                CurrentGame.Remove(pieceToRemove);
            }

            var tempSaveOldPosition = PieceToMove!.Position;
            PieceToMove.Position = move.DestinationPosition;

            foreach (var piece in CurrentGame.Where(p => p.Colour != ColourToMove))
            {
                var tempgame = CurrentGame;
                var tempcoltomove = ColourToMove;
                var tempMove = new Move()
                {
                    DestinationPosition = CurrentGame.Where(p => p.Colour == ColourToMove && p.GetType().Name == "King").FirstOrDefault().Position,
                    StartPosition = piece.Position,
                    PieceTypeToMove = MoveSerializer.GeneratePiece(piece.GetType().Name[0]),
                    IsCapture = true,
                };

                if (CanMoveInGameContext(tempMove))
                {
                    if (pieceToRemove != null)
                    {
                        CurrentGame.Add(pieceToRemove);
                    }
                    PieceToMove.Position = tempSaveOldPosition;
                    PieceToMove = null;
                    return null;
                }
            }

            if (ColourToMove == Colour.White)
            {
                ColourToMove = Colour.Black;
            }
            else
            {
                ColourToMove = Colour.White;
            }

            LastMove = move;
            PieceToMove.HasMoved = true;
            PieceToMove = null;

            if (IsWhiteInCheckMate)
            {
                CurrentGame = new List<Piece>
                {
                    new Pawn(Colour.Black, new Position()),
                };
            }
            else if (IsBlackInCheckMate)
            {
                CurrentGame = new List<Piece>
                {
                    new Pawn(Colour.White, new Position()),
                };
            }
            return CurrentGame;
        }

        private static bool CanMoveInGameContext(Move move)
        {
            Piece pieceToMove = null;
            List<Position> occupiedSquares = CurrentGame.Select(c => c.Position).ToList();
            List<Position> occupiedSquaresThisPlayer = CurrentGame.Where(p => p.Colour == ColourToMove).Select(p => p.Position).ToList();
            List<Position> occupiedSquaresOtherPlayer;
            var colourToMoveTemp = ColourToMove;

            if (move.StartPosition != null)
            {
                colourToMoveTemp = CurrentGame.Where(p => p.Position.IsEqualTo(move.StartPosition)).FirstOrDefault().Colour;
            }

            if (colourToMoveTemp == Colour.White)
            {
                occupiedSquaresThisPlayer = CurrentGame.Where(p => p.Colour == Colour.White).Select(p => p.Position).ToList();
                occupiedSquaresOtherPlayer = CurrentGame.Where(p => p.Colour == Colour.Black).Select(p => p.Position).ToList();
            }
            else
            {
                occupiedSquaresThisPlayer = CurrentGame.Where(p => p.Colour == Colour.Black).Select(p => p.Position).ToList();
                occupiedSquaresOtherPlayer = CurrentGame.Where(p => p.Colour == Colour.White).Select(p => p.Position).ToList();
            }

            if (!move.IsCapture && occupiedSquares.Any(s => s.IsEqualTo(move.DestinationPosition)))
            {
                return false;
            }

            if (move.IsCapture && !occupiedSquares.Any(s => s.IsEqualTo(move.DestinationPosition)))
            {
                return false;
            }

            foreach (Piece piece in CurrentGame.Where(p => p.GetType().Name == move.PieceTypeToMove.ToString()))
            {
                move.StartPosition = piece.Position;

                if (piece.Colour == colourToMoveTemp && piece.CanMove(move) && !move.DestinationPosition.IsEqualToAnyInList(occupiedSquaresThisPlayer))
                {
                    if (piece.SquaresToTraverse(move) != null)
                    {
                        if (!piece.SquaresToTraverse(move).Any(s => s.IsEqualToAnyInList(occupiedSquares)))
                        {
                            // This statement being true means two pieces can do this move, thus it is too ambigious to be a valid move.
                            if (pieceToMove != null)
                            {
                                move.StartPosition = null;
                                return false;
                            }
                            else
                            {
                                pieceToMove = piece;
                            }
                        }
                    }
                    else
                    {
                        if (pieceToMove != null)
                        {
                            move.StartPosition = null;
                            return false;
                        }
                        else
                        {
                            pieceToMove = piece;
                        }
                    }
                }
            }

           if (pieceToMove == null)
            {
                return false;
            }

            if (occupiedSquares.Any(s => s.IsEqualTo(move.DestinationPosition)) && (CurrentGame.Where(p => p.Position.IsEqualTo(move.DestinationPosition)).FirstOrDefault().Colour == pieceToMove.Colour))
            {
                return false;
            }

            if (PieceToMove == null)
            {
                PieceToMove = pieceToMove;
            }

            return true;
        }

        private static bool CanAnyPieceGoToAnyOfTheseSquares(List<Position> positions)
        {
            foreach (Position position in positions)
            {
                foreach (var piece in CurrentGame.Where(p => p.Colour != ColourToMove))
                {
                    var tempMove = new Move()
                    {
                        DestinationPosition = position,
                        StartPosition = piece.Position,
                        PieceTypeToMove = MoveSerializer.GeneratePiece(piece.GetType().Name[0]),
                        IsCapture = true,
                    };

                    if (CanMoveInGameContext(tempMove))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CanAPieceGoToAllOfTheseSquares(List<Position> positions)
        {
            foreach (Position position in positions)
            {
                foreach (var piece in CurrentGame.Where(p => p.Colour != ColourToMove))
                {
                    var tempMove = new Move()
                    {
                        DestinationPosition = position,
                        StartPosition = piece.Position,
                        PieceTypeToMove = MoveSerializer.GeneratePiece(piece.GetType().Name[0]),
                        IsCapture = true,
                    };

                    if (CanMoveInGameContext(tempMove))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsThisKingCheckMated(Colour colour)
        {
                foreach (var position in CurrentGame.Where(p => p.Colour != ColourToMove))
                {
                    var tempMove = new Move()
                    {
                        DestinationPosition = position,
                        StartPosition = piece.Position,
                        PieceTypeToMove = MoveSerializer.GeneratePiece(piece.GetType().Name[0]),
                        IsCapture = true,
                    };

                    if (CanMoveInGameContext(tempMove))
                    {
                        return true;
                    }
            }
            return false;
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