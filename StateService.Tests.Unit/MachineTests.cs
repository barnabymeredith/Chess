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
        public void FullMatch_Simple()
        {
            Machine.StartMatch("classic");
            Machine.Move("e4");
            Machine.Move("e5");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
            Machine.Move("e4");
        }
    }
}