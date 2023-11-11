using Model.Enums;

namespace Model.Pieces
{
    public class Position
    {
        private string _column;
        private string _row;

        public string Column
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

        public string Row
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

        public Position(string column, string row)
        {
            _column = column;
            _row = row;
        }
    }
}
