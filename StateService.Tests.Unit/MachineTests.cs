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
                expectedPieces.Add(new Pawn(Colour.White, (Column)i, (Row)WhitePawnStartRow));
                expectedPieces.Add(new Pawn(Colour.Black, (Column)i, (Row)BlackPawnStartRow));
            }

            expectedPieces.Add(new Rook(Colour.White, Column.a, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Rook(Colour.White, Column.h, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Rook(Colour.Black, Column.a, (Row)BlackPieceStartRow));
            expectedPieces.Add(new Rook(Colour.Black, Column.h, (Row)BlackPieceStartRow));
                
            expectedPieces.Add(new Knight(Colour.White, Column.b, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Knight(Colour.White, Column.g, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Knight(Colour.Black, Column.b, (Row)BlackPieceStartRow));
            expectedPieces.Add(new Knight(Colour.Black, Column.g, (Row)BlackPieceStartRow));

            expectedPieces.Add(new Bishop(Colour.White, Column.c, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Bishop(Colour.White, Column.f, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Bishop(Colour.Black, Column.c, (Row)BlackPieceStartRow));
            expectedPieces.Add(new Bishop(Colour.Black, Column.f, (Row)BlackPieceStartRow));

            expectedPieces.Add(new Queen(Colour.White, Column.d, (Row)WhitePieceStartRow));
            expectedPieces.Add(new Queen(Colour.Black, Column.d, (Row)BlackPieceStartRow));

            expectedPieces.Add(new King(Colour.White, Column.e, (Row)WhitePieceStartRow));
            expectedPieces.Add(new King(Colour.Black, Column.e, (Row)BlackPieceStartRow));

            var variant = Variant.Classic;

            // Act
            var result = Machine.StartMatch(variant.ToString());
            
            // Assert
            result.Should().BeEquivalentTo(expectedPieces);
        }
    }
}