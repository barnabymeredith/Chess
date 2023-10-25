using Model.Enums;

namespace Model.Pieces
{
    public class Position
    {
        private Column _column;
        private Row _row;

        public Column Column { get => _column; set => _column = value; }
        public Row Row { get => _row; set => _row = value; }

        public Position(Column column, Row row)
        {
            Column = column;
            Row = row;
        }
    }
}
