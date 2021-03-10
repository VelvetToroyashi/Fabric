using System;

namespace FabricLang.Exceptions
{
    public class IllegalCharacterException : Exception
    {
        public IllegalCharacterException(string? message) : base(message) { }
    }
}