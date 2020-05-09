namespace Dotless.DotWriters
{
    public interface IDotGraphWriter : IDotEntityWriter
    {
        void WriteGraphDeclaration(string id, bool strict, bool quoteId);

        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}
