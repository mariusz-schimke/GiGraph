using Dotless.Generators;

namespace Dotless.DotBuilders.Tokens
{
    public interface IToken
    {
        string ToString(GeneratorOptions options);
    }
}
