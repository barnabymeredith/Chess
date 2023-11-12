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

            if (PieceInitials.Contains(input.Last())) {
                move.PieceTypeToPromoteTo = GeneratePiece(input.Last());
                input = input.Remove(input[input.Length - 1], 1);
            }

            if (input[input.Length - 3] == 'x')
            {
                move.IsCapture = true;
                input = input.Remove(input.Length - 3, 1);
            }

            move.DestinationPosition = new Position();
            move.DestinationPosition.Column = Encoding.ASCII.GetBytes(input[input.Length - 2].ToString())[0] - 64;
            move.DestinationPosition.Row = Encoding.ASCII.GetBytes(input[input.Length - 1].ToString())[0] - 64;
            input = input.Remove(input.Length - 2, 2);

            if (PieceInitials.Contains(input.First()))
            {
                move.PieceTypeToMove = GeneratePiece(input[0]);
                input = input.Remove(input.First(), 1);
            }
            else
            {
                move.PieceTypeToMove = PieceType.Pawn;
            }

            switch (input.Length)
            {
                case 2:
                    move.StartPosition = new Position();
                    move.StartPosition.Column = Encoding.ASCII.GetBytes(input.First().ToString())[0] - 64;
                    move.StartPosition.Row = Encoding.ASCII.GetBytes(input.Last().ToString())[0] - 64;
                    break;
                case 1:
                    if (Enum.IsDefined(typeof(Column), input))
                    {
                        move.StartPosition = new Position();
                        move.StartPosition.Column = Encoding.ASCII.GetBytes(input)[0] - 64;
                    }
                    else
                    {
                        move.StartPosition = new Position();
                        move.StartPosition.Row = Encoding.ASCII.GetBytes(input)[0] - 64;
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
            }

            throw new ArgumentException();
        }
    }
}
