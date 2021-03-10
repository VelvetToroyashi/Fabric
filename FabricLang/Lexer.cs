using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FabricLang.Exceptions;
using FabricLang.Utilities;

namespace FabricLang
{
    public class Lexer
    {
        private int _position = -1;
        private char? _currentChar = null;
        private readonly string _text;
        public Lexer(string text)
        {
            _text = text;
            Advance();
        }

        public void Advance()
        {
            _position++;
            _currentChar = _position >= _text.Length ? null : _text[_position];
        }
        
        private char? PeekAdvance() => _position + 1 >= _text.Length ? null : _text[_position + 1];

        public (List<Token>, Exception?) CreateTokens()
        {
            var tokens = new List<Token>();
            while (_currentChar is not null)
            {
                if (_currentChar is (' ' or '\t'))
                {
                    Advance();
                }
                else
                {
                    Token? result;
                    switch (_currentChar)
                    {
                        case '+':
                            result = new(TokenType.Plus, null);
                            break;
                        case '-':
                            result = new(TokenType.Minus, null);
                            break;
                        case '*':
                            result = new(TokenType.Multiply, null);
                            break;
                        case '/':
                            result = new(TokenType.Divide, null);
                            break;
                        case '(':
                            result = new(TokenType.LeftParen, null);
                            break;
                        case ')':
                            result = new(TokenType.RightParen, null);
                            break;
                        default:
                            result = null;
                            break;
                    }
                    
                    if (result is null)
                    {
                        if (Constants.Numbers.Contains(_currentChar.Value))
                        {
                            try { result = MakeNumber(); }
                            catch (InvalidTypeException te)
                            { return (new(), te); }
                        }
                    }
                    tokens.Add(result!);
                    Advance();
                }
            }
            
            return (tokens, null);
        }

        private Token MakeNumber()
        {
            string value = "";
            int decimalCount = 0;
            while (_currentChar is not null && Constants.Numbers.Contains(_currentChar.Value))
            {
                if (_currentChar is '.')
                {
                    decimalCount++;
                    if (decimalCount > 1)
                        throw new InvalidTypeException("Numerical values cannot have more than one decimal point.");
                    else value += _currentChar;
                }
                else
                {
                    value += _currentChar;
                    
                }
                if (Constants.Numbers.Contains(PeekAdvance() ?? ' '))
                    Advance();
                else break;
            }
            TokenType type = decimalCount is 0 ? TokenType.Int : TokenType.Float;
            
            return new(type, value);
        }
        
    }
}