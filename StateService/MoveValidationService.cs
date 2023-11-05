using Model.Enums;
using Model.Pieces;

namespace StateService
{
    public static class MoveValidationService
    {
        public static PieceType? PieceTypeToMove;
        public static string Move;
        public static List<Piece> Pieces;
        public static Piece PieceToMove;

        public static bool IsMoveValid(string move, List<Piece> currentGame)
        {
            Move = move;
            Pieces = currentGame;

            if (!IsMoveSyntaxValid())
            {
                return false;
            }

            if (PieceTypeToMove == null)
            {
                SetPieceTypeToMove();
            }

            foreach (Piece piece in Pieces.Where(p => p.GetType().Name == PieceTypeToMove.ToString()))
            {
                if (PieceToMove == null && piece.CanMove(Move))
                {
                    PieceToMove = piece;
                }
                else if (PieceToMove != null && piece.CanMove(Move))
                {
                    throw new ArgumentException();
                }
            }

            return true;
        }

        public static bool IsMoveSyntaxValid()
        {
            // evaluate the number of characters in the input move to distinguish
            // the type of move played. we then evaluate what characters are contained
            switch (Move.Length)
            {
                case 2:
                    if (IsValidColumn(Move[0]) && IsValidRow(Move[1]))
                    {
                        PieceTypeToMove = PieceType.Pawn;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return true;
            }
            return false;
        }

        public static bool IsMovePositionallyValid()
        {
            return false;
        }

        public static bool IsValidColumn(char column)
        {
            return Enum.IsDefined(typeof(Column), column.ToString());
        }

        public static bool IsValidRow(char row)
        {
            var rowAsInt = (int)char.GetNumericValue(row);
            return Enum.IsDefined(typeof(Row), rowAsInt);
        }

        public static void SetPieceTypeToMove()
        {
            switch (Move[0]) 
            {
                case 'B':
                    PieceTypeToMove = PieceType.Bishop;
                    return;
                case 'K':
                    PieceTypeToMove = PieceType.King;
                    return;
                case 'N':
                    PieceTypeToMove = PieceType.Knight;
                    return;
                case 'Q':
                    PieceTypeToMove = PieceType.Queen;
                    return;
                case 'R':
                    PieceTypeToMove = PieceType.Rook;
                    return;
            }
        }
    }
}
