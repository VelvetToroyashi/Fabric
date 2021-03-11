using System.Collections.Generic;

namespace FabricLang.Types
{
    public record LexingResult(List<Token>? Tokens, bool Success, string? Reason = null);
}