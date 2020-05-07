namespace Dotless.DotWriters
{
    public interface IDotGraphWriter : IDotEntityWriter
    {
        void WriteGraphDeclaration(string? id, bool directed, bool strict, bool quoteId);

        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}
