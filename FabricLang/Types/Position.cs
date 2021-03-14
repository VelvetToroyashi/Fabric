namespace FabricLang.Types
{
    public class Position
    {
        /// <summary>
        /// The current index of the <see cref="Position"/>
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// The index the position started at.
        /// </summary>
        public int StartPosition { get; set; }
        
        /// <summary>
        /// The index that the position ends.
        /// </summary>
        public int EndPosition   { get; set; }

        public Position(int startPos)
        {
            StartPosition = startPos;
        }
        
        public void Advance() => Index++;
        public void Reset() => Index = 0;
    }
}