using System;

namespace FabricLang.Exceptions
{
    public class LexerException : Exception
    {
        // ReSharper disable once ArrangeThisQualifier
        public override string Message => this.ToString();
        
        private readonly int _posStart;
        private readonly Type _exceptionType;
        private readonly string _message;
        public LexerException(Type exceptionType, string message, int posStart, string file = "<stdin>")
        {
            _posStart = posStart;
            _exceptionType = exceptionType;
            _message = message;
        }

        public override string ToString() => $"A(n) {_exceptionType.Name} occured while lexing: {_message}\n At: Line";

    }
}