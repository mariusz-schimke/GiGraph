namespace Dotless.DotBuilders.Tokens
{
    public abstract class Token : IToken
    {
        protected readonly string _token;

        public Token(string token)
        {
            _token = token;
        }

        public override string ToString()
        {
            return _token;
        }
    }
}
