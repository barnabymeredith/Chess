using Model.Enums;
using Model.Moves;
using Model.Pieces;

namespace StateService.Tests.Unit
{
    public class PieceTests
    {
        [SetUp]
        public void Setup()
        {
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
    }
}
