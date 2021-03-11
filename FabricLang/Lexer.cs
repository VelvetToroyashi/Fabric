using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FabricLang.Exceptions;
using FabricLang.Types;
using FabricLang.Utilities;

namespace FabricLang
{
    public class Lexer
    {
        private readonly string _source;
        private readonly List<Token> _tokens;
        
        private int line = 0;
        private int _index;
        private char _currentChar;

        public Lexer(string source)
        {
            _source = source;
        }
        
        public LexingResult Run() => throw new NotImplementedException("Soon™️");

        private LexingResult MakeTokens()
        {
            var tokens = new List<Token>();
            while (_currentChar is not '\0')
            {
                if (_currentChar is '\t')
                {
                    Advance();
                }
                else
                {
                    Token t = _currentChar switch
                    {
                        '+' => new(TokenType.Plus),
                        '-' => new(TokenType.Minus),
                        '/' => new(TokenType.Divide),
                        '*' => new(TokenType.Multiply),
                        '(' => new (TokenType.LeftParen),
                        ')' => new(TokenType.RightParen),

                        _ => new(TokenType.Unknown)
                    };

                    if (t.Type is TokenType.Unknown)
                    {
                        if (!Constants.Numbers.Contains(_currentChar))
                        {
                            //TODO: Make this check for other things.
                            return new(null, false, $"Unknown character '{_currentChar}'.") ;
                        }
                        else
                        {
                            try
                            {
                                t = MakeNumber();
                                tokens.Add(t);
                            }
                            catch (LexerException le)
                            {
                                return new(null, false, $"Lexer exception: {le}");
                            }
                        }
                    }
                    else
                    {
                        tokens.Add(t);
                    }
                }
            }
            return new(tokens, true);
        }
        private Token MakeNumber()
        {
            int decimalCount = 0;
            var builder = new StringBuilder();
            while (_currentChar is not '\0')
            {
                if (Constants.Numbers.Contains(_currentChar))
                {
                    builder.Append(_currentChar);
                }
                else if (_currentChar is '.')
                {
                    decimalCount++;
                    if ()
                }
            }
        }


        private char Advance()
        {
            if (_index < _source.Length)
            {
                _currentChar = _source[++_index];
                return _currentChar;
            }
            return _currentChar = '\0';
        }

        private char? Peek()
        {
            if (_currentChar is not '\0')
            {
                if (_index + 1 < _source.Length)
                    return _source[_index + 1];
                else return _currentChar;
            }
            else
            {
                return _currentChar;
            }
        }
        
        
        

    }
}