using Model.Enums;
using Model.Pieces;
using FluentAssertions;

namespace StateService.Tests.Unit
{
    public class MachineTests
    {
        private const int WhitePawnStartRow = 2;
        private const int BlackPawnStartRow = 7;
        private const int WhitePieceStartRow = 1;
        private const int BlackPieceStartRow = 8;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StartMatch_Success()
        {
            // Arrange
            var expectedPieces = new List<Piece>();

            for (int i = 1; i < 9; i++)
            {
                expectedPieces.Add(new Pawn(Colour.White, new Position((Column)i, (Row)WhitePawnStartRow)));
                expectedPieces.Add(new Pawn(Colour.Black, new Position((Column)i, (Row)BlackPawnStartRow)));
            }

            expectedPieces.Add(new Rook(Colour.White, new Position(Column.a, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Rook(Colour.White, new Position(Column.h, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Rook(Colour.Black, new Position(Column.a, (Row)BlackPieceStartRow)));
            expectedPieces.Add(new Rook(Colour.Black, new Position(Column.h, (Row)BlackPieceStartRow)));

            expectedPieces.Add(new Knight(Colour.White, new Position(Column.b, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Knight(Colour.White, new Position(Column.g, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Knight(Colour.Black, new Position(Column.b, (Row)BlackPieceStartRow)));
            expectedPieces.Add(new Knight(Colour.Black, new Position(Column.g, (Row)BlackPieceStartRow)));

            expectedPieces.Add(new Bishop(Colour.White, new Position(Column.c, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Bishop(Colour.White, new Position(Column.f, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Bishop(Colour.Black, new Position(Column.c, (Row)BlackPieceStartRow)));
            expectedPieces.Add(new Bishop(Colour.Black, new Position(Column.f, (Row)BlackPieceStartRow)));

            expectedPieces.Add(new Queen(Colour.White, new Position(Column.d, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new Queen(Colour.Black, new Position(Column.d, (Row)BlackPieceStartRow)));

            expectedPieces.Add(new King(Colour.White, new Position(Column.e, (Row)WhitePieceStartRow)));
            expectedPieces.Add(new King(Colour.Black, new Position(Column.e, (Row)BlackPieceStartRow)));

            var variant = Variant.Classic;

            // Act
            var result = Machine.StartMatch(variant);
            
            // Assert
            result.Should().BeEquivalentTo(expectedPieces);
        }
    }
}