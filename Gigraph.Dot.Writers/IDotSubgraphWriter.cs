namespace Gigraph.Dot.Writers
{
    public interface IDotSubgraphWriter : IDotEntityWriter
    {
        void WriteSubgraphDeclaration(string id, bool quote);

        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}
