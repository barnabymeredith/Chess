using FluentAssertions;
using Model.Enums;
using Model.Moves;
using Model.Pieces;

namespace StateService.Tests.Unit
{
    public class MoveSerializerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(PieceType.Pawn, false, 0, 0, 5, 4, "e4")]
        [TestCase(PieceType.Bishop, false, 0, 0, 1, 1, "Ba1")]
        [TestCase(PieceType.Queen, true, 0, 0, 1, 1, "Qxa1")]
        [TestCase(PieceType.Knight, true, 5, 0, 1, 1, "Nexa1")]
        [TestCase(PieceType.Rook, false, 0, 4, 1, 1, "R4a1")]
        [TestCase(PieceType.King, true, 2, 3, 1, 1, "Kb3xa1")]
        public void Serializer_Success(PieceType pieceTypeToMove, bool isCapture, int startCol, int startRow, int col, int row, string input)
        {
            Move expectedMove = new();
            // Arrange
            if (!(startCol == 0 && startRow == 0))
            {
                var startPosition = new Position()
                {
                    Column = startCol,
                    Row = startRow,
                };

                expectedMove = new Move()
                {
                    PieceTypeToMove = pieceTypeToMove,
                    IsCapture = isCapture,
                    StartPosition = startPosition ?? null,
                    DestinationPosition = new Position()
                    {
                        Column = col,
                        Row = row,
                    }
                };
            }
            else if (startCol == 0 && startRow != 0)
            {
                var startPosition = new Position()
                {
                    Row = startRow,
                };

                expectedMove = new Move()
                {
                    PieceTypeToMove = pieceTypeToMove,
                    IsCapture = isCapture,
                    StartPosition = startPosition ?? null,
                    DestinationPosition = new Position()
                    {
                        Column = col,
                        Row = row,
                    }
                };
            }
            else if (startRow == 0 && startCol != 0)
            {
                var startPosition = new Position()
                {
                    Column = startCol,
                };

                expectedMove = new Move()
                {
                    PieceTypeToMove = pieceTypeToMove,
                    IsCapture = isCapture,
                    StartPosition = startPosition ?? null,
                    DestinationPosition = new Position()
                    {
                        Column = col,
                        Row = row,
                    }
                };
            }
            else
            {
                expectedMove = new Move()
                {
                    PieceTypeToMove = pieceTypeToMove,
                    IsCapture = isCapture,
                    StartPosition = null,
                    DestinationPosition = new Position()
                    {
                        Column = col,
                        Row = row,
                    }
                };
            }

            // Act
            var result = MoveSerializer.Serialize(input);

            // Assert
            result.Should().BeEquivalentTo(expectedMove);
        }
    }
}
