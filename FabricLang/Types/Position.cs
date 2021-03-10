namespace FabricLang.Types
{
    public struct Position
    {
        public int Index { get; private set; }
        public int LineNumber { get; private set; }
        public int ColumnNumber { get; private set; }
        public string FileName { get; }
        public string FileText { get; }


        private Position(Position other) : this(other.Index, other.LineNumber, other.ColumnNumber, other.FileName, other.FileText) { }
        public Position(int index, int lineNumber, int columnNumber, string fileName, string fileText)
        {
            Index = index;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
            FileName = fileName;
            FileText = fileText;
        }

        public Position Advance(char? currentChar)
        {
            Index++;
            ColumnNumber++;
            if (currentChar is '\n')
            {
                LineNumber++;
                ColumnNumber = 0;
            }
            return this;
        }
        public Position Copy() => new(this);
    }
}