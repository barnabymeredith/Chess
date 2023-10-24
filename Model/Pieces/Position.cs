namespace Model.Pieces
{
    public class Position
    {
        private const string PermittedColumns = "abcdefgh";
        private const string PermittedRows = "12345678";
        private char _column;
        private char _row;

        public char Column 
        { 
            get => _column;
            set 
            {
                if (PermittedColumns.Contains(value))
                {
                    _column = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(null, $"Column should be present in this set: {PermittedColumns}");
                }
            }
        }
        public char Row 
        { 
            get => _row;
            set
            {
                if (PermittedRows.Contains(value))
                {
                    _row = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(null, $"Row should be present in this set: {PermittedRows}");
                }
            }
        }

        public Position(char column, char row)
        {
            Column = column;
            Row = row;
        }
    }
}
