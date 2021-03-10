namespace FabricLang.Types.Nodes
{
    public record BinaryOperationNode(Node Left, Node Right, TokenType Operation) : Node
    {
        public override string ToString() => $"({Left}, {Operation}, {Right})";
    }
}