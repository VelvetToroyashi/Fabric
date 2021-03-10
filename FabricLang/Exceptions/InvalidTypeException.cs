using System;

namespace FabricLang.Exceptions
{
    /// <summary>
    /// Denotes that invalid data was passed when attempting to construct a type.
    /// </summary>
    public class InvalidTypeException : InvalidOperationException
    {
        public InvalidTypeException(string? message) : base(message) { }
    }
}