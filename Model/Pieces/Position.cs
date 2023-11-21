using Model.Enums;

namespace Model.Pieces
{
    public class Position
    {
        private int _column;
        private int _row;

        public int Column
        {
            get
            {
                return _column;
            }
            set
            {
                if (Enum.IsDefined(typeof(Column), value)) {
                    _column = value;
                }
            }
        }

        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                if (Enum.IsDefined(typeof(Row), value)) {
                    _row = value;
                }
            }
        }

        public bool IsEqualTo(Position other)
        {
            if (this.Column == other.Column && this.Row == other.Row) return true;
            return false;
        }
    }
}
