using Model.Enums;
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
            if (move.DestinationPosition == null)
            {
                throw new Exception();
            }

            var (rowDifference, colDifference) = GetDifferenceStartDestinationPosition(move);
            rowDifference = Math.Abs(rowDifference);
            colDifference = Math.Abs(colDifference);

            if (rowDifference + colDifference < 3 && colDifference < 2 && rowDifference < 2)
            {
                return true;
            }

            return false;
        }

        public override List<Position> SquaresToTraverse(Move move)
        {
            return null;
        }

        public List<Position> GetValidMoves()
        {
            var validMoves = new List<Position>();

            // Possible moves in relation to the current position
            int[] columnOffsets = { -1, 0, 1 };
            int[] rowOffsets = { -1, 0, 1 };

            // Loop through all combinations of column and row offsets
            foreach (int colOffset in columnOffsets)
            {
                foreach (int rowOffset in rowOffsets)
                {
                    // Skip the current position (no movement)
                    if (colOffset == 0 && rowOffset == 0)
                        continue;

                    int newColumn = this.Position.Column + colOffset;
                    int newRow = this.Position.Row + rowOffset;

                    // Check if the new position is within the board limits
                    if (newColumn >= 1 && newColumn <= 8 && newRow >= 1 && newRow <= 8)
                    {
                        validMoves.Add(new Position() { Column = newColumn, Row = newRow});
                    }
                }
            }

            return validMoves;
        }
    }
}