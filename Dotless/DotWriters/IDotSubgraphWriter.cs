namespace Dotless.DotWriters
{
    public interface IDotSubgraphWriter : IDotEntityWriter
    {
        void WriteSubgraphDeclaration(string? id, bool quote);

        IDotGraphBodyWriter BeginSubgraphBody();
        void EndSubraphBody();
    }
}
