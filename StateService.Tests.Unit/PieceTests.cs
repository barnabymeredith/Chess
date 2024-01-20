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
                Assert.That(result.Count == 1);
                Assert.That(result[0].IsEqualTo(whiteOutputSquareList[0]));
            }
            else
            {
                Assert.That(result.Count == 1);
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
                PieceTypeToMove = PieceType.Pawn,
                DestinationPosition = new Position() { Column = destCol, Row = destRow },
                IsCapture = isCapture
            };

            // Act
            var result = bishop.CanMove(move);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
