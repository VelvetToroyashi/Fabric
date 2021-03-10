namespace FabricLang
{
    public sealed record Token(TokenType Type, string? Value = null)
    {
        public override string ToString() => !string.IsNullOrEmpty(Value) ? $"{Type}:{Value}" : Type.ToString();
    }
}