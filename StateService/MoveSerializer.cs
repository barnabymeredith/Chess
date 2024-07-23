using Model.Enums;
using Model.Moves;
using Model.Pieces;
using System.Text;

namespace StateService
{
    public static class MoveSerializer
    {
        private const string PieceInitials = "BKNQR";

        public static Move Serialize(string input)
        {
            var move = new Move();

            // pawn promotion
            if (PieceInitials.Contains(input.Last())) {
                move.PieceTypeToPromoteTo = GeneratePiece(input.Last());
                input = input.Remove(input.Length - 1, 1);
            }
            else
            {
                move.PieceTypeToPromoteTo = PieceType.None;
            }

            // capture
            if (input.Length > 2 && input[input.Length - 3] == 'x')
            {
                move.IsCapture = true;
                input = input.Remove(input.Length - 3, 1);
            }

            move.DestinationPosition = new Position();
            move.DestinationPosition.Column = Encoding.ASCII.GetBytes(input[input.Length - 2].ToString())[0] - 96;
            move.DestinationPosition.Row = Int32.Parse(input[input.Length - 1].ToString());
            input = input.Remove(input.Length - 2, 2);

            if (input.Length > 0 && PieceInitials.Contains(input.First()))
            {
                move.PieceTypeToMove = GeneratePiece(input[0]);
                input = input.Remove(0, 1);
            }
            else
            {
                move.PieceTypeToMove = PieceType.Pawn;
            }

            switch (input.Length)
            {
                case 2:
                    move.StartPosition = new Position();
                    move.StartPosition.Column = Encoding.ASCII.GetBytes(input.First().ToString())[0] - 96;
                    move.StartPosition.Row = Int32.Parse(input.Last().ToString());
                    break;
                case 1:
                    if (Enum.IsDefined(typeof(Column), input))
                    {
                        move.StartPosition = new Position();
                        move.StartPosition.Column = Encoding.ASCII.GetBytes(input)[0] - 96;
                    }
                    else
                    {
                        move.StartPosition = new Position();
                        move.StartPosition.Row = Int32.Parse(input);
                    }
                    break;
            }
            return move;
        }

        public static PieceType GeneratePiece(char initial)
        {
            switch (initial)
            {
                case 'B':
                    return PieceType.Bishop;
                case 'K':
                    return PieceType.King;
                case 'N':
                    return PieceType.Knight;
                case 'Q':
                    return PieceType.Queen;
                case 'R':
                    return PieceType.Rook;
                default:
                    return PieceType.Pawn;
            }

            throw new ArgumentException();
        }
    }
}
