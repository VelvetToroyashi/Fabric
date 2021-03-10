using System;
using System.Collections.Generic;
using FabricLang.Exceptions;
using FabricLang.Types;
using FabricLang.Utilities;

namespace FabricLang
{
    public class Lexer
    {
        private Position _position;
        private char? _currentChar;
        private readonly string _text;
        public Lexer(string text, string fileName)
        {
            _text = text;
            _position = new(-1, 0, -1, fileName, text);
            
            Advance();
        }

        public void Advance()
        {
            _position.Advance(_currentChar);
            _currentChar = _position.Index >= _text.Length ? null : _text[_position.Index];
        }
        
        private char? PeekAdvance() => _position.Index + 1 >= _text.Length ? null : _text[_position.Index];

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
                            result = new(TokenType.Plus);
                            break;
                        case '-':
                            result = new(TokenType.Minus);
                            break;
                        case '*':
                            result = new(TokenType.Multiply);
                            break;
                        case '/':
                            result = new(TokenType.Divide);
                            break;
                        case '(':
                            result = new(TokenType.LeftParen);
                            break;
                        case ')':
                            result = new(TokenType.RightParen);
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
                            {
                                return (new(), te);
                            }
                        }
                        else return (new(), new LexerException(typeof(IllegalCharacterException), $"Unknown character '{_currentChar}'", _position.Index, _position.FileName));
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
                        throw new LexerException(typeof(InvalidOperationException), "Numerical values cannot have more than one decimal point.", _position.Index, _position.FileName);
                    value += _currentChar;
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