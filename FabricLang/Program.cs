using System;
using System.Collections.Generic;
using System.Linq;
using FabricLang;

while (true)
{
    Console.WriteLine("Fabric! : ");
    string? input = Console.ReadLine();
    (List<Token> result, Exception? exception) result = new Lexer(input!).CreateTokens();

    if (result.exception is not null) // Will replace with Interpreter.Run() later
    {
        Console.WriteLine($"An exception happened! {result.exception.GetType()}: {result.exception.Message}");
    }
    else
    {
        IEnumerable<string> prettifiedTokens = result.result.Select(t => $"[{t}]");
        string tokenString = string.Join(' ', prettifiedTokens);
        Console.WriteLine(tokenString);
    }
}