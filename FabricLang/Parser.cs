using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using FabricLang.Types.Nodes;

namespace FabricLang
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private Token? _currentToken;
        private int _index = -1;
        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _currentToken = null!;
            Advance();
        }

        public BinaryOperationNode Parse() => GetExpression();


        private void Advance()
        {
            _index++;
            _currentToken = _index > _tokens.Count ? null : _tokens[_index];
        }

        private NumberNode? GetFactor()
        {
            var token = _currentToken;
            if (token?.Type is (TokenType.Int or TokenType.Float))
                return new(token);
            else return null;
        }

        private BinaryOperationNode GetTerm() => 
            MakeBinOperation(GetFactor!, new[] {TokenType.Multiply, TokenType.Divide});

        private BinaryOperationNode GetExpression() =>
            MakeBinOperation(GetTerm!, new[] {TokenType.Plus, TokenType.Minus});

        private BinaryOperationNode MakeBinOperation(Func<Node> action, TokenType[] operations)
        {
            Node left = action();
            Node right = null!;
            Token opToken = null!;
            
            while (_currentToken is not null && operations.Contains(_currentToken.Type))
            {
                opToken = _currentToken;
                Advance();
                right = action();
            }
            
            return new(left!, right!, opToken.Type);
        }
    }
}