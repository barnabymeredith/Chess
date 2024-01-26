using FluentAssertions;
using Model.Enums;
using Model.Moves;
using Model.Pieces;

namespace StateService.Tests.Unit
{
    public class PieceTests
    {
        private List<Position> whiteOutputSquareList;
        private List<Position> blackOutputSquareList;

        [SetUp]
        public void Setup()
        {
            whiteOutputSquareList = new List<Position>() { new Position() { Column = 2, Row = 3 } };
            blackOutputSquareList = new List<Position>() { new Position() { Column = 1, Row = 5 } };
        }

        [TestCase(Colour.Black, 6, 6, 6, 5, false)]
        [TestCase(Colour.White, 2, 2, 3, 3, true)]
        [TestCase(Colour.Black, 7, 7, 6, 6, true)]
        [TestCase(Colour.White, 2, 2, 2, 4, false)]
        public void Pawn_CanMove_Success(Colour colour, int col, int row, int destCol, int destRow, bool isCapture)
        {
            // Arrange
            var pawn = new Pawn(colour, new Position() { Column = col, Row = row});
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Pawn,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
                IsCapture = isCapture
            };

            // Act
            var result = pawn.CanMove(move);

            // Assert
            Assert.That(result, Is.True);
        }

        [TestCase(Colour.Black, 6, 6, 6, 5, false, false)]
        [TestCase(Colour.White, 2, 2, 3, 3, true, false)]
        [TestCase(Colour.Black, 7, 7, 6, 6, true, false)]
        [TestCase(Colour.White, 2, 2, 2, 4, false, true)]
        [TestCase(Colour.Black, 1, 6, 1, 4, false, true)]
        public void Pawn_SquaresToTraverse(Colour colour, int col, int row, int destCol, int destRow, bool isCapture, bool outputSquares)
        {
            // Arrange
            var pawn = new Pawn(colour, new Position() { Column = col, Row = row });
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Pawn,
                StartPosition = pawn.Position,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
                IsCapture = isCapture
            };

            // Act
            var result = pawn.SquaresToTraverse(move);

            // Assert
            if (!outputSquares)
            {
                Assert.That(result, Is.Null);
            }
            else if (colour == Colour.White)
            {
                Assert.That(result!.Count == 1);
                Assert.That(result[0].IsEqualTo(whiteOutputSquareList[0]));
            }
            else
            {
                Assert.That(result!.Count == 1);
                Assert.That(result[0].IsEqualTo(blackOutputSquareList[0]));
            }     
        }

        [TestCase(Colour.Black, 6, 6, 4, 4, false)]
        [TestCase(Colour.White, 3, 1, 4, 2, true)]
        [TestCase(Colour.Black, 7, 1, 8, 2, true)]
        [TestCase(Colour.White, 5, 5, 8, 8, false)]
        public void Bishop_CanMove_Success(Colour colour, int col, int row, int destCol, int destRow, bool isCapture)
        {
            // Arrange
            var bishop = new Bishop(colour, new Position() { Column = col, Row = row });
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Bishop,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
                IsCapture = isCapture
            };

            // Act
            var result = bishop.CanMove(move);

            // Assert
            Assert.That(result, Is.True);
        }

        [TestCase(Colour.Black, 3, 1, 8, 6)]
        public void Bishop_SquaresToTraverse_Positive(Colour colour, int col, int row, int destCol, int destRow)
        {
            // Arrange
            var bishop = new Bishop(colour, new Position() { Column = col, Row = row });
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Bishop,
                StartPosition = bishop.Position,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
            };
            var expectedResult = new List<Position>
            {
                new Position() { Column = 4, Row = 2 },
                new Position() { Column = 5, Row = 3 },
                new Position() { Column = 6, Row = 4 },
                new Position() { Column = 7, Row = 5 }
            };

            // Act
            var result = bishop.SquaresToTraverse(move);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestCase(Colour.Black, 3, 1, 4, 3, false)]
        [TestCase(Colour.White, 5, 7, 3, 6, true)]
        [TestCase(Colour.Black, 7, 3, 8, 1, true)]
        public void Knight_CanMove_Success(Colour colour, int col, int row, int destCol, int destRow, bool isCapture)
        {
            // Arrange
            var knight = new Knight(colour, new Position() { Column = col, Row = row });
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Knight,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
                IsCapture = isCapture
            };

            // Act
            var result = knight.CanMove(move);

            // Assert
            Assert.That(result, Is.True);
        }

        [TestCase(Colour.Black, 3, 1, 8, 6)]
        public void Knight_SquaresToTraverse_Positive(Colour colour, int col, int row, int destCol, int destRow)
        {
            // Arrange
            var knight = new Knight(colour, new Position() { Column = col, Row = row });
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Knight,
                StartPosition = knight.Position,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
            };

            // Act
            var result = knight.SquaresToTraverse(move);

            // Assert
            result.Should().BeNull();
        }
        [TestCase(Colour.Black, 3, 1, 3, 6, false)]
        [TestCase(Colour.White, 5, 7, 2, 7, true)]
        [TestCase(Colour.Black, 7, 3, 7, 1, true)]
        public void Rook_CanMove_Success(Colour colour, int col, int row, int destCol, int destRow, bool isCapture)
        {
            // Arrange
            var rook = new Rook(colour, new Position() { Column = col, Row = row });
            var move = new Move()
            {
                PieceTypeToMove = PieceType.Rook,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
                IsCapture = isCapture
            };

            // Act
            var result = rook.CanMove(move);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
