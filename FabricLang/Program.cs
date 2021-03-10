using System;
using System.Collections.Generic;
using System.Linq;
using FabricLang;
using FabricLang.Types.Nodes;

while (true)
{
    Console.WriteLine("Fabric! : ");
    string? input = Console.ReadLine();
    (List<Token> result, Exception? exception) result = new Lexer(input!, "<stdin>").CreateTokens();
    
    if (result.exception is not null) // Will replace with Interpreter.Run() later
    {
        Console.WriteLine($"An exception happened! {result.exception.GetType().Name}: {result.exception.Message}");
    }
    else
    {
        BinaryOperationNode operationNode = new Parser(result.result).Parse();
        Console.WriteLine(operationNode);
    }
}