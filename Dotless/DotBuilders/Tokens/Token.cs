using Dotless.Generators;

namespace Dotless.DotBuilders.Tokens
{
    public abstract class Token : IToken
    {
        protected readonly string _token;

        public Token(string token)
        {
            _token = token;
        }

        public string ToString(GeneratorOptions options)
        {
            return _token;
        }
    }
}
