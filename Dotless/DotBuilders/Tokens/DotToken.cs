namespace Dotless.DotBuilders.Tokens
{
    public abstract class DotToken : IDotToken
    {
        protected readonly string _token;

        public DotToken(string token)
        {
            _token = token;
        }

        public override string ToString()
        {
            return _token;
        }
    }
}
