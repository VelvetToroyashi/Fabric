using System;
using System.Collections.Generic;
using System.Linq;
using FabricLang.Types;

namespace FabricLang
{
    public class Lexer
    {
        private readonly Position _pos = new(0);
        private char? _currentChar = '\0';
        private readonly string _input;
        public Lexer(string input)
        {
            _input = input;
        }

        public LexingResult Run(string input) => throw new NotImplementedException();

        private bool Advance()
        {
            if (_pos.Index > _input.Length)
            {
                _pos.Advance();
                _currentChar = _input[_pos.Index];
                return true;
            }
            return false;
        }
        

        private IReadOnlyList<Token> Tokenize()
        {
            
            
            return new List<Token>();
        }


    }
}