namespace FabricLang
{
    public sealed record Token(TokenType Type, string? Value)
    {
        public override string ToString() => !string.IsNullOrEmpty(Value) ? $"{Type}:{Value}" : Type.ToString();
    }
}