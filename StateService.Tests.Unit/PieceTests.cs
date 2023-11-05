using Model.Enums;
using Model.Pieces;

namespace StateService.Tests.Unit
{
    public class PieceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(Colour.White, Column.a, Row.Two, "a4")]
        [TestCase(Colour.White, Column.d, Row.Four, "d5")]
        [TestCase(Colour.Black, Column.f, Row.Seven, "f5")]
        [TestCase(Colour.Black, Column.c, Row.Three, "c2")]
        public void IsMoveSyntaxValid_Success(Colour colour, Column column, Row row, string move)
        {
            // Arrange
            var pawn = new Pawn(colour, column, row);

            // Act
            var result = pawn.CanMove(move);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
