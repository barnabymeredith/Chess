using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateService.Tests.Unit
{
    public class MoveValidationServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsMoveSyntaxValid_Success()
        {
            // Arrange
            MoveValidationService.Move = "f4";

            // Act
            var result = MoveValidationService.IsMoveSyntaxValid();

            // Assert
            Assert.That(result, Is.True);
            Assert.That(MoveValidationService.PieceTypeToMove, Is.EqualTo(PieceType.Pawn));
        }
    }
}
