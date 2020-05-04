namespace Dotless.DotWriters
{
    public interface IDotSubgraphWriter : IDotWriter
    {
        void WriteSubgraphDeclaration(string? name, bool quote);

        IDotGraphBodyWriter BeginSubgraphBody();
        void EndSubraphBody();
    }
}
